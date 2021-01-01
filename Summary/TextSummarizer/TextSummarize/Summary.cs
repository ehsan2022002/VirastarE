using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LanguageDetection;
using TextRank;

namespace TextSummarize
{
    public partial class Summary : Form
    {
        private readonly BackgroundWorker _mOWorker;
        private string _lang;
        public string Sentance = string.Empty;
        private string _stringKeywords;
        private string _stringSummary;

        public Summary(string s)
        {
            InitializeComponent();
            _mOWorker = new BackgroundWorker();
            Sentance = Regex.Replace(s, "<.*?>|&.*?;", string.Empty);


            _mOWorker.DoWork += m_oWorker_DoWork;
            _mOWorker.ProgressChanged += m_oWorker_ProgressChanged;
            _mOWorker.RunWorkerCompleted += m_oWorker_RunWorkerCompleted;
            _mOWorker.WorkerReportsProgress = true;
            _mOWorker.WorkerSupportsCancellation = true;

            SetLangusateDetect();
        }

        private void SetLangusateDetect()
        {
            if (Sentance.Trim().Length < 10)
                return;

            try
            {
                cmbLang.Items.Clear();
                cmbLang.Items.AddRange(FindLanguage.GetTraindLanguage().ToArray());

                var dlang = FindLanguage.Detect(Sentance);
                cmbLang.Text = dlang;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.Text = @"لغو عملیات";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                lblStatus.Text = @"خطا در انجام عملیات";
            }
            else
            {
                lblStatus.Text = @"خلاصه سازی ماشینی انجام شد";

                txtSummary.Text = _stringSummary;
                txtKeywords.Text = _stringKeywords;
            }


            //Change the status of the buttons on the UI accordingly
            btnStartAsyncOperation.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = @"پردازش در حال انجام است زمان بسته به مقدار متن دارد...";
        }

        private void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _mOWorker.ReportProgress(10);
            try
            {
                var extractKeyPhrases = new ExtractKeyPhrases();

                var x = extractKeyPhrases.Extract(Sentance, _lang);

                _mOWorker.ReportProgress(90);


                _stringSummary = x.Item1;
                _stringKeywords = string.Join(",", x.Item2.ToArray());
            }
            catch (Exception)
            {
                // ignored
            }

            //Report 100% completion on operation completed
            _mOWorker.ReportProgress(100);
        }


        private void BtnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            _lang = cmbLang.Text;
            if (ValidateSizeIsOver()) return;

            btnStartAsyncOperation.Enabled = false;
            btnCancel.Enabled = true;

            // Kickoff the worker thread to begin it's DoWork function.
            _mOWorker.RunWorkerAsync();
            _mOWorker.RunWorkerCompleted += M_oWorker_RunWorkerCompleted;
        }

        private bool ValidateSizeIsOver()
        {
            if (Sentance.Trim().Length > 5000)
            {
                lblStatus.Text = @"اندازه متن بیشتر از حد مجاز است";
                return true;
            }

            if (Sentance.Trim().Length < 50)
            {
                lblStatus.Text = @"اندازه متن کمتر از حد مجاز است";
                return true;
            }

            return false;
        }

        private void M_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_mOWorker.IsBusy)
                // Notify the worker thread that a cancel has been requested.

                // The cancel will not actually happen until the thread in the

                // DoWork checks the _mOWorker.CancellationPending flag. 

                _mOWorker.CancelAsync();
        }
    }
}