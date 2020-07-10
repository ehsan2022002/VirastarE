using Balloon.NET;
using BorzoyaSpell;
using NetOffice.Tools;
//using NetOffice.OutlookApi.Tools;
//using NetOffice.Tools;
using NetOffice.WordApi.Enums;
using NetOffice.WordApi.Tools;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Word = NetOffice.WordApi;
using NetOffice.OfficeApi.Tools;
using NetOffice.OfficeApi;
using System.Threading;
using LDA;

namespace VirastarE
{
    [COMAddin("VirastarE", "farsi spell checker", LoadBehavior.LoadAtStartup), ProgId("VirastarE.Addin"), Guid("51CFA53D-03D0-4192-8380-85A811807747"), Codebase]
	[RegistryLocation(RegistrySaveLocation.InstallScopeCurrentUser), CustomUI("RibbonUI.xml", true)]
	[MultiRegister(RegisterIn.Word, RegisterIn.Outlook)]
	public class Addin : Word.Tools.COMAddin
	{

        
        bool IgnoreAllSpell = false;

        CheakSpell _BcheakSpell; 
        
        List<PunchPattern> lpck;
        PunchPattern currentPuncPattern;

        //BackgroundWorker m_oWorkerPunch;
        //BackgroundWorker m_oWorkerSpell;

        System.Globalization.PersianCalendar persiancalendar ;

        CPPPunctuation cpPuncForm;
        CPPSPell cpSpellForm;


        //threading 
        Thread bgThread;
        Thread SpellThread;
        Thread PuncThread;
        bool isrunningSpellThread;
        bool isrunningPuncThread;

        public Addin()
		{

                this.OnStartupComplete += new OnStartupCompleteEventHandler(Addin_OnStartupComplete);
                this.OnDisconnection += new OnDisconnectionEventHandler(Addin_OnDisconnection);
                
                //m_oWorkerSpell = new BackgroundWorker();
                //m_oWorkerSpell.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
                //m_oWorkerSpell.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorkerSpell_RunWorkerCompleted);

                //m_oWorkerPunch = new BackgroundWorker();
                //m_oWorkerPunch.DoWork += new DoWorkEventHandler(m_oWorkerDoWork2);
                //m_oWorkerPunch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorkerPunch_RunWorkerCompleted);

                persiancalendar = new System.Globalization.PersianCalendar();
        }



        #region BackGroundProcess
        
        private string GetShamsiDate_Now()
        {
            
            return persiancalendar.GetYear(DateTime.Now) + "/" +
                   persiancalendar.GetMonth(DateTime.Now) + "/" +
                   persiancalendar.GetDayOfMonth(DateTime.Now) + " " + DateTime.Now.ToString("HH:mm:ss"); ;   
        }

        #endregion BackGroundProcess

        private void Addin_OnStartupComplete(ref Array custom)
		{
            try
            {

            this.Application.NewDocumentEvent += Application_NewDocumentEvent;
            //this.Application.DocumentBeforeCloseEvent += Application_DocumentBeforeCloseEvent;
            //this.Application.DocumentBeforeSaveEvent += Application_DocumentBeforeSaveEvent;
            //this.Application.DocumentBeforePrintEvent += Application_DocumentBeforePrintEvent;
            this.Application.DocumentOpenEvent += Application_DocumentOpenEvent;

            this.Application.WindowBeforeDoubleClickEvent += Application_WindowBeforeDoubleClickEvent;
            this.Application.WindowBeforeRightClickEvent += Application_WindowBeforeRightClickEvent;

            setupSpell();
            setupKeyBoardHooks();
            SetupBgThread();
                
                

                try
                {  //welcome page not show
                    GlobalClass.myword = this.Application;
                    GlobalClass.mydoc = this.Application.ActiveDocument;

                }
                catch { }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/n" + ex.InnerException);
            }

        }


