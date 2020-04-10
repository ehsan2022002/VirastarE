namespace Balloon.NET
{
    partial class CPPSPell
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
            this.LsBoxWords = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LsBoxWords
            // 
            this.LsBoxWords.BackColor = System.Drawing.SystemColors.Info;
            this.LsBoxWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LsBoxWords.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LsBoxWords.FormattingEnabled = true;
            this.LsBoxWords.Items.AddRange(new object[] {
            "سلام",
            "سلامتی",
            "سلامت",
            "سلیم",
            "سار",
            "سارا"});
            this.LsBoxWords.Location = new System.Drawing.Point(9, 12);
            this.LsBoxWords.Name = "LsBoxWords";
            this.LsBoxWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LsBoxWords.Size = new System.Drawing.Size(168, 104);
            this.LsBoxWords.TabIndex = 0;
            this.LsBoxWords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LsBoxWords_MouseDown);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Info;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "____________________",
            "اضافه شود",
            "نادیده گرفتن",
            "همه نادیده گرفته شود"});
            this.listBox1.Location = new System.Drawing.Point(9, 115);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(168, 65);
            this.listBox1.TabIndex = 1;
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // CPPSPell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(191, 189);
            this.Controls.Add(this.LsBoxWords);
            this.Controls.Add(this.listBox1);
            this.Name = "CPPSPell";
            this.Text = "CPPSPell";
            this.Deactivate += new System.EventHandler(this.CPPSPell_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsBoxWords;
        private System.Windows.Forms.ListBox listBox1;
    }
}