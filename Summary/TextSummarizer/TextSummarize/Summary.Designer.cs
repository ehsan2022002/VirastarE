namespace TextSummarize
{
    partial class Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.btnStartAsyncOperation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSummary.Location = new System.Drawing.Point(12, 44);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(608, 184);
            this.txtSummary.TabIndex = 0;
            // 
            // txtKeywords
            // 
            this.txtKeywords.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtKeywords.Location = new System.Drawing.Point(12, 247);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeywords.Size = new System.Drawing.Size(608, 74);
            this.txtKeywords.TabIndex = 1;
            // 
            // btnStartAsyncOperation
            // 
            this.btnStartAsyncOperation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStartAsyncOperation.Location = new System.Drawing.Point(555, 15);
            this.btnStartAsyncOperation.Name = "btnStartAsyncOperation";
            this.btnStartAsyncOperation.Size = new System.Drawing.Size(65, 23);
            this.btnStartAsyncOperation.TabIndex = 2;
            this.btnStartAsyncOperation.Text = "پردازش";
            this.btnStartAsyncOperation.UseVisualStyleBackColor = true;
            this.btnStartAsyncOperation.Click += new System.EventHandler(this.BtnStartAsyncOperation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(571, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "کلیدواژها";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(181, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Location = new System.Drawing.Point(487, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TextSummarize.Properties.Resources.digitullCircles;
            this.pictureBox1.InitialImage = global::TextSummarize.Properties.Resources.loading_gears_animation_10;
            this.pictureBox1.Location = new System.Drawing.Point(88, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(12, 17);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbLang.Size = new System.Drawing.Size(70, 21);
            this.cmbLang.TabIndex = 7;
            // 
            // frmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(632, 333);
            this.Controls.Add(this.cmbLang);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartAsyncOperation);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.txtSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSummary";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "خلاصه ساز";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Button btnStartAsyncOperation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbLang;
    }
}