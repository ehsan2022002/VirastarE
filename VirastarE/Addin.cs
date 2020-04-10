using Balloon.NET;
using BorzoyaSpell;
using NetOffice.OfficeApi.Tools;
using NetOffice.OutlookApi.Tools;
using NetOffice.Tools;
using NetOffice.WordApi.Enums;
using NetOffice.WordApi.Tools;
//using NetSpell.SpellChecker.Dictionary;
//using NetSpell.SpellChecker;
using Stemming.Persian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = NetOffice.OfficeApi;
using Word = NetOffice.WordApi;

namespace VirastarE
{
    [COMAddin("VirastarE", "farsi spell checker", LoadBehavior.LoadAtStartup), ProgId("VirastarE.Addin"), Guid("51CFA53D-03D0-4192-8380-85A811807747"), Codebase]
	[RegistryLocation(RegistrySaveLocation.InstallScopeCurrentUser), CustomUI("RibbonUI.xml", true)]
	[MultiRegister(RegisterIn.Word, RegisterIn.Outlook)]
	public class Addin : Word.Tools.COMAddin
	{

        CPPSPell cpSpellForm;
        //WordDictionary _dictionary;
        //Spelling _SpellChecker;

        CheakSpell _BcheakSpell; 

        bool IgnoreAllSpell = false;
        Stemmer stm;
        List<PunchPattern> lpck;
        PunchPattern currentPuncPattern;

        BackgroundWorker m_oWorkerPunch;
        BackgroundWorker m_oWorkerSpell;
        public Addin()
		{
			this.OnStartupComplete += new OnStartupCompleteEventHandler(Addin_OnStartupComplete);
			this.OnDisconnection += new OnDisconnectionEventHandler(Addin_OnDisconnection);
            m_oWorkerSpell = new BackgroundWorker();
            m_oWorkerSpell.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorkerSpell.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorkerSpell_RunWorkerCompleted);

