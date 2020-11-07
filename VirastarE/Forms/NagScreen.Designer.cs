namespace VirastarE.Forms
{
    partial class NagScreen
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
            this.UnloadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UnloadTimer
            // 
            this.UnloadTimer.Interval = 12000;
            this.UnloadTimer.Tick += new System.EventHandler(this.UnloadTimer_Tick);
            // 
            // NagScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VirastarE.Properties.Resources.virastari_3_final;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NagScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NagScreen";
            this.Click += new System.EventHandler(this.NagScreen_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UnloadTimer;
    }
}