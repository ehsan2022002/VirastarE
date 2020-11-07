using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using TextSummarize;
using VirastarE.Forms;
using COMAddin = NetOffice.WordApi.Tools.COMAddin;

namespace VirastarE
{
    using Word = NetOffice.WordApi;

    [COMAddin("VirastarE", "farsi spell checker", LoadBehavior.LoadAtStartup)]
    [ProgId("VirastarE.Addin")]
    [Guid("51CFA53D-03D0-4192-8380-85A811807747")]
    [Codebase]
    [RegistryLocation(RegistrySaveLocation.InstallScopeCurrentUser)]
    [CustomUI("RibbonUI.xml", true)]
    [MultiRegister(RegisterIn.Word, RegisterIn.Outlook)]
    public class Addin : COMAddin
    {
        private static object locksyncPuncThread = new object();
        private static object locksyncSpellThread = new object();
        private Thread _bgthread;
        private CheakSpell _chkSpell;
        private CPPPunctuation _cpuncForm;
        private CPPSPell _cspellForm;
        private PunchPattern _currentPuncPattern;
        private bool _ignoreAllSpell;
        private bool _isrunningPuncThread;
        private bool _isrunningSpellThread;
        private List<PunchPattern> _listpukPattern;
        private Thread _puncthread;
        private Thread _spellthread;
        private readonly Util _utilclass = new Util();

        public Addin()
        {
            OnStartupComplete += Addin_OnStartupComplete;
            OnDisconnection += Addin_OnDisconnection;
        }

        [RegisterErrorHandler]
        public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, Exception exception)
        {
            MessageBox.Show(methodKind + Environment.NewLine + exception.Message);
        }

        public void btnNormalizaer_Click(IRibbonControl control)
        {
            var farsiNormalizer = new FarsiNormalizer();
            var currentdoc = GlobalClass.myword.ActiveDocument;

            if (currentdoc.ActiveWindow.Selection.Text.Trim().Length > 1)
                currentdoc.ActiveWindow.Selection.Text = farsiNormalizer.Run(currentdoc.ActiveWindow.Selection.Text);
            else
                currentdoc.Content.Text = farsiNormalizer.Run(currentdoc.Content.Text);
        }

        public void btnPunctuation_Click(IRibbonControl control)
        {
            if (_puncthread == null ||
                _puncthread.ThreadState != ThreadState.Running &&
                _puncthread.ThreadState != ThreadState.WaitSleepJoin
            )
                lock (locksyncPuncThread)
                {
                    _puncthread = new Thread(PunchDoWork) {IsBackground = true};
                    _puncthread.Start();
                }
        }

        public void btnSetting_Click(IRibbonControl control)
        {
            var frmsetting = new Setting(_chkSpell);
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
            if (_spellthread == null ||
                _spellthread.ThreadState != ThreadState.Running &&
                _spellthread.ThreadState != ThreadState.WaitSleepJoin
            )
                lock (locksyncSpellThread)
                {
                    _spellthread = new Thread(SpellDoWork) {IsBackground = true};
                    _spellthread.Start();
                }
        }

        public void btnSummerizer_Click(IRibbonControl control)
        {
            var textToSend = string.Empty;
            var currntDoc = GlobalClass.myword.ActiveDocument;

            textToSend = currntDoc.ActiveWindow.Selection.Text.Trim().Length > 0 ? currntDoc.ActiveWindow.Selection.Text : currntDoc.Content.Text;

            Form frmSummary = new frmSummary(textToSend);
            frmSummary.Show();
        }

