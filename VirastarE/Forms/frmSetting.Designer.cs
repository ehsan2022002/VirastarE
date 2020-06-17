namespace VirastarE.Forms
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblErr = new System.Windows.Forms.Label();
            this.txtIgnoreList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTackval = new System.Windows.Forms.Label();
            this.chkIgnoreEnglish = new System.Windows.Forms.CheckBox();
            this.chkStemSpell = new System.Windows.Forms.CheckBox();
            this.lblTackbar = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.chkPunkRec = new System.Windows.Forms.CheckBox();
            this.chkRecSpell = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSysinfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 317);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.resultLabel);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(535, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "واژه نامه";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(403, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "نمایش پوشه";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "جستجو";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(245, 229);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 16);
            this.resultLabel.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 23);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "حذف واژه";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(8, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(519, 164);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.lblErr);
            this.tabPage3.Controls.Add(this.txtIgnoreList);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.lblTackval);
            this.tabPage3.Controls.Add(this.chkIgnoreEnglish);
            this.tabPage3.Controls.Add(this.chkStemSpell);
            this.tabPage3.Controls.Add(this.lblTackbar);
            this.tabPage3.Controls.Add(this.trackBar1);
            this.tabPage3.Controls.Add(this.chkPunkRec);
            this.tabPage3.Controls.Add(this.chkRecSpell);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(535, 288);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تنظیمات";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblErr.ForeColor = System.Drawing.Color.Salmon;
            this.lblErr.Location = new System.Drawing.Point(184, 262);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 13);
            this.lblErr.TabIndex = 10;
            // 
            // txtIgnoreList
            // 
            this.txtIgnoreList.Location = new System.Drawing.Point(109, 233);
            this.txtIgnoreList.Name = "txtIgnoreList";
            this.txtIgnoreList.Size = new System.Drawing.Size(219, 23);
            this.txtIgnoreList.TabIndex = 9;
            this.txtIgnoreList.TextChanged += new System.EventHandler(this.txtIgnoreList_TextChanged);
            this.txtIgnoreList.Validating += new System.ComponentModel.CancelEventHandler(this.txtIgnoreList_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "این کاراکترها نادیده گرفته شود";
            this.toolTip1.SetToolTip(this.label3, "کاراکترهای زیر را میتوان برای املا نادیده فرض کرد\r\n!:\\.،؛؟»\\]\\)\\}«\\[\\(\\{-_&^#");
            // 
            // lblTackval
            // 
            this.lblTackval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTackval.AutoSize = true;
            this.lblTackval.Location = new System.Drawing.Point(334, 121);
            this.lblTackval.Name = "lblTackval";
            this.lblTackval.Size = new System.Drawing.Size(0, 16);
            this.lblTackval.TabIndex = 7;
            // 
            // chkIgnoreEnglish
            // 
            this.chkIgnoreEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIgnoreEnglish.AutoSize = true;
            this.chkIgnoreEnglish.Location = new System.Drawing.Point(276, 191);
            this.chkIgnoreEnglish.Name = "chkIgnoreEnglish";
            this.chkIgnoreEnglish.Size = new System.Drawing.Size(229, 20);
            this.chkIgnoreEnglish.TabIndex = 6;
            this.chkIgnoreEnglish.Text = "لغات یا حروف انگلیسی را اشکال نگیر";
            this.chkIgnoreEnglish.UseVisualStyleBackColor = true;
            this.chkIgnoreEnglish.CheckedChanged += new System.EventHandler(this.chkIgnoreEnglish_CheckedChanged);
            // 
            // chkStemSpell
            // 
            this.chkStemSpell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStemSpell.AutoSize = true;
            this.chkStemSpell.Location = new System.Drawing.Point(187, 165);
            this.chkStemSpell.Name = "chkStemSpell";
            this.chkStemSpell.Size = new System.Drawing.Size(318, 20);
            this.chkStemSpell.TabIndex = 5;
            this.chkStemSpell.Text = "اگر در لغتنامه یافت نشد ریشه کلمه هم مقایسه شود";
            this.chkStemSpell.UseVisualStyleBackColor = true;
            this.chkStemSpell.CheckedChanged += new System.EventHandler(this.chkStemSpell_CheckedChanged);
            // 
            // lblTackbar
            // 
            this.lblTackbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTackbar.AutoSize = true;
            this.lblTackbar.Location = new System.Drawing.Point(200, 121);
            this.lblTackbar.Name = "lblTackbar";
            this.lblTackbar.Size = new System.Drawing.Size(306, 16);
            this.lblTackbar.TabIndex = 4;
            this.lblTackbar.Text = "واژه نامه املایی (سایتهای خبری - واژه نامه ویراستاری)";
            this.toolTip1.SetToolTip(this.lblTackbar, "1.آزمایشگاه ویراستاری\r\n2.ویکی پیدیا اصلاح شده\r\n3.سایتهای خبری\r\n4.ویکی پیدیا با لغ" +
        "ات فارسی اضافه شده\r\n5.ویکی پیدیا");
            this.lblTackbar.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(47, 106);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(134, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.toolTip1.SetToolTip(this.trackBar1, "1.سایتهای خبری\r\n2.فرهنگ نامه آزمایشگاه ویراستاری");
            this.trackBar1.Value = 1;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // chkPunkRec
            // 
            this.chkPunkRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPunkRec.AutoSize = true;
            this.chkPunkRec.Location = new System.Drawing.Point(314, 60);
            this.chkPunkRec.Name = "chkPunkRec";
            this.chkPunkRec.Size = new System.Drawing.Size(191, 20);
            this.chkPunkRec.TabIndex = 2;
            this.chkPunkRec.Text = "انشای متن مرتبا بازبینی شود";
            this.chkPunkRec.UseVisualStyleBackColor = true;
            this.chkPunkRec.CheckedChanged += new System.EventHandler(this.chkPunkRec_CheckedChanged);
            // 
            // chkRecSpell
            // 
            this.chkRecSpell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRecSpell.AutoSize = true;
            this.chkRecSpell.Location = new System.Drawing.Point(320, 34);
            this.chkRecSpell.Name = "chkRecSpell";
            this.chkRecSpell.Size = new System.Drawing.Size(185, 20);
            this.chkRecSpell.TabIndex = 0;
            this.chkRecSpell.Text = "املای متن مرتبا بازبینی شود";
            this.chkRecSpell.UseVisualStyleBackColor = true;
            this.chkRecSpell.CheckedChanged += new System.EventHandler(this.chkRecSpell_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(535, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "درباره";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(298, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "کاندید نسخه اصلی ویرایش 3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 176);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.lblSysinfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(535, 288);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "سیستم";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VirastarE.Properties.Resources.loading_gears_animation_10;
            this.pictureBox1.Location = new System.Drawing.Point(360, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 122);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblSysinfo
            // 
            this.lblSysinfo.AutoSize = true;
            this.lblSysinfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSysinfo.Location = new System.Drawing.Point(57, 45);
            this.lblSysinfo.Name = "lblSysinfo";
            this.lblSysinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSysinfo.Size = new System.Drawing.Size(0, 16);
            this.lblSysinfo.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 317);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تنظیمات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkRecSpell;
        private System.Windows.Forms.CheckBox chkPunkRec;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblTackbar;
        private System.Windows.Forms.CheckBox chkStemSpell;
        private System.Windows.Forms.CheckBox chkIgnoreEnglish;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTackval;
        private System.Windows.Forms.TextBox txtIgnoreList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblSysinfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}