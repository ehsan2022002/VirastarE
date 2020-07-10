using LanguageDetection;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TextRank;

namespace TextSummarize
{
    public partial class frmSummary : Form
    {
        public string sentance = "";
        BackgroundWorker m_oWorker;
        string strSummary;
        string strKeywords;
        string lang;

        public frmSummary(string s)
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            this.sentance = Regex.Replace(s, "<.*?>|&.*?;", string.Empty);


            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;

            setLangusateDetect();
        }

        private void setLangusateDetect()
        {
            if (this.sentance.Trim().Length < 10)
                 return; 

            try
            {
                cmbLang.Items.Clear();
                cmbLang.Items.AddRange(FindLanguage.GetTraindLanguage().ToArray());

                var Dlang = FindLanguage.Detect(this.sentance);
                cmbLang.Text = Dlang;
            }
            catch (Exception ex)
            { }

        }

        private void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.Text = "لغو عملیات";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                lblStatus.Text = "خطا در انجام عملیات";
            }
            else
            {
                
                lblStatus.Text = "خلاصه سازی ماشینی انجام شد";

                txtSummary.Text = strSummary;
                txtKeywords.Text = strKeywords;
            }
            
            
            //Change the status of the buttons on the UI accordingly
            btnStartAsyncOperation.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
                         
            lblStatus.Text = "پردازش در حال انجام است زمان بسته به مقدار متن دارد..." ;
        }

        private void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            
            m_oWorker.ReportProgress(10);
            try
            {
                var extractKeyPhrases = new ExtractKeyPhrases();

                var x = extractKeyPhrases.Extract(sentance, lang);

                m_oWorker.ReportProgress(90);
                

                strSummary = x.Item1.ToString();
                strKeywords = string.Join(",", x.Item2.ToArray());
            }
            catch (Exception ex)
            {
               /// MessageBox.Show(ex.Message + ex.InnerException.Message);
            }

            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);

        }




       
        private void BtnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            lang = cmbLang.Text;
            if (this.sentance.Trim().Length > 5000)
            {
                lblStatus.Text = "اندازه متن بیشتر از حد مجاز است";
                return;
            }

            if (this.sentance.Trim().Length < 50)
            {
                lblStatus.Text = "اندازه متن کمتر از حد مجاز است";
                return;
            }

            btnStartAsyncOperation.Enabled = false;
            btnCancel.Enabled = true;

            // Kickoff the worker thread to begin it's DoWork function.
            m_oWorker.RunWorkerAsync();
            m_oWorker.RunWorkerCompleted += M_oWorker_RunWorkerCompleted;
        }

        private void M_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {

                // Notify the worker thread that a cancel has been requested.

                // The cancel will not actually happen until the thread in the

                // DoWork checks the m_oWorker.CancellationPending flag. 

                m_oWorker.CancelAsync();
            }
        }
    }
}
