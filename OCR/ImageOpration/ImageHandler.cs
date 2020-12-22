using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ImageOpration
{
    public class ImageHandler
    {
        public enum ColorFilterTypes
        {
            Red,
            Green,
            Blue
        }

        private Bitmap _bitmapPrevCropArea;
        private Bitmap _currentBitmap;

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set => _currentBitmap = value;
        }

        public Bitmap BitmapBeforeProcessing { get; set; }

        public string BitmapPath { get; set; }

        public void ResetBitmap()
        {
            if (_currentBitmap != null && BitmapBeforeProcessing != null)
            {
                var temp = (Bitmap) _currentBitmap.Clone();
                _currentBitmap = (Bitmap) BitmapBeforeProcessing.Clone();
                BitmapBeforeProcessing = (Bitmap) temp.Clone();
            }
        }

        public void SaveBitmap(string saveFilePath)
        {
            BitmapPath = saveFilePath;
            if (File.Exists(saveFilePath))
                File.Delete(saveFilePath);
            _currentBitmap.Save(saveFilePath);
        }

        public void ClearImage()
        {
            _currentBitmap = new Bitmap(1, 1);
        }

        public void RestorePrevious()
        {
            BitmapBeforeProcessing = _currentBitmap;
        }

        public void SetColorFilter(ColorFilterTypes colorFilterType)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var nPixelR = 0;
                var nPixelG = 0;
                var nPixelB = 0;
                if (colorFilterType == ColorFilterTypes.Red)
                {
                    nPixelR = c.R;
                    nPixelG = c.G - 255;
                    nPixelB = c.B - 255;
                }
                else if (colorFilterType == ColorFilterTypes.Green)
                {
                    nPixelR = c.R - 255;
                    nPixelG = c.G;
                    nPixelB = c.B - 255;
                }
                else if (colorFilterType == ColorFilterTypes.Blue)
                {
                    nPixelR = c.R - 255;
                    nPixelG = c.G - 255;
                    nPixelB = c.B;
                }

                nPixelR = Math.Max(nPixelR, 0);
                nPixelR = Math.Min(255, nPixelR);

                nPixelG = Math.Max(nPixelG, 0);
                nPixelG = Math.Min(255, nPixelG);

                nPixelB = Math.Max(nPixelB, 0);
                nPixelB = Math.Min(255, nPixelB);

                bmap.SetPixel(i, j, Color.FromArgb((byte) nPixelR, (byte) nPixelG, (byte) nPixelB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetGamma(double red, double green, double blue)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            var redGamma = CreateGammaArray(red);
            var greenGamma = CreateGammaArray(green);
            var blueGamma = CreateGammaArray(blue);
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        private byte[] CreateGammaArray(double color)
        {
            var gammaArray = new byte[256];
            for (var i = 0; i < 256; ++i)
                gammaArray[i] = (byte) Math.Min(255, (int) (255.0 * Math.Pow(i / 255.0, 1.0 / color) + 0.5));
            return gammaArray;
        }

        public void SetBrightness(int brightness)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var cR = c.R + brightness;
                var cG = c.G + brightness;
                var cB = c.B + brightness;

                if (cR < 0) cR = 1;
                if (cR > 255) cR = 255;

                if (cG < 0) cG = 1;
                if (cG > 255) cG = 255;

                if (cB < 0) cB = 1;
                if (cB > 255) cB = 255;

                bmap.SetPixel(i, j, Color.FromArgb((byte) cR, (byte) cG, (byte) cB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetContrast(double contrast)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var pR = c.R / 255.0;
                pR -= 0.5;
                pR *= contrast;
                pR += 0.5;
                pR *= 255;
                if (pR < 0) pR = 0;
                if (pR > 255) pR = 255;

                var pG = c.G / 255.0;
                pG -= 0.5;
                pG *= contrast;
                pG += 0.5;
                pG *= 255;
                if (pG < 0) pG = 0;
                if (pG > 255) pG = 255;

                var pB = c.B / 255.0;
                pB -= 0.5;
                pB *= contrast;
                pB += 0.5;
                pB *= 255;
                if (pB < 0) pB = 0;
                if (pB > 255) pB = 255;

                bmap.SetPixel(i, j, Color.FromArgb((byte) pR, (byte) pG, (byte) pB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetGrayscale()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var gray = (byte) (.299 * c.R + .587 * c.G + .114 * c.B);

                bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetInvert()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                var temp = _currentBitmap;
                var bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                var nWidthFactor = temp.Width / (double) newWidth;
                var nHeightFactor = temp.Height / (double) newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                var color1 = new Color();
                var color2 = new Color();
                var color3 = new Color();
                var color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (var x = 0; x < bmap.Width; ++x)
                for (var y = 0; y < bmap.Height; ++y)
                {
                    fr_x = (int) Math.Floor(x * nWidthFactor);
                    fr_y = (int) Math.Floor(y * nHeightFactor);
                    cx = fr_x + 1;
                    if (cx >= temp.Width) cx = fr_x;
                    cy = fr_y + 1;
                    if (cy >= temp.Height) cy = fr_y;
                    fx = x * nWidthFactor - fr_x;
                    fy = y * nHeightFactor - fr_y;
                    nx = 1.0 - fx;
                    ny = 1.0 - fy;

                    color1 = temp.GetPixel(fr_x, fr_y);
                    color2 = temp.GetPixel(cx, fr_y);
                    color3 = temp.GetPixel(fr_x, cy);
                    color4 = temp.GetPixel(cx, cy);

                    // Blue
                    bp1 = (byte) (nx * color1.B + fx * color2.B);

                    bp2 = (byte) (nx * color3.B + fx * color4.B);

                    nBlue = (byte) (ny * bp1 + fy * bp2);

                    // Green
                    bp1 = (byte) (nx * color1.G + fx * color2.G);

                    bp2 = (byte) (nx * color3.G + fx * color4.G);

                    nGreen = (byte) (ny * bp1 + fy * bp2);

                    // Red
                    bp1 = (byte) (nx * color1.R + fx * color2.R);

                    bp2 = (byte) (nx * color3.R + fx * color4.R);

                    nRed = (byte) (ny * bp1 + fy * bp2);

                    bmap.SetPixel(x, y, Color.FromArgb(255, nRed, nGreen, nBlue));
                }

                _currentBitmap = (Bitmap) bmap.Clone();
            }
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            bmap.RotateFlip(rotateFlipType);
            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Crop(int xPosition, int yPosition, int width, int height)
        {
            try
            {
                var temp = _currentBitmap;
                var bmap = (Bitmap) temp.Clone();
                //			if (xPosition + width > _currentBitmap.Width)
                //				width = _currentBitmap.Width - xPosition;
                //			if (yPosition + height > _currentBitmap.Height)
                //				height = _currentBitmap.Height - yPosition;

                var rect = new Rectangle(xPosition, yPosition, width, height);
                _currentBitmap = bmap.Clone(rect, bmap.PixelFormat);
            }
            catch
            {
            }
        }

        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)
        {
            _bitmapPrevCropArea = _currentBitmap;
            var bmap = (Bitmap) _bitmapPrevCropArea.Clone();
            var gr = Graphics.FromImage(bmap);
            var cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;
            var rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);
            var rect2 = new Rectangle(0, yPosition, xPosition, height);
            var rect3 = new Rectangle(0, yPosition + height, _currentBitmap.Width, _currentBitmap.Height);
            var rect4 = new Rectangle(xPosition + width, yPosition, _currentBitmap.Width - xPosition - width, height);
            gr.FillRectangle(cBrush, rect1);
            gr.FillRectangle(cBrush, rect2);
            gr.FillRectangle(cBrush, rect3);
            gr.FillRectangle(cBrush, rect4);
            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void RemoveCropAreaDraw()
        {
            _currentBitmap = (Bitmap) _bitmapPrevCropArea.Clone();
        }

        public void InsertText(string text, int xPosition, int yPosition, string fontName, float fontSize,
            string fontStyle, string colorName1, string colorName2)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            var gr = Graphics.FromImage(bmap);
            if (fontName.Length == 0 || fontName == null)
                fontName = "Times New Roman";
            if (fontSize.Equals(null))
                fontSize = 10.0F;
            var font = new Font(fontName, fontSize);
            if (fontStyle.Length > 0)
            {
                var fStyle = FontStyle.Regular;
                switch (fontStyle.ToLower())
                {
                    case "bold":
                        fStyle = FontStyle.Bold;
                        break;
                    case "italic":
                        fStyle = FontStyle.Italic;
                        break;
                    case "underline":
                        fStyle = FontStyle.Underline;
                        break;
                    case "strikeout":
                        fStyle = FontStyle.Strikeout;
                        break;
                }

                font = new Font(fontName, fontSize, fStyle);
            }

            if (colorName1.Length == 0 || colorName1 == null)
                colorName1 = "Black";
            if (colorName2.Length == 0 || colorName2 == null)
                colorName2 = colorName1;

            var color1 = Color.FromName(colorName1);
            var color2 = Color.FromName(colorName2);
            var gW = (int) (text.Length * fontSize);
            gW = gW == 0 ? 10 : gW;
            var LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int) fontSize), color1, color2,
                LinearGradientMode.Vertical);
            gr.DrawString(text, font, LGBrush, xPosition, yPosition);
            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void InsertImage(string imagePath, int xPosition, int yPosition)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            var gr = Graphics.FromImage(bmap);
            if (imagePath.Length > 0)
            {
                var i_bitmap = (Bitmap) Image.FromFile(imagePath);
                var rect = new Rectangle(xPosition, yPosition, i_bitmap.Width, i_bitmap.Height);
                gr.DrawImage(Image.FromFile(imagePath), rect);
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void InsertShape(string shapeType, int xPosition, int yPosition, int width, int height, string colorName)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            var gr = Graphics.FromImage(bmap);
            if (colorName.Length == 0 || colorName == null)
                colorName = "Black";

            var pen = new Pen(Color.FromName(colorName));
            switch (shapeType.ToLower())
            {
                case "filledellipse":
                    gr.FillEllipse(pen.Brush, xPosition, yPosition, width, height);
                    break;
                case "filledrectangle":
                    gr.FillRectangle(pen.Brush, xPosition, yPosition, width, height);
                    break;
                case "ellipse":
                    gr.DrawEllipse(pen, xPosition, yPosition, width, height);
                    break;
                case "rectangle":
                default:
                    gr.DrawRectangle(pen, xPosition, yPosition, width, height);
                    break;
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }
    }
}