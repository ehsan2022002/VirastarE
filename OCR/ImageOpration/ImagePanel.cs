using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace ImageOpration
{
	/// <summary>
	/// Summary description for ImagePanel.
	/// </summary>
	public class ImagePanel : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImagePanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
				ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		int viewRectWidth, viewRectHeight; // view window width and height

		float zoom = 1.0f;
		public float Zoom
		{
			get { return zoom; }
			set
			{
				if (value < 0.001f) value = 0.001f;
				zoom = value;

				displayScrollbar();
				setScrollbarValues();
				Invalidate();
			}
		}

		Size canvasSize = new Size(60, 40);
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
	
		public Size CanvasSize
		{
			get { return canvasSize; }
			set
			{
				canvasSize = value;
				displayScrollbar();
				setScrollbarValues();
				Invalidate();
			}
		}

		Bitmap image;
		public Bitmap Image
		{
			get { return image; }
			set 
			{
				image = value;
				displayScrollbar();
				setScrollbarValues(); 
				Invalidate();
			}
		}

		private void displayScrollbar()
		{
			viewRectWidth = this.Width;
			viewRectHeight = this.Height;

			if (image != null) canvasSize = image.Size;

			// If the zoomed image is wider than view window, show the HScrollBar and adjust the view window
			if (viewRectWidth > canvasSize.Width*zoom)
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
			if (viewRectHeight > canvasSize.Height*zoom)
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
			this.vScrollBar1.Minimum = 0;
			this.hScrollBar1.Minimum = 0;

			// If the offset does not make the Maximum less than zero, set its value. 
			if ((canvasSize.Width * zoom - viewRectWidth) > 0)
			{
				this.hScrollBar1.Maximum =(int)( canvasSize.Width * zoom) - viewRectWidth;
			}
			// If the VScrollBar is visible, adjust the Maximum of the 
			// HSCrollBar to account for the width of the VScrollBar.  
			if (this.vScrollBar1.Visible)
			{
				this.hScrollBar1.Maximum += this.vScrollBar1.Width;
			}
			this.hScrollBar1.LargeChange = this.hScrollBar1.Maximum / 10;
			this.hScrollBar1.SmallChange = this.hScrollBar1.Maximum / 20;

			// Adjust the Maximum value to make the raw Maximum value 
			// attainable by user interaction.
			this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange;

			// If the offset does not make the Maximum less than zero, set its value.    
			if ((canvasSize.Height * zoom - viewRectHeight) > 0)
			{
				this.vScrollBar1.Maximum = (int)(canvasSize.Height * zoom) - viewRectHeight;
			}

			// If the HScrollBar is visible, adjust the Maximum of the 
			// VSCrollBar to account for the width of the HScrollBar.
			if (this.hScrollBar1.Visible)
			{
				this.vScrollBar1.Maximum += this.hScrollBar1.Height;
			}
			this.vScrollBar1.LargeChange = this.vScrollBar1.Maximum / 10;
			this.vScrollBar1.SmallChange = this.vScrollBar1.Maximum / 20;

			// Adjust the Maximum value to make the raw Maximum value 
			// attainable by user interaction.
			this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange;
		}


		InterpolationMode interMode = InterpolationMode.HighQualityBilinear;
		public InterpolationMode InterpolationMode
		{
			get{return interMode;}
			set{interMode=value;}
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(64, 144);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(128, 17);
			this.hScrollBar1.TabIndex = 0;
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(176, 40);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.TabIndex = 1;
			this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
			// 
			// ImagePanel
			// 
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.hScrollBar1);
			this.Name = "ImagePanel";
			this.Size = new System.Drawing.Size(216, 184);
			this.Load += new System.EventHandler(this.ImagePanel_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ImagePanel_Load(object sender, System.EventArgs e)
		{			
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
			if(image!=null)
			{
				Rectangle srcRect,distRect;
				Point pt=new Point((int)(hScrollBar1.Value/zoom),(int)(vScrollBar1.Value/zoom));
				if (canvasSize.Width * zoom < viewRectWidth && canvasSize.Height * zoom < viewRectHeight)
					srcRect = new Rectangle(0, 0, canvasSize.Width, canvasSize.Height);  // view all image
				else srcRect = new Rectangle(pt, new Size((int)(viewRectWidth / zoom), (int)(viewRectHeight / zoom))); // view a portion of image

				distRect=new Rectangle((int)(-srcRect.Width/2),-srcRect.Height/2,srcRect.Width,srcRect.Height); // the center of apparent image is on origin
 
				Matrix mx=new Matrix(); // create an identity matrix
				mx.Scale(zoom,zoom); // zoom image
				mx.Translate(viewRectWidth/2.0f,viewRectHeight/2.0f, MatrixOrder.Append); // move image to view window center

				Graphics g=e.Graphics;
				g.InterpolationMode=interMode;
				g.Transform=mx;
				g.DrawImage(image,distRect,srcRect, GraphicsUnit.Pixel);
			}

		}

		private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			this.Invalidate();
		}

		private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			this.Invalidate();
		}

	}
}
