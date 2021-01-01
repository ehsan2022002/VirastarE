using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorzoyaSpell;
using Tesseract;

namespace ImageOpration
{
    public partial class ImageSelector : Form
    {
        private readonly ImageHandler _imageHandler = new ImageHandler();

        private readonly CheakSpell _checkSpell;

        //private float x1, y1, x2, y2 = 0;
        //private double zoomFactor = 1;

        public ImageSelector(CheakSpell checkSpell)
        {
            InitializeComponent();
            pictureBoxProcess.Visible = false;
            listBoxFiles.Items.Clear();

            _checkSpell = checkSpell;
        }

        private void btnOCR_Click(object sender, EventArgs e)
        {
            pictureBoxProcess.Visible = true;
            btnOCR.Text = @"در حال انجام";
            btnOCR.Enabled = false;
            btnOpenFile.Enabled = false;
            chkSpell.Enabled = false;

            var currentImages = new List<string>();

            if (listBoxFiles.SelectedItems.Count == 0)
                for (var i = 0; i < listBoxFiles.Items.Count; i++)
                    listBoxFiles.SetSelected(i, true);

            foreach (var item in listBoxFiles.SelectedItems) currentImages.Add(item.ToString());

            var task = Task.Run(() => ProcessOcr(currentImages));

            task.GetAwaiter().OnCompleted(Close);
        }


        private void ProcessOcr(List<string> currentImages)
        {
            try
            {
                var datapath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\\tessdata";

                Results.AutoCorrect = chkSpell.Checked;

                using (var engine = new TesseractEngine(datapath, "fas+eng", EngineMode.Default))
                {
                    foreach (var image in currentImages)
                        using (var img = Pix.LoadFromFile(image))
                        {
                            using (var page = engine.Process(img))
                            {
                                var text = page.GetText();
                                Results.OcrResult += Environment.NewLine + text;
                            }
                        }
                } // engine

                var correctedSentance = string.Empty;
                if (Results.OcrResult.Trim().Length != 0)
                {
                    //Application.StatusBar = Util.UtilMessagesEnum.Processing;
                    if (Results.AutoCorrect)
                    {
                        //Results.OcrResult =Regex.Replace(Results.OcrResult, @"\r\n?|\n", " ");
                        var words = Results.OcrResult.Split(' ');

                        foreach (var word in words)
                            if (_checkSpell.Cheak_Spell(word.Trim()) == false)
                                correctedSentance += " " + _checkSpell.SuggestOne(word.Trim());
                            else
                                correctedSentance += " " + word;
                    }
                    else
                    {
                        correctedSentance = Results.OcrResult.Trim();
                    }

                    Results.OcrResult = correctedSentance;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }


        private void chkSpell_CheckedChanged(object sender, EventArgs e)
        {
            Results.AutoCorrect = chkSpell.Checked;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var openfiledialog = new OpenFileDialog();
            openfiledialog.Multiselect = true;
            openfiledialog.Filter = @"Image files|*.jpg;*.tif|All files|*.*";
            try
            {
                var resulte = openfiledialog.ShowDialog();

                if (resulte == DialogResult.OK)
                {
                    var filesNames = openfiledialog.FileNames.ToList();

                    if (filesNames.Count == 0)
                        return;

                    //listBoxFiles.Items.Clear();
                    foreach (var file in filesNames) listBoxFiles.Items.Add(file);

                    _imageHandler.CurrentBitmap = (Bitmap) Image.FromFile(filesNames.FirstOrDefault() ?? string.Empty);
                    _imageHandler.BitmapPath = filesNames.FirstOrDefault();

                    PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
                    PictureboxCurrent.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Rotate90StripButton_Click(object sender, EventArgs e)
        {
            _imageHandler.RotateFlip(RotateFlipType.Rotate90FlipNone);

            PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
        }

        private void Rotate180StripButton_Click(object sender, EventArgs e)
        {
            _imageHandler.RotateFlip(RotateFlipType.Rotate180FlipNone);

            PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
        }

        private void ZoomInToolStripButton_Click(object sender, EventArgs e)
        {
            PictureboxCurrent.Zoom += PictureboxCurrent.Zoom * 0.02f;
        }

        private void ZoomOutToolStripButton_Click(object sender, EventArgs e)
        {
            PictureboxCurrent.Zoom -= PictureboxCurrent.Zoom * 0.02f;
        }

        private void BlackandWhiteStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _imageHandler.RestorePrevious();
                _imageHandler.SetGrayscale();

                PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
                PictureboxCurrent.Refresh();
            }
            catch (Exception exception)
            {
                //ignore
            }
        }

        private void InvertStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _imageHandler.RestorePrevious();
                _imageHandler.SetInvert();

                PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
                PictureboxCurrent.Refresh();
            }
            catch (Exception exception)
            {
                //ignore
            }
        }

        private void listBoxFiles_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem != null)
            {
                var image = listBoxFiles.SelectedItem.ToString();

                _imageHandler.CurrentBitmap = (Bitmap) Image.FromFile(image);
                _imageHandler.BitmapPath = image;

                PictureboxCurrent.Image = _imageHandler.CurrentBitmap;
                PictureboxCurrent.Refresh();
            }
        }
    }


    //public void Initialise_ShouldStartEngineFARSI(
    //    [ValueSource("DataPaths")] string datapath)
    //{
    //    using (var engine = new TesseractEngine(datapath, "fas", EngineMode.Default))
    //    {
    //        string TestImage =
    //            @"C:\\Users\\Ehsan\\Documents\\Visual Studio 2019\\OCR\\tesseract-master\\tesseract-master\\src\\Tesseract.Tests\\Data\\Ocr\\phototes3.tif";
    //        using (var img = LoadTestPix(TestImage))
    //        {
    //            using (var page = engine.Process(img))
    //            {
    //                var text = page.GetText();

    //            }
    //        }
    //    }
    //}
}