        private void SetupBgThread()
        {
            bgThread = new Thread(chkTask);
            bgThread.IsBackground = true;
            bgThread.SetApartmentState(System.Threading.ApartmentState.STA);
            bgThread.Priority = ThreadPriority.Lowest;
            bgThread.Start();

        }

       
        public void chkTask()
        {
            while (true)
            {
                Thread.Sleep(8000);
                if (RegistaryApplicationSetting.GetRegistaryKey("chkRecSpell") == "1" && isrunningSpellThread ==false)
                    btnSpell_Click(null);

                Thread.Sleep(8000);
                if (RegistaryApplicationSetting.GetRegistaryKey("chkPunkRec") == "1" && isrunningPuncThread==false)
                    btnPunctuation_Click(null);
            }
        }


        private void Application_WindowBeforeDoubleClickEvent(Word.Selection sel, ref bool cancel)
        {
            //throw new NotImplementedException();
        }

        private void setupKeyBoardHooks()
        {
            ShortcutManager.Start();
            ShortcutManager.KeyDown += ShortcutManager_KeyDown;
        }

        private void ShortcutManager_KeyDown(object sender, KeyEventArgs e)
        { //ketpree 
            if (e.KeyCode == Keys.F11)
            {
                btnSpell_Click(null);
            }

            if (e.KeyCode == Keys.F9)
            {
                // Console.WriteLine("control F10");
                btnNormalizaer_Click(null);
            }

            //throw new NotImplementedException();
        }

        private void setupSpell()
        {
            Application.Options.AutoFormatReplaceQuotes = false;
            Application.Options.AutoFormatAsYouTypeReplaceQuotes = false;
                                    
            _BcheakSpell = new CheakSpell();
            _BcheakSpell.IgnoreEnglish = RegistaryApplicationSetting.GetRegistaryKey("chkIgnoreEnglish") == "1" ? true : false;
            _BcheakSpell.SpellLavel = 1; // int.Parse(RegistaryApplicationSetting.GetRegistaryKey("trackBar1") == "" ? "1" : RegistaryApplicationSetting.GetRegistaryKey("trackBar1"));
            _BcheakSpell.CheakSteem = RegistaryApplicationSetting.GetRegistaryKey("chkStemSpell") == "1" ? true : false;
            _BcheakSpell.IgnoreChars = RegistaryApplicationSetting.GetRegistaryKey("txtIgnoreList");
            //stm = new Stemmer();

        }


        private void Application_WindowBeforeRightClickEvent(Word.Selection sel, ref bool cancel)
        {
            GlobalClass.myselection = sel;
            Word.Range r = GlobalClass.myword.Selection.Range;

            int left, top, width, height;
            GlobalClass.myword.ActiveWindow.GetPoint(out left, out top, out width, out height, r);

            var x = sel.Range.Words[1].Text;
            var s = sel.Range.Words.Count;
            
            PunchPattern pp = null;
            if (lpck != null)
                pp = lpck.Find(t => t.IndexStart <= sel.Range.Start && t.IndexEnd >= sel.Range.End);


            if (pp != null && pp.ErrorCode > 0)
            {
                cancel = true;
                currentPuncPattern = pp;
                cpPuncForm = new CPPPunctuation();
                cpPuncForm.Deactivate += CpPuncForm_Deactivate;

                cpPuncForm.ShowBallonScreen(new Point(left, top));
                cpPuncForm.ShowFormWithMessage = pp.ErroMessage + Environment.NewLine + pp.ErrorCorrection;

            }
            else
            {
                //else spell        
                var b = _BcheakSpell.Cheak_Spell(x.Trim());
                
                if ((x.Trim().Length > 1) && (s == 1) && (b == false))
                {
                    cancel = true;
                    cpSpellForm = new CPPSPell();
                    cpSpellForm.Deactivate += cpSpellForm_Deactivate;

                    cpSpellForm.ShowBallonScreen(new Point(left, top));

                    var sl = _BcheakSpell.Suggest(x);
                    //var sl = _SpellChecker.Suggestions;

                    cpSpellForm.ShowDlg(sl);
                    //finally
                }
            }
        }


