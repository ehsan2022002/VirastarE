using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Balloon.NET
{
    public partial class CPPSPell : Balloon.NET.BalloonWindow
    {
        public CPPSPell()
        {
            InitializeComponent();
        }
        
        public void ShowDlg(List<string> Words)
        {
            LsBoxWords.Items.Clear();
            foreach (var item in Words)
            {
                LsBoxWords.Items.Add(item.ToString());
            }
        }

        private void CPPSPell_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            //this.Visible = false;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //index 2 ignore
                //index 1 add
                if (index ==2)
                    IsIgnored = true;

                if (index == 1)
                    IsAdd = true;

                if (index == 3)
                    IsIgnoreAll = true;
            }
            this.Visible = false;
            //CPPSPell_Deactivate(null, null);
        }

        //////////////////////////////////////////////////////
        public bool IsIgnored = false;
        public bool IsIgnoreAll = false;
        public bool IsAdd = false;
        public bool IsSelect = false;

        public string SelectedWord = string.Empty;
        private void LsBoxWords_MouseDown(object sender, MouseEventArgs e)
        {

            int index = this.LsBoxWords.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                IsSelect = true;
                SelectedWord = LsBoxWords.SelectedItem.ToString();
            }

            this.Visible = false;
            //CPPSPell_Deactivate(null, null);

        }
    }
}
