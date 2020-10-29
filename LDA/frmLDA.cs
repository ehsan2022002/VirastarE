using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDA
{
    public partial class frmLDA : Form
    {

        string Dirloc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VirastarE";
        public frmLDA()
        {
            InitializeComponent();

            try
            {
                if (!System.IO.Directory.Exists(Dirloc))
                    System.IO.Directory.CreateDirectory(Dirloc);

                txtinput.Text = Dirloc;
                txtoutput.Text = Dirloc;
            }
            catch
            {
                // ignored
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            CommandLineOption opt = GetDefaultOption();
            //Parser parser = new Parser();
            //var stopwatch = new Stopwatch();
            if (this.txtinput.Text.Trim().Length == 0 || Path.GetExtension(this.txtinput.Text).ToLower() != ".txt")
                return;

            try
            {
                //parser.ParseArguments(args, opt);
                LdaGibbsSampling model = new LdaGibbsSampling();


                model.OnIterate += new ProgressEventHandler(LdaProcessEvent);
                progressBar1.Maximum = opt.niters;
                progressBar1.Value = 1;
                progressBar1.Visible = true;


                Corpora cor = new Corpora();
                cor.LoadDataFile(opt.input);
                model.TrainNewModel(cor, opt);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);

            }
        }

        private void LdaProcessEvent(object source, LdaProcessEventArgs e)
        {
            Console.WriteLine(e.GetInfo());
            progressBar1.Value = int.Parse(e.GetInfo());

            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Visible = false;
        }


        private CommandLineOption GetDefaultOption()
        {
            CommandLineOption option = new CommandLineOption();


            option.alpha = double.Parse(txtalpha.Text);
            option.beta = double.Parse(txtbeta.Text);
            option.topics = int.Parse(txttopics.Text);
            option.savestep = int.Parse(txtsavestep.Text);
            option.niters = int.Parse(txtniters.Text);
            option.twords = int.Parse(txttwords.Text);

            option.input = txtinput.Text ;
            option.outputfile = txtoutput.Text + @"\out.txt";

            return option;

        }

        private void btnInFiel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = Dirloc;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtinput.Text = openFileDialog1.FileName;
        }

        private void btnOutDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Dirloc;
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtoutput.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
