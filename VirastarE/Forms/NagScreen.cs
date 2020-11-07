using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Close();
        }

        private void NagScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
