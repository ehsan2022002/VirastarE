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
            this.chkSpell = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ZoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Rotate90StripButton = new System.Windows.Forms.ToolStripButton();
            this.Rotate180StripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BlackandWhiteStripButton = new System.Windows.Forms.ToolStripButton();
            this.InvertStripButton = new System.Windows.Forms.ToolStripButton();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.pictureBoxProcess = new System.Windows.Forms.PictureBox();
            this.PictureboxCurrent = new ImageOpration.ImagePanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOpenFile.Location = new System.Drawing.Point(672, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(130, 43);
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
            this.btnOCR.Location = new System.Drawing.Point(672, 423);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(130, 43);
            this.btnOCR.TabIndex = 1;
            this.btnOCR.Text = "تبدیل تصویر به متن";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // chkSpell
            // 
            this.chkSpell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpell.AutoSize = true;
            this.chkSpell.Checked = true;
            this.chkSpell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkSpell.Location = new System.Drawing.Point(689, 360);
            this.chkSpell.Name = "chkSpell";
            this.chkSpell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSpell.Size = new System.Drawing.Size(113, 17);
            this.chkSpell.TabIndex = 23;
            this.chkSpell.Text = "تصحیح خودکار لغات";
            this.chkSpell.UseVisualStyleBackColor = true;
            this.chkSpell.CheckedChanged += new System.EventHandler(this.chkSpell_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 474);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.PictureboxCurrent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تصاویر";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInToolStripButton,
            this.ZoomOutToolStripButton,
            this.toolStripSeparator,
            this.Rotate90StripButton,
            this.Rotate180StripButton,
            this.toolStripSeparator1,
            this.BlackandWhiteStripButton,
            this.InvertStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(649, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ZoomInToolStripButton
            // 
            this.ZoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInToolStripButton.Image = global::ImageOpration.Properties.Resources.zoom_in_icon;
            this.ZoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInToolStripButton.Name = "ZoomInToolStripButton";
            this.ZoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomInToolStripButton.Text = "ZoomIn";
            this.ZoomInToolStripButton.Click += new System.EventHandler(this.ZoomInToolStripButton_Click);
            // 
            // ZoomOutToolStripButton
            // 
            this.ZoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutToolStripButton.Image")));
            this.ZoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutToolStripButton.Name = "ZoomOutToolStripButton";
            this.ZoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutToolStripButton.Text = "ZoomOut";
            this.ZoomOutToolStripButton.Click += new System.EventHandler(this.ZoomOutToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // Rotate90StripButton
            // 
            this.Rotate90StripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rotate90StripButton.Image = global::ImageOpration.Properties.Resources.rotate90;
            this.Rotate90StripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rotate90StripButton.Name = "Rotate90StripButton";
            this.Rotate90StripButton.Size = new System.Drawing.Size(23, 22);
            this.Rotate90StripButton.Text = "Rotate90";
            this.Rotate90StripButton.Click += new System.EventHandler(this.Rotate90StripButton_Click);
            // 
            // Rotate180StripButton
            // 
            this.Rotate180StripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rotate180StripButton.Image = global::ImageOpration.Properties.Resources.rotate180;
            this.Rotate180StripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rotate180StripButton.Name = "Rotate180StripButton";
            this.Rotate180StripButton.Size = new System.Drawing.Size(23, 22);
            this.Rotate180StripButton.Text = "Rotate180";
            this.Rotate180StripButton.Click += new System.EventHandler(this.Rotate180StripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BlackandWhiteStripButton
            // 
            this.BlackandWhiteStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BlackandWhiteStripButton.Image = global::ImageOpration.Properties.Resources.ConvertImage;
            this.BlackandWhiteStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BlackandWhiteStripButton.Name = "BlackandWhiteStripButton";
            this.BlackandWhiteStripButton.Size = new System.Drawing.Size(23, 22);
            this.BlackandWhiteStripButton.Text = "BlackandWhite";
            this.BlackandWhiteStripButton.Click += new System.EventHandler(this.BlackandWhiteStripButton_Click);
            // 
            // InvertStripButton
            // 
            this.InvertStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InvertStripButton.Image = global::ImageOpration.Properties.Resources.invert;
            this.InvertStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InvertStripButton.Name = "InvertStripButton";
            this.InvertStripButton.Size = new System.Drawing.Size(23, 22);
            this.InvertStripButton.Text = "Invert";
            this.InvertStripButton.Click += new System.EventHandler(this.InvertStripButton_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(672, 74);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxFiles.Size = new System.Drawing.Size(131, 277);
            this.listBoxFiles.TabIndex = 27;
            this.listBoxFiles.Click += new System.EventHandler(this.listBoxFiles_Click);
            // 
            // pictureBoxProcess
            // 
            this.pictureBoxProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxProcess.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProcess.BackgroundImage = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.Image = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.InitialImage = global::ImageOpration.Properties.Resources.digitullCircles;
            this.pictureBoxProcess.Location = new System.Drawing.Point(712, 383);
            this.pictureBoxProcess.Name = "pictureBoxProcess";
            this.pictureBoxProcess.Size = new System.Drawing.Size(53, 34);
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
            this.PictureboxCurrent.Location = new System.Drawing.Point(20, 43);
            this.PictureboxCurrent.Name = "PictureboxCurrent";
            this.PictureboxCurrent.Size = new System.Drawing.Size(617, 387);
            this.PictureboxCurrent.TabIndex = 3;
            this.PictureboxCurrent.TabStop = false;
            this.PictureboxCurrent.Zoom = 1F;
            // 
            // ImageSelector
            // 
            this.ClientSize = new System.Drawing.Size(818, 483);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBoxProcess);
            this.Controls.Add(this.chkSpell);
            this.Controls.Add(this.btnOCR);
            this.Controls.Add(this.btnOpenFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageSelector";
            this.Text = "نویسه خوان";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.CheckBox chkSpell;
        private System.Windows.Forms.PictureBox pictureBoxProcess;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ImagePanel PictureboxCurrent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ZoomInToolStripButton;
        private System.Windows.Forms.ToolStripButton ZoomOutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton Rotate90StripButton;
        private System.Windows.Forms.ToolStripButton Rotate180StripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BlackandWhiteStripButton;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.ToolStripButton InvertStripButton;
    }
}

