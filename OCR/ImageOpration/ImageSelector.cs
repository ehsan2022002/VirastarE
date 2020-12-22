using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace ImageOpration
{
    public partial class ImageSelector : Form
    {
        private readonly ImageHandler imageHandler = new ImageHandler();

        //private float x1, y1, x2, y2 = 0;
        //private double zoomFactor = 1;

        public ImageSelector()
        {
            InitializeComponent();
            pictureBoxProcess.Visible = false;
        }

        private void btnOCR_Click(object sender, EventArgs e)
        {
            pictureBoxProcess.Visible = true;
            btnOCR.Text = @"در حال انجام";
            btnOCR.Enabled = false;
            btnOpenFile.Enabled = false;
            var currentImage = FilePathLable.Text;

            Task task = Task.Run(() => ProcessOcr(currentImage));
            task.GetAwaiter().OnCompleted(this.Close);
           
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            imageHandler.RestorePrevious();
            imageHandler.SetInvert();

            PictureboxCurrent.Image = imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
        }

        private void ProcessOcr(string currentImage)
        {
            try
            {
                var datapath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\\tessdata";

                using (var engine = new TesseractEngine(datapath, "fas+eng", EngineMode.Default))
                {
                    
                    // @"C:\\Users\\Ehsan\\Documents\\Visual Studio 2019\\OCR\\tesseract-master\\tesseract-master\\src\\Tesseract.Tests\\Data\\Ocr\\phototes3.tif";
                    using (var img = Pix.LoadFromFile(currentImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Results.OcrResult = text;
                            Results.AutoCorrect = chkSpell.Checked;
                            
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnRotate90_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate90FlipNone);

            PictureboxCurrent.Image = imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
        }

        private void btnRotate180_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate180FlipNone);

            PictureboxCurrent.Image = imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
        }

        private void chkSpell_CheckedChanged(object sender, EventArgs e)
        {
            Results.AutoCorrect = chkSpell.Checked;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var openfiledialog = new OpenFileDialog();
            openfiledialog.Multiselect = false;
            openfiledialog.Filter = @"Image files|*.jpg;*.tif|All files|*.*";
            try
            {
                var resulte = openfiledialog.ShowDialog();

                if (resulte == DialogResult.OK)
                {
                    FilePathLable.Text = openfiledialog.FileName;
                    imageHandler.CurrentBitmap = (Bitmap) Image.FromFile(openfiledialog.FileName);
                    imageHandler.BitmapPath = openfiledialog.FileName;

                    PictureboxCurrent.Image = imageHandler.CurrentBitmap;
                    PictureboxCurrent.Refresh();

                    trackBarZoom.Value = 100;
                    trackBarZoom_Scroll(null, null);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            PictureboxCurrent.Zoom = trackBarZoom.Value * 0.02f;
        }

        private void btnGrayscal_Click(object sender, EventArgs e)
        {
            imageHandler.RestorePrevious();
            imageHandler.SetGrayscale();

            PictureboxCurrent.Image = imageHandler.CurrentBitmap;
            PictureboxCurrent.Refresh();
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