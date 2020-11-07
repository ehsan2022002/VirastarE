using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BorzoyaSpell;


namespace VirastarE.Forms
{
    public partial class Setting : Form
    {
        private readonly CheakSpell _cheakSpell;
        private List<string> _items = new List<string>();

        private readonly string valid = @"!:\.،؛؟»\]\)\}«\[\(\{-_&^#";

        public Setting(CheakSpell cheakSpell)
        {
            InitializeComponent();
            Util util = new Util();
            _cheakSpell = cheakSpell;

            chkRecSpell.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkRecSpell.Name) == Util.UtilSystemEnum.OnKey ? true : false;
            
            chkStemSpell.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkStemSpell.Name) == Util.UtilSystemEnum.OnKey ? true : false;
            chkPunkRec.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkPunkRec.Name) == Util.UtilSystemEnum.OnKey ? true : false;
            chkIgnoreEnglish.Checked =
                RegistaryApplicationSetting.GetRegistaryKey(chkIgnoreEnglish.Name) == Util.UtilSystemEnum.OnKey ? true : false;

            txtIgnoreList.Text = RegistaryApplicationSetting.GetRegistaryKey(Util.UtilSystemEnum.txtIgnoreList);


            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            var os = Environment.OSVersion;
            var ver = os.Version;

            lblSysinfo.Text = SystemInformation.ComputerName + Environment.NewLine
                                                             + SystemInformation.UserName + Environment.NewLine +
                                                             @"Resolution: " + screenWidth + @"x" + screenHeight +
                                                             Environment.NewLine + @"max DotNet Version:" +
                                                             util.GetVersionFromRegistry() + Environment.NewLine +
                                                             os.VersionString + @" " + os.Platform + " " + ver.Major;
        }


       

        private void Button1_Click(object sender, EventArgs e)
        {
            //_cheakSpell = new BorzoyaSpell.CheakSpell();
            var s = listBox1.SelectedItem.ToString();
            _cheakSpell.DeletebyName(s);
            listBox1.Items.Remove(s);
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
        }

        private void FindParsonalDic_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();


            foreach (var str in _cheakSpell.GetUserDIcByName(textBox1.Text))
                if (str.Trim().Length > 0)
                    listBox1.Items.Add(str);
            //items.Add(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VirastarE\";
            Process.Start("explorer.exe", folderPath);
        }


        private void chkRecSpell_CheckedChanged(object sender, EventArgs e)
        {
            var value = chkRecSpell.Checked ? Util.UtilSystemEnum.OnKey: Util.UtilSystemEnum.OffKey;

            RegistaryApplicationSetting.SetRegistaryKey(chkRecSpell.Name, value);
        }

        private void chkRecSpellCorrect_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkStemSpell_CheckedChanged(object sender, EventArgs e)
        {
            var value = chkStemSpell.Checked ? Util.UtilSystemEnum.OnKey : Util.UtilSystemEnum.OffKey;
            RegistaryApplicationSetting.SetRegistaryKey(chkStemSpell.Name, value);
            _cheakSpell.CheakSteem = chkStemSpell.Checked;
        }

        private void chkPunkRec_CheckedChanged(object sender, EventArgs e)
        {
            var value = chkPunkRec.Checked ? Util.UtilSystemEnum.OnKey : Util.UtilSystemEnum.OffKey;
            RegistaryApplicationSetting.SetRegistaryKey(chkPunkRec.Name, value);
        }

        private void chkIgnoreEnglish_CheckedChanged(object sender, EventArgs e)
        {
            var value = chkIgnoreEnglish.Checked ? Util.UtilSystemEnum.OnKey : Util.UtilSystemEnum.OffKey;
            _cheakSpell.IgnoreEnglish = chkIgnoreEnglish.Checked;
        }

        


        private void txtIgnoreList_TextChanged(object sender, EventArgs e)
        {
        }


        private void txtIgnoreList_Validating(object sender, CancelEventArgs e)
        {
            var bol = txtIgnoreList.Text.Trim().ToCharArray().Where(x => !valid.Contains(x));
            lblErr.Text = string.Empty;

            if (!bol.Any())
            {
                RegistaryApplicationSetting.SetRegistaryKey(Util.UtilSystemEnum.txtIgnoreList, txtIgnoreList.Text.Trim());
                _cheakSpell.IgnoreChars = txtIgnoreList.Text.Trim();
            }
            else
            {
                var result = new string(bol.ToArray());
                lblErr.Text = result + Util.UtilMessagesEnum.NotValid;
                e.Cancel = true;
            }
        }
    }
}