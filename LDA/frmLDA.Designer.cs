namespace LDA
{
    partial class frmLDA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLDA));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txttwords = new System.Windows.Forms.TextBox();
            this.lbltwords = new System.Windows.Forms.Label();
            this.txtniters = new System.Windows.Forms.TextBox();
            this.lblniters = new System.Windows.Forms.Label();
            this.txtsavestep = new System.Windows.Forms.TextBox();
            this.lblsavestep = new System.Windows.Forms.Label();
            this.txttopics = new System.Windows.Forms.TextBox();
            this.lbltopics = new System.Windows.Forms.Label();
            this.txtbeta = new System.Windows.Forms.TextBox();
            this.lblbeta = new System.Windows.Forms.Label();
            this.txtalpha = new System.Windows.Forms.TextBox();
            this.lblalpha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOutDir = new System.Windows.Forms.Button();
            this.btnInFiel = new System.Windows.Forms.Button();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(441, 23);
            this.progressBar1.TabIndex = 37;
            this.progressBar1.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(12, 387);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 36;
            this.btnRun.Text = "اجرا";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txttwords);
            this.groupBox2.Controls.Add(this.lbltwords);
            this.groupBox2.Controls.Add(this.txtniters);
            this.groupBox2.Controls.Add(this.lblniters);
            this.groupBox2.Controls.Add(this.txtsavestep);
            this.groupBox2.Controls.Add(this.lblsavestep);
            this.groupBox2.Controls.Add(this.txttopics);
            this.groupBox2.Controls.Add(this.lbltopics);
            this.groupBox2.Controls.Add(this.txtbeta);
            this.groupBox2.Controls.Add(this.lblbeta);
            this.groupBox2.Controls.Add(this.txtalpha);
            this.groupBox2.Controls.Add(this.lblalpha);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 239);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "پارامترهای ایجاد عنوان";
            // 
            // txttwords
            // 
            this.txttwords.Location = new System.Drawing.Point(372, 196);
            this.txttwords.Name = "txttwords";
            this.txttwords.Size = new System.Drawing.Size(100, 21);
            this.txttwords.TabIndex = 44;
            this.txttwords.Text = "30";
            // 
            // lbltwords
            // 
            this.lbltwords.AutoSize = true;
            this.lbltwords.Location = new System.Drawing.Point(478, 199);
            this.lbltwords.Name = "lbltwords";
            this.lbltwords.Size = new System.Drawing.Size(40, 13);
            this.lbltwords.TabIndex = 43;
            this.lbltwords.Text = "twords";
            // 
            // txtniters
            // 
            this.txtniters.Location = new System.Drawing.Point(372, 170);
            this.txtniters.Name = "txtniters";
            this.txtniters.Size = new System.Drawing.Size(100, 21);
            this.txtniters.TabIndex = 42;
            this.txtniters.Text = "100";
            // 
            // lblniters
            // 
            this.lblniters.AutoSize = true;
            this.lblniters.Location = new System.Drawing.Point(478, 173);
            this.lblniters.Name = "lblniters";
            this.lblniters.Size = new System.Drawing.Size(34, 13);
            this.lblniters.TabIndex = 41;
            this.lblniters.Text = "niters";
            // 
            // txtsavestep
            // 
            this.txtsavestep.Location = new System.Drawing.Point(372, 129);
            this.txtsavestep.Name = "txtsavestep";
            this.txtsavestep.Size = new System.Drawing.Size(100, 21);
            this.txtsavestep.TabIndex = 40;
            this.txtsavestep.Text = "100";
            // 
            // lblsavestep
            // 
            this.lblsavestep.AutoSize = true;
            this.lblsavestep.Location = new System.Drawing.Point(478, 132);
            this.lblsavestep.Name = "lblsavestep";
            this.lblsavestep.Size = new System.Drawing.Size(51, 13);
            this.lblsavestep.TabIndex = 39;
            this.lblsavestep.Text = "savestep";
            // 
            // txttopics
            // 
            this.txttopics.Location = new System.Drawing.Point(372, 103);
            this.txttopics.Name = "txttopics";
            this.txttopics.Size = new System.Drawing.Size(100, 21);
            this.txttopics.TabIndex = 38;
            this.txttopics.Text = "10";
            // 
            // lbltopics
            // 
            this.lbltopics.AutoSize = true;
            this.lbltopics.Location = new System.Drawing.Point(478, 106);
            this.lbltopics.Name = "lbltopics";
            this.lbltopics.Size = new System.Drawing.Size(35, 13);
            this.lbltopics.TabIndex = 37;
            this.lbltopics.Text = "topics";
            // 
            // txtbeta
            // 
            this.txtbeta.Location = new System.Drawing.Point(372, 66);
            this.txtbeta.Name = "txtbeta";
            this.txtbeta.Size = new System.Drawing.Size(100, 21);
            this.txtbeta.TabIndex = 36;
            this.txtbeta.Text = "0.1";
            // 
            // lblbeta
            // 
            this.lblbeta.AutoSize = true;
            this.lblbeta.Location = new System.Drawing.Point(478, 69);
            this.lblbeta.Name = "lblbeta";
            this.lblbeta.Size = new System.Drawing.Size(29, 13);
            this.lblbeta.TabIndex = 35;
            this.lblbeta.Text = "Beta";
            // 
            // txtalpha
            // 
            this.txtalpha.Location = new System.Drawing.Point(372, 40);
            this.txtalpha.Name = "txtalpha";
            this.txtalpha.Size = new System.Drawing.Size(100, 21);
            this.txtalpha.TabIndex = 34;
            this.txtalpha.Text = "0.1";
            // 
            // lblalpha
            // 
            this.lblalpha.AutoSize = true;
            this.lblalpha.Location = new System.Drawing.Point(478, 43);
            this.lblalpha.Name = "lblalpha";
            this.lblalpha.Size = new System.Drawing.Size(33, 13);
            this.lblalpha.TabIndex = 33;
            this.lblalpha.Text = "Alpha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOutDir);
            this.groupBox1.Controls.Add(this.btnInFiel);
            this.groupBox1.Controls.Add(this.txtoutput);
            this.groupBox1.Controls.Add(this.txtinput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 100);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فایل متنی";
            // 
            // btnOutDir
            // 
            this.btnOutDir.Location = new System.Drawing.Point(34, 61);
            this.btnOutDir.Name = "btnOutDir";
            this.btnOutDir.Size = new System.Drawing.Size(36, 23);
            this.btnOutDir.TabIndex = 35;
            this.btnOutDir.Text = "...";
            this.btnOutDir.UseVisualStyleBackColor = true;
            this.btnOutDir.Click += new System.EventHandler(this.btnOutDir_Click);
            // 
            // btnInFiel
            // 
            this.btnInFiel.Location = new System.Drawing.Point(34, 27);
            this.btnInFiel.Name = "btnInFiel";
            this.btnInFiel.Size = new System.Drawing.Size(36, 23);
            this.btnInFiel.TabIndex = 34;
            this.btnInFiel.Text = "...";
            this.btnInFiel.UseVisualStyleBackColor = true;
            this.btnInFiel.Click += new System.EventHandler(this.btnInFiel_Click);
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(98, 63);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(357, 21);
            this.txtoutput.TabIndex = 33;
            this.txtoutput.Text = "C:\\Users\\e_bagheri\\Documents\\VirastarE";
            this.toolTip1.SetToolTip(this.txtoutput, "مسیر پوشه خروجی را مشخص میکند\r\nفایلهای پردازش شده در این آدرس ذخیره میشود");
            // 
            // txtinput
            // 
            this.txtinput.Location = new System.Drawing.Point(98, 29);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(357, 21);
            this.txtinput.TabIndex = 32;
            this.txtinput.Text = "C:\\Users\\e_bagheri\\Documents\\VirastarE";
            this.toolTip1.SetToolTip(this.txtinput, "فایل با فرمت متنی ورودی را مشخص میکند");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "مسیر خروجی";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "مسیر ورودی";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmLDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 430);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLDA";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "استخراج عناوین(تاپیک مدلینگ)";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txttwords;
        private System.Windows.Forms.Label lbltwords;
        private System.Windows.Forms.TextBox txtniters;
        private System.Windows.Forms.Label lblniters;
        private System.Windows.Forms.TextBox txtsavestep;
        private System.Windows.Forms.Label lblsavestep;
        private System.Windows.Forms.TextBox txttopics;
        private System.Windows.Forms.Label lbltopics;
        private System.Windows.Forms.TextBox txtbeta;
        private System.Windows.Forms.Label lblbeta;
        private System.Windows.Forms.TextBox txtalpha;
        private System.Windows.Forms.Label lblalpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOutDir;
        private System.Windows.Forms.Button btnInFiel;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}