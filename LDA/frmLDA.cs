using System;
using System.IO;
using System.Windows.Forms;

namespace LDA
{
    public partial class frmLDA : Form
    {
        private readonly string Dirloc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                         @"\VirastarE";

        public frmLDA()
        {
            InitializeComponent();

            try
            {
                if (!Directory.Exists(Dirloc))
                    Directory.CreateDirectory(Dirloc);

                txtinput.Text = Dirloc;
                txtoutput.Text = Dirloc;
            }
            catch
            {
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var opt = GetDefaultOption();
            //Parser parser = new Parser();
            //var stopwatch = new Stopwatch();
            if (txtinput.Text.Trim().Length == 0 || Path.GetExtension(txtinput.Text).ToLower() != ".txt")
                return;

            try
            {
                //parser.ParseArguments(args, opt);
                var model = new LDAGibbsSampling();


                model.OnIterate += LDAProcessEvent;
                progressBar1.Maximum = opt.Niters;
                progressBar1.Value = 1;
                progressBar1.Visible = true;


                var cor = new Corpora();
                cor.LoadDataFile(opt.Input);
                model.TrainNewModel(cor, opt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
        }

        private void LDAProcessEvent(object source, LDAProcessEventArgs e)
        {
            Console.WriteLine(e.GetInfo());
            progressBar1.Value = int.Parse(e.GetInfo());

            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Visible = false;
        }


        private CommandLineOption GetDefaultOption()
        {
            var option = new CommandLineOption();


            option.Alpha = double.Parse(txtalpha.Text);
            option.Beta = double.Parse(txtbeta.Text);
            option.Topics = int.Parse(txttopics.Text);
            option.Savestep = int.Parse(txtsavestep.Text);
            option.Niters = int.Parse(txtniters.Text);
            option.Twords = int.Parse(txttwords.Text);

            option.Input = txtinput.Text;
            option.Outputfile = txtoutput.Text + @"\out.txt";

            return option;
        }

        private void btnInFiel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = Dirloc;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtinput.Text = openFileDialog1.FileName;
        }

        private void btnOutDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Dirloc;
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtoutput.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}