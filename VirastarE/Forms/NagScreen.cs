using System;
using System.Windows.Forms;

namespace VirastarE.Forms
{
    public partial class NagScreen : Form
    {
        public NagScreen()
        {
            InitializeComponent();
            UnloadTimer.Enabled = true;
        }

        private void UnloadTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void NagScreen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}