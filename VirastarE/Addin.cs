namespace VirastarE
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using Balloon.NET;
    using BorzoyaSpell;
    using LDA;
    using NetOffice.OfficeApi;
    using NetOffice.OfficeApi.Tools;
    using NetOffice.Tools;
    using NetOffice.WordApi.Enums;
    using NetOffice.WordApi.Tools;
    using Word = NetOffice.WordApi;

    [COMAddin("VirastarE", "farsi spell checker", LoadBehavior.LoadAtStartup), ProgId("VirastarE.Addin"), Guid("51CFA53D-03D0-4192-8380-85A811807747"), Codebase]
    [RegistryLocation(RegistrySaveLocation.InstallScopeCurrentUser), CustomUI("RibbonUI.xml", true)]
    [MultiRegister(RegisterIn.Word, RegisterIn.Outlook)]
    public class Addin : Word.Tools.COMAddin
    {
        private static object locksyncPuncThread = new object();
        private static object locksyncSpellThread = new object();
        private Thread bgthread;
        private CheakSpell chkSpell;
        private CPPPunctuation cpuncForm;
        private CPPSPell cspellForm;
        private PunchPattern currentPuncPattern;
        private bool ignoreAllSpell = false;
        private bool isrunningPuncThread;
        private bool isrunningSpellThread;
        private List<PunchPattern> listpukPattern;
        private Util utilclass = new Util();
        private Thread puncthread;
        private Thread spellthread;

        public Addin()
        {
            this.OnStartupComplete += new OnStartupCompleteEventHandler(this.Addin_OnStartupComplete);
            this.OnDisconnection += new OnDisconnectionEventHandler(this.Addin_OnDisconnection);            
        }

        [RegisterErrorHandler]
        public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, System.Exception exception)
        {
            MessageBox.Show(methodKind.ToString() + " " + exception.Message);            
        }

        public void btnNormalizaer_Click(IRibbonControl control)
        {
            FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            var currentdoc = GlobalClass.myword.ActiveDocument;

            if (currentdoc.ActiveWindow.Selection.Text.Trim().Length > 1)
            {
                currentdoc.ActiveWindow.Selection.Text = farsiNormalizer.Run(currentdoc.ActiveWindow.Selection.Text);
            }
            else
            {
                currentdoc.Content.Text = farsiNormalizer.Run(currentdoc.Content.Text);
            }
        }
        
        public void btnPunctuation_Click(IRibbonControl control)
        {
            if (this.puncthread == null ||
                    (
                        this.puncthread.ThreadState != System.Threading.ThreadState.Running &&
                        this.puncthread.ThreadState != System.Threading.ThreadState.WaitSleepJoin
                    )
                )
            {
                lock (locksyncPuncThread)
                {
                    this.puncthread = new Thread(this.PunchDoWork);
                    this.puncthread.IsBackground = true;
                    this.puncthread.Start();
                }
            }
        }

        public void btnSetting_Click(IRibbonControl control)
        {
            var frmsetting = new Forms.frmSetting(this.chkSpell);
            frmsetting.Show();
            Application.StatusBar = Util.UtilMessagesEnum.ToolbarMessageSetting;
        }

        public void btnSLDA_Click(IRibbonControl control)
        {
            var frmlda = new frmLDA();
            frmlda.Show();
            Application.StatusBar = Util.UtilMessagesEnum.ToolbarMessageLDA;
        }

        public void btnSpell_Click(IRibbonControl control)
        {
            if (this.spellthread == null ||
                    (this.spellthread.ThreadState != System.Threading.ThreadState.Running &&
                    this.spellthread.ThreadState != System.Threading.ThreadState.WaitSleepJoin)
                )
            {
                lock (locksyncSpellThread)
                {
                    this.spellthread = new Thread(this.SpellDoWork);
                    this.spellthread.IsBackground = true;
                    this.spellthread.Start();
                }
            }
        }

        public void btnSummerizer_Click(IRibbonControl control)
        {
            string texttosend = string.Empty;
            var currntdoc = GlobalClass.myword.ActiveDocument;

            if (currntdoc.ActiveWindow.Selection.Text.Trim().Length > 0)
            {
                texttosend = currntdoc.ActiveWindow.Selection.Text;
            }
            else
            { 
                texttosend = currntdoc.Content.Text;
            }

            Form frmSummary = new TextSummarize.frmSummary(texttosend);
            frmSummary.Show();
        }

        public void ChkingTask()
        {
            while (true)
            {
                Thread.Sleep(8000);

                if (RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkRecSpell).Equals(Util.UtilSystemEnum.OnKey)
                    && (!this.isrunningSpellThread))
                {
                    this.btnSpell_Click(null);
                }

                Thread.Sleep(8000);

                if (RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkPunkRec).Equals(Util.UtilSystemEnum.OnKey)
                    && (!this.isrunningPuncThread))
                {
                    this.btnPunctuation_Click(null);
                }
            }
        }

        public void PunchDoWork()
        {
            this.Application.StatusBar = Util.UtilMessagesEnum.ChkPuncInProcess;
            this.CheakPunctuation(true);
            this.Application.StatusBar = Util.UtilMessagesEnum.ChkPuncProcessCompilite + this.utilclass.GetShamsiDateNow();
        }

        public void SpellDoWork()
        {
            this.Application.StatusBar = Util.UtilMessagesEnum.ChkSpellInProcess;
            this.CheakSpellDoc();
            this.Application.StatusBar = Util.UtilMessagesEnum.ChkSpellProcessCompilite + this.utilclass.GetShamsiDateNow();
        }

        protected override void OnError(ErrorMethodKind methodKind, System.Exception exception)
        {
            MessageBox.Show(methodKind.ToString() + " " + exception.Message);
        }

        private void Addin_OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            try
            {
                if (this.bgthread != null && this.bgthread.IsAlive)
                {
                    this.bgthread.Abort();
                }

                if (this.spellthread != null && this.spellthread.IsAlive)
                {
                    this.spellthread.Abort();
                }

                if (this.puncthread != null && this.puncthread.IsAlive)
                {
                    this.puncthread.Abort();
                }
            }
            catch
            {
            }
        }

        private void Addin_OnStartupComplete(ref Array custom)
        {
            try
            {
                // this.Application.WindowBeforeDoubleClickEvent += this.Application_WindowBeforeDoubleClickEvent;
                this.Application.NewDocumentEvent += this.Application_NewDocumentEvent;
                this.Application.DocumentOpenEvent += this.Application_DocumentOpenEvent;
                this.Application.WindowBeforeRightClickEvent += this.Application_WindowBeforeRightClickEvent;

                this.SetupSpell();
                this.SetupKeyBoardHooks();
                this.SetupBackgroundThread();

                try
                {  // welcome page not show
                    GlobalClass.myword = this.Application;
                    GlobalClass.mydoc = this.Application.ActiveDocument;
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void Application_DocumentOpenEvent(Word.Document doc)
        {            
            GlobalClass.mydoc = doc;
        }

        private void Application_NewDocumentEvent(Word.Document doc)
        {            
            GlobalClass.mydoc = doc;            
        }

        private void Application_WindowBeforeRightClickEvent(Word.Selection curselection, ref bool cancel)
        {
            GlobalClass.myselection = curselection;
            Word.Range wordrange = GlobalClass.myword.Selection.Range;

            int left, top, width, height;
            GlobalClass.myword.ActiveWindow.GetPoint(out left, out top, out width, out height, wordrange);

            var curword = curselection.Range.Words[1].Text;
            var curwordcount = curselection.Range.Words.Count;

            PunchPattern punckpattern = null;
            if (this.listpukPattern != null)
            {
                punckpattern = listpukPattern.Find(t => t.IndexStart <= curselection.Range.Start && t.IndexEnd >= curselection.Range.End);
            }

            if (punckpattern != null && punckpattern.ErrorCode > 0)
            {
                cancel = true;
                this.currentPuncPattern = punckpattern;
                this.cpuncForm = new CPPPunctuation();
                this.cpuncForm.Deactivate += this.CpPuncForm_Deactivate;
                this.cpuncForm.ShowBallonScreen(new Point(left, top));
                this.cpuncForm.ShowFormWithMessage = punckpattern.ErroMessage + Environment.NewLine + punckpattern.ErrorCorrection;
            }
            else
            {
                // else spell
                bool isspelliscorrect = chkSpell.Cheak_Spell(curword.Trim());

                if ((curword.Trim().Length > 1) && (curwordcount == 1) && (isspelliscorrect == false))
                {
                    cancel = true;
                    this.cspellForm = new CPPSPell();
                    this.cspellForm.Deactivate += cpSpellForm_Deactivate;
                    this.cspellForm.ShowBallonScreen(new Point(left, top));

                    var suggestlist = chkSpell.Suggest(curword);
                    this.cspellForm.ShowDlg(suggestlist);                    
                }
            }
        }

        private void CheakPunctuation(bool recheak)
        {
            if (GlobalClass.mydoc == null)
                return;

            isrunningPuncThread = true;
            try
            {
                // paragrapth
                Application.UndoRecord.StartCustomRecord(Util.UtilSystemEnum.StartCustomRecordPunc);

                string currenttext = GlobalClass.mydoc.Content.Text;
                if (currenttext.Trim().Length > 4)
                {
                    if (recheak == true)
                    {
                        listpukPattern = PunctuationCkeak.PunctuationChk(currenttext);
                    }

                    Word.Range curentrang = GlobalClass.mydoc.Range();

                    GlobalClass.mydoc.Range().Font.Underline = WdUnderline.wdUnderlineNone;
                    GlobalClass.mydoc.Range().Font.UnderlineColor = WdColor.wdColorWhite;

                    foreach (var punkpattern in listpukPattern)
                    {
                        if (punkpattern.ErrorCode > 0)
                        {
                            curentrang.Start = punkpattern.IndexStart;
                            curentrang.End = (punkpattern.IndexStart + punkpattern.IndexLenght);
                            curentrang.Font.Underline = WdUnderline.wdUnderlineWavy;
                            curentrang.Font.UnderlineColor = WdColor.wdColorLightBlue;
                        }
                    }
                } // if

                Application.UndoRecord.EndCustomRecord();
            }
            catch {
            }
            finally
            {
                this.isrunningPuncThread = false;
            }
        }

        private void CheakSpellDoc()
        {
            // FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            this.isrunningSpellThread = true;

            try
            {
                if (GlobalClass.myword.ActiveDocument != null)
                {
                    var currentdoc = GlobalClass.myword.ActiveDocument;
                    
                    Application.UndoRecord.StartCustomRecord(Util.UtilSystemEnum.StartCustomRecordSpell);
                    for (int i = 1; i < GlobalClass.mydoc.Words.Count; i++)
                    {
                        var currenttext = currentdoc.Content.Words[i].Text.Trim();                        
                        bool isspelliscorrect = chkSpell.Cheak_Spell(currenttext);
                        bool isinignorelist = chkSpell.isInIgnoreList(currenttext);
                        
                        if (((isspelliscorrect == false) && isinignorelist == false))
                        {
                            currentdoc.Content.Words[i].Underline = WdUnderline.wdUnderlineWavy;
                            currentdoc.Content.Words[i].Font.UnderlineColor = WdColor.wdColorRed;
                        }
                        else
                        {
                            currentdoc.Content.Words[i].Underline = WdUnderline.wdUnderlineNone;
                            currentdoc.Content.Words[i].Font.UnderlineColor = WdColor.wdColorWhite;
                        }
                    }

                    Application.UndoRecord.EndCustomRecord();                    
                }
            }
            catch
            { 
            }
            finally
            {
                isrunningSpellThread = false;
            }
        }

        private void CpPuncForm_Deactivate(object sender, EventArgs e)
        {
            listpukPattern.Remove(currentPuncPattern);
            CheakPunctuation(false);
        }

        private void cpSpellForm_Deactivate(object sender, EventArgs e)
        {
            // read selected value from baloon form
            bool isWordingored = this.cspellForm.IsIgnored;
            bool isWordAdd = this.cspellForm.IsAdd;
            bool isWordSelect = this.cspellForm.IsSelect;
            string selectedWord = this.cspellForm.SelectedWord;
            ignoreAllSpell = this.cspellForm.IsIgnoreAll;

            if (isWordSelect)
            {
                chkSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);

                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Text = selectedWord + " ";
            }

            if (isWordingored || ignoreAllSpell)
            {
                chkSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (isWordAdd)
            {
                chkSpell.AddtoUserDic(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (ignoreAllSpell)
            {
                btnSpell_Click(null);
            }
        }

        private void SetupBackgroundThread()
        {
            this.bgthread = new Thread(this.ChkingTask);
            this.bgthread.IsBackground = true;
            this.bgthread.SetApartmentState(System.Threading.ApartmentState.STA);
            this.bgthread.Priority = ThreadPriority.Lowest;
            this.bgthread.Start();
        }

        private void SetupKeyBoardHooks()
        {
            ShortcutManager.Start();
            ShortcutManager.KeyDown += ShortcutManager_KeyDown;
        }

        private void SetupSpell()
        {
            Application.Options.AutoFormatReplaceQuotes = false;
            Application.Options.AutoFormatAsYouTypeReplaceQuotes = false;

            this.chkSpell = new CheakSpell();
            this.chkSpell.IgnoreEnglish = RegistaryApplicationSetting.GetRegistaryKey("chkIgnoreEnglish") == "1" ? true : false;
            this.chkSpell.SpellLavel = 1; // int.Parse(RegistaryApplicationSetting.GetRegistaryKey("trackBar1") == "" ? "1" : RegistaryApplicationSetting.GetRegistaryKey("trackBar1"));
            this.chkSpell.CheakSteem = RegistaryApplicationSetting.GetRegistaryKey("chkStemSpell") == "1" ? true : false;
            this.chkSpell.IgnoreChars = RegistaryApplicationSetting.GetRegistaryKey("txtIgnoreList");
        }

        private void ShortcutManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                this.btnSpell_Click(null);
            }

            if (e.KeyCode == Keys.F9)
            {
                this.btnNormalizaer_Click(null);
            }
        }
    }
}