        public void ChkingTask()
        {
            while (true)
            {
                Thread.Sleep(8000);

                if (RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkRecSpell)
                        .Equals(Util.UtilSystemEnum.OnKey)
                    && !_isrunningSpellThread)
                    btnSpell_Click(null);

                Thread.Sleep(8000);

                if (RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkPunkRec)
                        .Equals(Util.UtilSystemEnum.OnKey)
                    && !_isrunningPuncThread)
                    btnPunctuation_Click(null);
            }
        }

        private void PunchDoWork()
        {
            Application.StatusBar = Util.UtilMessagesEnum.ChkPuncInProcess;
            CheakPunctuation(true);
            Application.StatusBar = Util.UtilMessagesEnum.ChkPuncProcessCompilite + _utilclass.GetShamsiDateNow();
        }

        private void SpellDoWork()
        {
            Application.StatusBar = Util.UtilMessagesEnum.ChkSpellInProcess;
            CheakSpellDoc();
            Application.StatusBar = Util.UtilMessagesEnum.ChkSpellProcessCompilite + _utilclass.GetShamsiDateNow();
        }

        protected override void OnError(ErrorMethodKind methodKind, Exception exception)
        {
            MessageBox.Show(methodKind + Environment.NewLine + exception.Message);
        }

        private void Addin_OnDisconnection(ext_DisconnectMode removeMode, ref Array custom)
        {
            try
            {
                if (_bgthread != null && _bgthread.IsAlive) _bgthread.Abort();

                if (_spellthread != null && _spellthread.IsAlive) _spellthread.Abort();

                if (_puncthread != null && _puncthread.IsAlive) _puncthread.Abort();
            }
            catch
            {
                // ignored
            }
        }

        private void Addin_OnStartupComplete(ref Array custom)
        {
            try
            {
                // this.Application.WindowBeforeDoubleClickEvent += this.Application_WindowBeforeDoubleClickEvent;
                Application.NewDocumentEvent += Application_NewDocumentEvent;
                Application.DocumentOpenEvent += Application_DocumentOpenEvent;
                Application.WindowBeforeRightClickEvent += Application_WindowBeforeRightClickEvent;

                SetupSpell();
                SetupKeyBoardHooks();
                SetupBackgroundThread();


                try
                {
                    NagScreen nagScreen = new NagScreen();
                    nagScreen.StartPosition= FormStartPosition.Manual;

                    var mySecondScreen = Screen.AllScreens.FirstOrDefault();

                    if (mySecondScreen != null)
                    {
                        nagScreen.Left = mySecondScreen.Bounds.Right - nagScreen.Width -10;
                        nagScreen.Top = mySecondScreen.Bounds.Bottom - nagScreen.Width - 10;
                    }

                    nagScreen.Show();

                    // welcome page not show
                    GlobalClass.myword = Application;
                    GlobalClass.mydoc = Application.ActiveDocument;
                }
                catch (Exception)
                {
                    // ignored
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
            var wordrange = GlobalClass.myword.Selection.Range;

            int left, top, width, height;
            GlobalClass.myword.ActiveWindow.GetPoint(out left, out top, out width, out height, wordrange);

            var curword = curselection.Range.Words[1].Text;
            var curwordcount = curselection.Range.Words.Count;

            PunchPattern punckPattern = null;
            if (_listpukPattern != null)
                punckPattern = _listpukPattern.Find(t =>
                    t.IndexStart <= curselection.Range.Start && t.IndexEnd >= curselection.Range.End);

            if (punckPattern != null && punckPattern.ErrorCode > 0)
            {
                cancel = true;
                _currentPuncPattern = punckPattern;
                _cpuncForm = new CPPPunctuation();
                _cpuncForm.Deactivate += CpPuncForm_Deactivate;
                _cpuncForm.ShowBallonScreen(new Point(left, top));
                _cpuncForm.ShowFormWithMessage =
                    punckPattern.ErroMessage + Environment.NewLine + punckPattern.ErrorCorrection;
            }
            else
            {
                // else spell
                var isSpellisCorrect = _chkSpell.Cheak_Spell(curword.Trim());

                if (curword.Trim().Length > 1 && curwordcount == 1 && isSpellisCorrect == false)
                {
                    cancel = true;
                    _cspellForm = new CPPSPell();
                    _cspellForm.Deactivate += cpSpellForm_Deactivate;
                    _cspellForm.ShowBallonScreen(new Point(left, top));

                    var suggestList = _chkSpell.Suggest(curword);
                    _cspellForm.ShowDlg(suggestList);
                }
            }
        }

        private void CheakPunctuation(bool recheak)
        {
            if (GlobalClass.mydoc == null)
                return;

            _isrunningPuncThread = true;
            try
            {
                // paragrapth
                Application.UndoRecord.StartCustomRecord(Util.UtilSystemEnum.StartCustomRecordPunc);

                var currenttext = GlobalClass.mydoc.Content.Text;
                if (currenttext.Trim().Length > 4)
                {
                    if (recheak) _listpukPattern = PunctuationCkeak.PunctuationChk(currenttext);

                    var curentrang = GlobalClass.mydoc.Range();

                    GlobalClass.mydoc.Range().Font.Underline = WdUnderline.wdUnderlineNone;
                    GlobalClass.mydoc.Range().Font.UnderlineColor = WdColor.wdColorWhite;

                    foreach (var punkpattern in _listpukPattern)
                        if (punkpattern.ErrorCode > 0)
                        {
                            curentrang.Start = punkpattern.IndexStart;
                            curentrang.End = punkpattern.IndexStart + punkpattern.IndexLenght;
                            curentrang.Font.Underline = WdUnderline.wdUnderlineWavy;
                            curentrang.Font.UnderlineColor = WdColor.wdColorLightBlue;
                        }
                } // if

                Application.UndoRecord.EndCustomRecord();
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _isrunningPuncThread = false;
            }
        }

        private void CheakSpellDoc()
        {
            // FarsiNormalizer farsiNormalizer = new FarsiNormalizer();
            _isrunningSpellThread = true;

            try
            {
                if (GlobalClass.myword.ActiveDocument != null)
                {
                    var currentdoc = GlobalClass.myword.ActiveDocument;

                    Application.UndoRecord.StartCustomRecord(Util.UtilSystemEnum.StartCustomRecordSpell);
                    for (var i = 1; i < GlobalClass.mydoc.Words.Count; i++)
                    {
                        var currenttext = currentdoc.Content.Words[i].Text.Trim();
                        var isspelliscorrect = _chkSpell.Cheak_Spell(currenttext);
                        var isinignorelist = _chkSpell.IsInIgnoreList(currenttext);

                        if (isspelliscorrect == false && isinignorelist == false)
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
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                _isrunningSpellThread = false;
            }
        }

        private void CpPuncForm_Deactivate(object sender, EventArgs e)
        {
            _listpukPattern.Remove(_currentPuncPattern);
            CheakPunctuation(false);
        }

        private void cpSpellForm_Deactivate(object sender, EventArgs e)
        {
            // read selected value from baloon form
            var isWordingored = _cspellForm.IsIgnored;
            var isWordAdd = _cspellForm.IsAdd;
            var isWordSelect = _cspellForm.IsSelect;
            var selectedWord = _cspellForm.SelectedWord;
            _ignoreAllSpell = _cspellForm.IsIgnoreAll;

            if (isWordSelect)
            {
                _chkSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);

                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Text = selectedWord + " ";
            }

            if (isWordingored || _ignoreAllSpell)
            {
                _chkSpell.AddToIgnoreList(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (isWordAdd)
            {
                _chkSpell.AddtoUserDic(GlobalClass.myselection.Range.Words[1].Text);
                GlobalClass.myselection.Range.Words[1].Font.UnderlineColor = WdColor.wdColorWhite;
                GlobalClass.myselection.Range.Words[1].Underline = WdUnderline.wdUnderlineNone;
            }

            if (_ignoreAllSpell) btnSpell_Click(null);
        }

        private void SetupBackgroundThread()
        {
            _bgthread = new Thread(ChkingTask) {IsBackground = true};
            _bgthread.SetApartmentState(ApartmentState.STA);
            _bgthread.Priority = ThreadPriority.Lowest;
            _bgthread.Start();
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

            _chkSpell = new CheakSpell
            {
                IgnoreEnglish = RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkIgnoreEnglish) ==
                                Util.UtilSystemEnum.OnKey
                    ? true
                    : false,
                CheakSteem = RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.chkStemSpell) ==
                             Util.UtilSystemEnum.OnKey
                    ? true
                    : false,
                IgnoreChars = RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.txtIgnoreList)
            };
        }

        private void ShortcutManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11) btnSpell_Click(null);

            if (e.KeyCode == Keys.F9) btnNormalizaer_Click(null);
        }
    }
}