            m_oWorkerPunch = new BackgroundWorker();
            m_oWorkerPunch.DoWork += new DoWorkEventHandler(m_oWorkerDoWork2);
            m_oWorkerPunch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorkerPunch_RunWorkerCompleted);

        }

        private void m_oWorkerPunch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.StatusBar = " برسی نگارش انجام شد " + GetShamsiDate_Now();
        }

        private void m_oWorkerSpell_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.StatusBar = " برسی املایی انجام شد " + GetShamsiDate_Now();
        }
        
        private void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.StatusBar = " برسی املا ... ";
            CheakSpellDoc();
            
        }

        private void m_oWorkerDoWork2(object sender, DoWorkEventArgs e)
        {
            Application.StatusBar = " برسی نگارش ... ";
            CheakPunctuation(true);
            //Application.StatusBar = " برسی نگارش انجام شد " + GetShamsiDate_Now();
        }

        private string GetShamsiDate_Now()
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(DateTime.Now) + "/" +
                   pc.GetMonth(DateTime.Now) + "/" +
                   pc.GetDayOfMonth(DateTime.Now) + " " + DateTime.Now.ToString("HH:mm:ss"); ;   
        }
        private void Addin_OnStartupComplete(ref Array custom)
		{
			Console.WriteLine("Addin started in {0}", Application.InstanceFriendlyName);
            //TaskPanes[0].Visible = false;

            this.Application.NewDocumentEvent += Application_NewDocumentEvent;
            this.Application.DocumentBeforeCloseEvent += Application_DocumentBeforeCloseEvent;
            this.Application.DocumentBeforeSaveEvent += Application_DocumentBeforeSaveEvent;
            this.Application.DocumentBeforePrintEvent += Application_DocumentBeforePrintEvent;
            this.Application.DocumentOpenEvent += Application_DocumentOpenEvent;

            this.Application.WindowBeforeRightClickEvent += Application_WindowBeforeRightClickEvent;

            GlobalClass.myword = this.Application;
            ///

            setupSpell();
            setupKeyBoardHooks();
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

            if (e.KeyCode == Keys.F10)
            {
               // Console.WriteLine("control F10");
            }

            //throw new NotImplementedException();
        }

        private void setupSpell()
        {
            Application.Options.AutoFormatReplaceQuotes = false;
            Application.Options.AutoFormatAsYouTypeReplaceQuotes = false;

            //_dictionary = new WordDictionary();
            //_dictionary.DictionaryFolder = @"";
            //_dictionary.DictionaryFile = "fa_IR_netspell.dic";
            //_dictionary.Initialize();

            
            _BcheakSpell = new CheakSpell();
            //_cheakSpell.Initialize(); 

            stm = new Stemmer();
        }


        private void Application_WindowBeforeRightClickEvent(Word.Selection sel, ref bool cancel)
        {
            GlobalClass.myselection = sel;
            Word.Range r = GlobalClass.myword.Selection.Range;

            int left, top, width, height;
            GlobalClass.myword.ActiveWindow.GetPoint(out left, out top, out width, out height, r);

            var x = sel.Range.Words[1].Text;
            var s = sel.Range.Words.Count;
            ///////
            PunchPattern pp = null;
            if (lpck != null)
                pp = lpck.Find(t => t.IndexStart <= sel.Range.Start && t.IndexEnd >= sel.Range.End);


            if (pp != null && pp.ErrorCode > 0)
            {
                cancel = true;
                currentPuncPattern = pp;
                CPPPunctuation cpPuncForm = new CPPPunctuation();
                cpPuncForm.Deactivate += CpPuncForm_Deactivate;

                cpPuncForm.ShowBallonScreen(new Point(left, top));
                cpPuncForm.ShowFormWithMessage = pp.ErroMessage + Environment.NewLine + pp.ErrorCorrection;

            }
            else
            {
                //else spell        
                var b = _BcheakSpell.Cheak_Spell(x.Trim());
                bool b2 =false; 

                if (b == false)
                {                     
                    b2 = _BcheakSpell.Cheak_Spell(stm.run(x.Trim()));
                }

                if ((x.Trim().Length > 1) && (s == 1) && (b == false && b2 == false))
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
            //string s = "برای تست ) نوشته میشود";
            //var pr = PunctuationCkeak.PunctuationChk(s);

            //paragrapth
            Application.UndoRecord.StartCustomRecord();

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
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Text = selectedWord + " ";                

            }

            if (isWordingored == true)
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
                CheakSpellDoc();
            }

        }


        private void CheakSpellDoc()
        {
            // FarsiNormalizer farsiNormalizer = new FarsiNormalizer();

            try
            {
                if (GlobalClass.myword.ActiveDocument != null)
                {
                    Application.UndoRecord.StartCustomRecord();
                    var doc = GlobalClass.myword.ActiveDocument;
                    //doc.Content.Text = farsiNormalizer.Run(doc.Content.Text);


                    for (int i = 1; i < GlobalClass.mydoc.Words.Count ; i++)
                    {
                        var s = doc.Content.Words[i].Text.Trim();
                        var ss = stm.run(s);

                        bool b1 = _BcheakSpell.Cheak_Spell(s);
                        bool b2 = _BcheakSpell.isInIgnoreList(s);
                        bool b3 = _BcheakSpell.Cheak_Spell(ss);  //b3=b1

                        if (((b1 == false && b3 == false) && b2 == false) && (IgnoreAllSpell == false))
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
                    IgnoreAllSpell = false;

                }
            }
            catch (Exception ex)
            { }
        }


        private void Application_DocumentBeforeCloseEvent(Word.Document Doc, ref bool Cancel)
        {
            if (Cancel == false)
            {
                Console.WriteLine(string.Format("{0} Addin Document is closing.. {1}", "AppName", Doc.Name));
            }
        }

        private void Application_DocumentBeforePrintEvent(Word.Document Doc, ref bool Cancel)
        {
            if (Cancel == false)
            {
                Console.WriteLine(string.Format("{0} Addin Document {1} is printing", "AppName", Doc.Name));
            }
        }

        private void Application_DocumentOpenEvent(Word.Document doc)
        {
            Console.WriteLine(doc.FullName);
            GlobalClass.mydoc = doc;
        }

        private void Application_NewDocumentEvent(Word.Document doc)
        {
            Console.WriteLine(doc.FullName);
            GlobalClass.mydoc = doc;

            doc.ContentControlOnEnterEvent += Doc_ContentControlOnEnterEvent;
        }
        private void Doc_ContentControlOnEnterEvent(Word.ContentControl contentControl)
        {

        }

        private void Application_DocumentBeforeSaveEvent(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (Cancel == false)
            {
                Console.WriteLine(string.Format("{0} Addin Document {1} is saving", "AppName", Doc.Name));
            }
        }

        private void Addin_OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
		{

		}

        public void AboutButton_Click(Office.IRibbonControl control)
        {
            
            Utils.Dialog.ShowAbout("VirastarE", "https://github.com/ehsan2022002",
                "Attribution-NonCommercial-NoDerivatives 4.0 International (CC BY-NC-ND 4.0) " + Environment.NewLine +
                "Ehsan Bagheri 4/3/2020"
                );
        }

		//public bool TooglePaneVisibleButton_GetPressed(Office.IRibbonControl control)
		//{
		//	//return TaskPanes.Count > 0 ? TaskPanes[0].Visible : false;
		//}

		//public void TooglePaneVisibleButton_Click(Office.IRibbonControl control, bool pressed)
		//{
		//	//if(TaskPanes.Count > 0)
		//	//	TaskPanes[0].Visible = pressed;
		//}



		protected override void OnError(ErrorMethodKind methodKind, System.Exception exception)
		{
            Utils.Dialog.ShowError(exception, "An error occurend in " + methodKind.ToString());
		}

		[RegisterErrorHandler]
		public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, System.Exception exception)
		{
			Office.Tools.Contribution.DialogUtils.ShowRegisterError("VirastarE", methodKind, exception);
		}



        public void btnSpell_Click(Office.IRibbonControl control)
        {
            if (!m_oWorkerSpell.IsBusy)
                m_oWorkerSpell.RunWorkerAsync();
                        
        }

        public void btnPunctuation_Click(Office.IRibbonControl control)
        {
            if (!m_oWorkerPunch.IsBusy)
                m_oWorkerPunch.RunWorkerAsync();
            
        }

        public void btnNormalizaer_Click(Office.IRibbonControl control)
        {
            FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            var doc = GlobalClass.myword.ActiveDocument;
            
            if (doc.ActiveWindow.Selection.Text.Trim().Length > 0)
                doc.ActiveWindow.Selection.Text = farsiNormalizer.Run(doc.ActiveWindow.Selection.Text);
            else
                doc.Content.Text = farsiNormalizer.Run(doc.Content.Text);


        }

        public void btnSummerizer_Click(Office.IRibbonControl control)
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
        public void btnSetting_Click(Office.IRibbonControl control)
        {
            var frm = new Forms.frmSetting(_BcheakSpell);
            frm.Show();
            Application.StatusBar = "تنظیمات";
               
        }
        

    }
}

