using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balloon.NET
{
    public partial class CPPPunctuation : Balloon.NET.BalloonWindow
    {
        public string ShowFormWithMessage { set { this.lblMessage.Text = value; } }
        public bool IgnorePuc = false;
        public CPPPunctuation()
        {
            InitializeComponent();

        }


        private void CPPPunctuation_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblIgnorePuctuation_Click(object sender, EventArgs e)
        {
            //lblIgnorePuctuation
            this.IgnorePuc = true;
            CPPPunctuation_Deactivate(null, null);

        }
    }
}