        private void CpPuncForm_Deactivate(object sender, EventArgs e)
        {
            lpck.Remove(currentPuncPattern);
            CheakPunctuation(false);
        }
        private void CheakPunctuation(bool ReCheak)
        {

            if (GlobalClass.mydoc == null)
                return;

            isrunningPuncThread = true;
            try
            {
                //paragrapth
                Application.UndoRecord.StartCustomRecord("VirastarE Punc");

                string p = GlobalClass.mydoc.Content.Text;
                if (p.Trim().Length > 4)
                {

                    if (ReCheak == true)
                        lpck = PunctuationCkeak.PunctuationChk(p);

                    Word.Range rng = GlobalClass.mydoc.Range();

                    GlobalClass.mydoc.Range().Font.Underline = WdUnderline.wdUnderlineNone;
                    GlobalClass.mydoc.Range().Font.UnderlineColor = WdColor.wdColorWhite;

                    foreach (var pr in lpck)
                    {
                        if (pr.ErrorCode > 0)
                        {
                            rng.Start = pr.IndexStart;
                            rng.End = (pr.IndexStart + pr.IndexLenght);
                            rng.Font.Underline = WdUnderline.wdUnderlineWavy;
                            rng.Font.UnderlineColor = WdColor.wdColorLightBlue;
                        }
                    }
                }//if

                Application.UndoRecord.EndCustomRecord();
            }
            catch { }
            finally{
                isrunningPuncThread = false;
            }
        }
        private void cpSpellForm_Deactivate(object sender, EventArgs e)
        {
            //read selected value from baloon form 
            bool isWordingored = cpSpellForm.IsIgnored;
            bool isWordAdd = cpSpellForm.IsAdd;
            bool isWordSelect = cpSpellForm.IsSelect;
            string selectedWord = cpSpellForm.SelectedWord;
            IgnoreAllSpell = cpSpellForm.IsIgnoreAll;

            if (isWordSelect == true)
            {
                _BcheakSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);

                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Text = selectedWord + " ";                

            }

