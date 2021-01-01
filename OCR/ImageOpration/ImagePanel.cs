using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageOpration
{
    public partial class ImagePanel : UserControl
    {
        private Size canvasSize = new Size(60, 40);

        private Bitmap image;

        private int viewRectWidth, viewRectHeight; // view window width and height

        private float zoom = 1.0f;

        public ImagePanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        public float Zoom
        {
            get => zoom;
            set
            {
                if (value < 0.001f) value = 0.001f;
                zoom = value;

                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }
        //private System.Windows.Forms.HScrollBar hScrollBar1;
        //private System.Windows.Forms.VScrollBar vScrollBar1;

        public Size CanvasSize
        {
            get => canvasSize;
            set
            {
                canvasSize = value;
                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }

        public Bitmap Image
        {
            get => image;
            set
            {
                image = value;
                displayScrollbar();
                setScrollbarValues();
                Invalidate();
            }
        }

        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.HighQualityBilinear;

        private void displayScrollbar()
        {
            viewRectWidth = Width;
            viewRectHeight = Height;

            if (image != null) canvasSize = image.Size;

            // If the zoomed image is wider than view window, show the HScrollBar and adjust the view window
            if (viewRectWidth > canvasSize.Width * zoom)
            {
                hScrollBar1.Visible = false;
                viewRectHeight = Height;
            }
            else
            {
                hScrollBar1.Visible = true;
                viewRectHeight = Height - hScrollBar1.Height;
            }

            // If the zoomed image is taller than view window, show the VScrollBar and adjust the view window
            if (viewRectHeight > canvasSize.Height * zoom)
            {
                vScrollBar1.Visible = false;
                viewRectWidth = Width;
            }
            else
            {
                vScrollBar1.Visible = true;
                viewRectWidth = Width - vScrollBar1.Width;
            }

            // Set up scrollbars
            hScrollBar1.Location = new Point(0, Height - hScrollBar1.Height);
            hScrollBar1.Width = viewRectWidth;
            vScrollBar1.Location = new Point(Width - vScrollBar1.Width, 0);
            vScrollBar1.Height = viewRectHeight;
        }

        private void setScrollbarValues()
        {
            // Set the Maximum, Minimum, LargeChange and SmallChange properties.
            vScrollBar1.Minimum = 0;
            hScrollBar1.Minimum = 0;

            // If the offset does not make the Maximum less than zero, set its value. 
            if (canvasSize.Width * zoom - viewRectWidth > 0)
                hScrollBar1.Maximum = (int) (canvasSize.Width * zoom) - viewRectWidth;
            // If the VScrollBar is visible, adjust the Maximum of the 
            // HSCrollBar to account for the width of the VScrollBar.  
            if (vScrollBar1.Visible) hScrollBar1.Maximum += vScrollBar1.Width;
            hScrollBar1.LargeChange = hScrollBar1.Maximum / 10;
            hScrollBar1.SmallChange = hScrollBar1.Maximum / 20;

            // Adjust the Maximum value to make the raw Maximum value 
            // attainable by user interaction.
            hScrollBar1.Maximum += hScrollBar1.LargeChange;

            // If the offset does not make the Maximum less than zero, set its value.    
            if (canvasSize.Height * zoom - viewRectHeight > 0)
                vScrollBar1.Maximum = (int) (canvasSize.Height * zoom) - viewRectHeight;

            // If the HScrollBar is visible, adjust the Maximum of the 
            // VSCrollBar to account for the width of the HScrollBar.
            if (hScrollBar1.Visible) vScrollBar1.Maximum += hScrollBar1.Height;
            vScrollBar1.LargeChange = vScrollBar1.Maximum / 10;
            vScrollBar1.SmallChange = vScrollBar1.Maximum / 20;

            // Adjust the Maximum value to make the raw Maximum value 
            // attainable by user interaction.
            vScrollBar1.Maximum += vScrollBar1.LargeChange;
        }

        protected override void OnLoad(EventArgs e)
        {
            displayScrollbar();
            setScrollbarValues();
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            displayScrollbar();
            setScrollbarValues();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //draw image
            if (image != null)
            {
                Rectangle srcRect, distRect;
                var pt = new Point((int) (hScrollBar1.Value / zoom), (int) (vScrollBar1.Value / zoom));
                if (canvasSize.Width * zoom < viewRectWidth && canvasSize.Height * zoom < viewRectHeight)
                    srcRect = new Rectangle(0, 0, canvasSize.Width, canvasSize.Height); // view all image
                else
                    srcRect = new Rectangle(pt,
                        new Size((int) (viewRectWidth / zoom),
                            (int) (viewRectHeight / zoom))); // view a portion of image

                distRect = new Rectangle(-srcRect.Width / 2, -srcRect.Height / 2, srcRect.Width,
                    srcRect.Height); // the center of apparent image is on origin

                var mx = new Matrix(); // create an identity matrix
                mx.Scale(zoom, zoom); // zoom image
                mx.Translate(viewRectWidth / 2.0f, viewRectHeight / 2.0f,
                    MatrixOrder.Append); // move image to view window center

                var g = e.Graphics;
                g.InterpolationMode = InterpolationMode;
                g.Transform = mx;
                g.DrawImage(image, distRect, srcRect, GraphicsUnit.Pixel);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }
    }
}