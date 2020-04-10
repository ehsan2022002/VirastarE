
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VirastarE.Forms
{
    public partial class frmSetting : Form
    {
        List<string> items = new List<string>();
        BorzoyaSpell.CheakSpell _ck;

        public frmSetting(BorzoyaSpell.CheakSpell ck)
        {
            InitializeComponent();
            this._ck = ck;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //_ck = new BorzoyaSpell.CheakSpell();
            string s = listBox1.SelectedItem.ToString();
            _ck.DeletebyName(s);
            listBox1.Items.Remove(s);

        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //_ck= new BorzoyaSpell.CheakSpell();

            foreach (var str in _ck.GetByName(textBox1.Text))
            {
                listBox1.Items.Add(str);
                //items.Add(str);
            }

        }


    }



}