            if (isWordingored == true || IgnoreAllSpell == true)
            {
                _BcheakSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (isWordAdd == true)
            {
                _BcheakSpell.AddtoUserDic(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (IgnoreAllSpell == true)
            {
                //CheakSpellDoc();
                btnSpell_Click(null);
            }

        }


        private void CheakSpellDoc()
        {
            // FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            isrunningSpellThread = true;

            try
            {
                if (GlobalClass.myword.ActiveDocument != null)
                {
                   
                    var doc = GlobalClass.myword.ActiveDocument;
                    //doc.Content.Text = farsiNormalizer.Run(doc.Content.Text);

                    
                    Application.UndoRecord.StartCustomRecord("VirastarE Spell");
                    for (int i = 1; i < GlobalClass.mydoc.Words.Count; i++)
                    {

                        var s = doc.Content.Words[i].Text.Trim();
                        //var ss = stm.run(s);

                        bool b1 = _BcheakSpell.Cheak_Spell(s);
                        bool b2 = _BcheakSpell.isInIgnoreList(s);
                        //bool b3 = _BcheakSpell.Cheak_Spell(ss);  //b3=b1

                        
                        if (((b1 == false) && b2 == false))
                        {
                            doc.Content.Words[i].Underline = WdUnderline.wdUnderlineWavy;
                            doc.Content.Words[i].Font.UnderlineColor = WdColor.wdColorRed;
                        }
                        else
                        {
                            doc.Content.Words[i].Underline = WdUnderline.wdUnderlineNone;
                            doc.Content.Words[i].Font.UnderlineColor = WdColor.wdColorWhite;
                        }
                        

                    }

                    Application.UndoRecord.EndCustomRecord();
                    //IgnoreAllSpell = false;
                }
            }
            catch (Exception ex)
            { }
            finally {
                isrunningSpellThread = false;
            }
        }


        
        private void Application_DocumentOpenEvent(Word.Document doc)
        {
            //Console.WriteLine(doc.FullName);
            GlobalClass.mydoc = doc;
        }

        private void Application_NewDocumentEvent(Word.Document doc)
        {
            //Console.WriteLine(doc.FullName);
            GlobalClass.mydoc = doc;
            //doc.ContentControlOnEnterEvent += Doc_ContentControlOnEnterEvent;
        }
               
        private void Addin_OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
		{
            try
            {
                if (bgThread !=null && bgThread.IsAlive )
                    this.bgThread.Abort();

                if (SpellThread != null && SpellThread.IsAlive)
                    this.SpellThread.Abort();

                if (PuncThread != null && PuncThread.IsAlive)
                    this.PuncThread.Abort();
            }
            catch { }

        }

        

		
		protected override void OnError(ErrorMethodKind methodKind, System.Exception exception)
		{
            MessageBox.Show(methodKind.ToString() + " " + exception.Message);

            //Utils.Dialog.ShowError(exception, "An error occurend in " + methodKind.ToString());
		}

		[RegisterErrorHandler]
		public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, System.Exception exception)
		{
            MessageBox.Show(methodKind.ToString() + " " + exception.Message);
            //Office.Tools.Contribution.DialogUtils.ShowRegisterError("VirastarE", methodKind, exception);
		}


        private static object _syncSpellThread = new object();
        public void btnSpell_Click(IRibbonControl control)
        {


            if (SpellThread == null ||
              (SpellThread.ThreadState != System.Threading.ThreadState.Running &&
                SpellThread.ThreadState != System.Threading.ThreadState.WaitSleepJoin)
             )
            {
                lock (_syncSpellThread)
                {
                    SpellThread = new Thread(SpellDoWork);
                    SpellThread.IsBackground = true;
                    SpellThread.Start();
                }
            }
        }


        public void SpellDoWork()
        {
            Application.StatusBar = " بازبینی املا ... ";
            CheakSpellDoc();
            Application.StatusBar = " بازبینی املایی انجام شد " + GetShamsiDate_Now();
        }

        private static object _syncPuncThread = new object();
        public void btnPunctuation_Click(IRibbonControl control)
        {

            if (PuncThread == null ||
              (PuncThread.ThreadState != System.Threading.ThreadState.Running &&
                PuncThread.ThreadState != System.Threading.ThreadState.WaitSleepJoin)
             )
            {
                lock (_syncPuncThread)
                {
                    PuncThread = new Thread(PunchDoWork);
                    PuncThread.IsBackground = true;
                    PuncThread.Start();
                }
            }
                                  
        }

        public void PunchDoWork()
        {
            Application.StatusBar = " بازبینی نگارش ... ";
            CheakPunctuation(true);
            Application.StatusBar = " بازبینی نگارش انجام شد " + GetShamsiDate_Now();
        }

        public void btnNormalizaer_Click(IRibbonControl control)
        {
            FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            var doc = GlobalClass.myword.ActiveDocument;
            
            if (doc.ActiveWindow.Selection.Text.Trim().Length > 1)
                doc.ActiveWindow.Selection.Text = farsiNormalizer.Run(doc.ActiveWindow.Selection.Text);
            else
                doc.Content.Text = farsiNormalizer.Run(doc.Content.Text);


        }
        public void btnSummerizer_Click(IRibbonControl control)
        {
            string sent = string.Empty;
            var doc = GlobalClass.myword.ActiveDocument;

            if (doc.ActiveWindow.Selection.Text.Trim().Length > 0)
                sent = doc.ActiveWindow.Selection.Text;
            else
                sent = doc.Content.Text;


            Form frm = new TextSummarize.frmSummary(sent);
            
            frm.Show();
        }
        public void btnSetting_Click(IRibbonControl control)
        {
            var frm = new Forms.frmSetting(_BcheakSpell);
            frm.Show();
            Application.StatusBar = "تنظیمات";
            
        }

        public void btnSLDA_Click(IRibbonControl control)
        {
            var frm = new frmLDA();
            frm.Show();
            Application.StatusBar = "تاپیک مدلینگ";
        }


    }
}

