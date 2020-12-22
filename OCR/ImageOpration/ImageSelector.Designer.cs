namespace ImageOpration
{
    partial class ImageSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelector));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnOCR = new System.Windows.Forms.Button();
            this.FilePathLable = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRotate180 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.chkSpell = new System.Windows.Forms.CheckBox();
            this.pictureBoxProcess = new System.Windows.Forms.PictureBox();
            this.PictureboxCurrent = new ImageOpration.ImagePanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOpenFile.Location = new System.Drawing.Point(754, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(106, 43);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "باز کردن فایل تصویر";
            this.toolTip1.SetToolTip(this.btnOpenFile, "ترجیها از تصاویر بدون خط و خش با \r\n رزولوشن 300 نقطه در اینچ استفاده نمایید");
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOCR
            // 
            this.btnOCR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOCR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOCR.Location = new System.Drawing.Point(754, 428);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(106, 43);
            this.btnOCR.TabIndex = 1;
            this.btnOCR.Text = "تبدیل تصویر به متن";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // FilePathLable
            // 
            this.FilePathLable.AutoSize = true;
            this.FilePathLable.Location = new System.Drawing.Point(16, 6);
            this.FilePathLable.Name = "FilePathLable";
            this.FilePathLable.Size = new System.Drawing.Size(0, 13);
            this.FilePathLable.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBarZoom);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(747, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(120, 62);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بزرگنمایی";
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trackBarZoom.Location = new System.Drawing.Point(8, 24);
            this.trackBarZoom.Maximum = 200;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(100, 45);
            this.trackBarZoom.TabIndex = 20;
            this.trackBarZoom.Value = 100;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnRotate180);
            this.groupBox4.Controls.Add(this.btnRotate90);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox4.Location = new System.Drawing.Point(747, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(120, 133);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "نمایش";
            // 
            // btnRotate180
            // 
            this.btnRotate180.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRotate180.Location = new System.Drawing.Point(8, 37);
            this.btnRotate180.Name = "btnRotate180";
            this.btnRotate180.Size = new System.Drawing.Size(106, 23);
            this.btnRotate180.TabIndex = 15;
            this.btnRotate180.Text = "چرخش";
            this.btnRotate180.Click += new System.EventHandler(this.btnRotate180_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRotate90.Location = new System.Drawing.Point(8, 66);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(106, 23);
            this.btnRotate90.TabIndex = 14;
            this.btnRotate90.Text = "نیم چرخش";
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // chkSpell
            // 
            this.chkSpell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpell.AutoSize = true;
            this.chkSpell.Checked = true;
            this.chkSpell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkSpell.Location = new System.Drawing.Point(747, 388);
            this.chkSpell.Name = "chkSpell";
            this.chkSpell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSpell.Size = new System.Drawing.Size(113, 17);
            this.chkSpell.TabIndex = 23;
            this.chkSpell.Text = "تصحیح خودکار لغات";
            this.chkSpell.UseVisualStyleBackColor = true;
            this.chkSpell.CheckedChanged += new System.EventHandler(this.chkSpell_CheckedChanged);
            // 
            // pictureBoxProcess
            // 
            this.pictureBoxProcess.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProcess.BackgroundImage = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.Image = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.InitialImage = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.Location = new System.Drawing.Point(784, 74);
            this.pictureBoxProcess.Name = "pictureBoxProcess";
            this.pictureBoxProcess.Size = new System.Drawing.Size(53, 39);
            this.pictureBoxProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProcess.TabIndex = 24;
            this.pictureBoxProcess.TabStop = false;
            // 
            // PictureboxCurrent
            // 
            this.PictureboxCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureboxCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureboxCurrent.CanvasSize = new System.Drawing.Size(60, 40);
            this.PictureboxCurrent.Image = null;
            this.PictureboxCurrent.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.PictureboxCurrent.Location = new System.Drawing.Point(19, 25);
            this.PictureboxCurrent.Name = "PictureboxCurrent";
            this.PictureboxCurrent.Size = new System.Drawing.Size(711, 446);
            this.PictureboxCurrent.TabIndex = 2;
            this.PictureboxCurrent.TabStop = false;
            this.PictureboxCurrent.Zoom = 1F;
            // 
            // ImageSelector
            // 
            this.ClientSize = new System.Drawing.Size(876, 483);
            this.Controls.Add(this.pictureBoxProcess);
            this.Controls.Add(this.chkSpell);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureboxCurrent);
            this.Controls.Add(this.FilePathLable);
            this.Controls.Add(this.btnOCR);
            this.Controls.Add(this.btnOpenFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageSelector";
            this.Text = "نویسه خوان";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageOpration.ImagePanel PictureboxCurrent;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOCR;
        //private System.Windows.Forms.PictureBox PictureboxCurrent;
        private System.Windows.Forms.Label FilePathLable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRotate180;
        private System.Windows.Forms.Button btnRotate90;
        private System.Windows.Forms.CheckBox chkSpell;
        private System.Windows.Forms.PictureBox pictureBoxProcess;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

