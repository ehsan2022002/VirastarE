
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace VirastarE.Forms
{
    public partial class frmSetting : Form
    {
        List<string> items = new List<string>();
        BorzoyaSpell.CheakSpell _ck;

        string valid = @"!:\.،؛؟»\]\)\}«\[\(\{-_&^#";

        public frmSetting(BorzoyaSpell.CheakSpell ck)
        {
            InitializeComponent();
            this._ck = ck;
            
            this.chkRecSpell.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkRecSpell.Name) == "1"  ? true :false;
            
            trackBar1.Value = int.Parse(RegistaryApplicationSetting.GetRegistaryKey(trackBar1.Name) == "" ? "1" : RegistaryApplicationSetting.GetRegistaryKey(trackBar1.Name));
            this.chkStemSpell.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkStemSpell.Name) == "1" ? true : false;
            this.chkPunkRec.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkPunkRec.Name) == "1" ? true : false;
            this.chkIgnoreEnglish.Checked = RegistaryApplicationSetting.GetRegistaryKey(chkIgnoreEnglish.Name) == "1" ? true : false;

            txtIgnoreList.Text = RegistaryApplicationSetting.GetRegistaryKey("txtIgnoreList");


            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            OperatingSystem os = Environment.OSVersion;
            Version ver = os.Version;

            lblSysinfo.Text = SystemInformation.ComputerName + Environment.NewLine
                                + SystemInformation.UserName + Environment.NewLine +
                                 ("Resolution: " + screenWidth + "x" + screenHeight) + Environment.NewLine +
                                 "max DotNet Version:" + GetVersionFromRegistry() + Environment.NewLine +
                                 os.VersionString + " " + os.Platform.ToString() + " " + ver.Major.ToString();

        }


        private static string GetVersionFromRegistry()
        {
            String maxDotNetVersion = "";
            // Opens the registry key for the .NET Framework entry.
            using (RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "")
                                            .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                        {
                            Console.WriteLine(versionKeyName + "  " + name);
                            if (String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                        }
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                                if (String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                            {
                                sp = subKey.GetValue("SP", "").ToString();
                            }
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "")
                            {
                                //no install info, must be later.
                                Console.WriteLine(versionKeyName + "  " + name);
                                if (String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                            }
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                    if (String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                }
                                else if (install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name);
                                    if (String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                } // if
                            } // if
                        } // for
                    } // if
                } // foreach
            } // using
            return maxDotNetVersion;
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

            foreach (var str in _ck.GetUserDIcByName(textBox1.Text))
            {
                if (str.Trim().Length>0)
                    listBox1.Items.Add(str);
                //items.Add(str);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string Dirloc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VirastarE\";
            Process.Start("explorer.exe", Dirloc);

        }


        private void chkRecSpell_CheckedChanged(object sender, EventArgs e)
        {
            string value = chkRecSpell.Checked ? "1" : "0";
            RegistaryApplicationSetting.SetRegistaryKey(chkRecSpell.Name, value);
        }

        private void chkRecSpellCorrect_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkStemSpell_CheckedChanged(object sender, EventArgs e)
        {
            string value = chkStemSpell.Checked ? "1" : "0";
            RegistaryApplicationSetting.SetRegistaryKey(chkStemSpell.Name, value);
            _ck.CheakSteem = chkStemSpell.Checked;
                        
        }

        private void chkPunkRec_CheckedChanged(object sender, EventArgs e)
        {
            string value = chkPunkRec.Checked ? "1" : "0";
            RegistaryApplicationSetting.SetRegistaryKey(chkPunkRec.Name, value);            
        }

        private void chkIgnoreEnglish_CheckedChanged(object sender, EventArgs e)
        {
            string value = chkIgnoreEnglish.Checked ? "1" : "0";            
            _ck.IgnoreEnglish = chkIgnoreEnglish.Checked;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            RegistaryApplicationSetting.SetRegistaryKey(trackBar1.Name, trackBar1.Value.ToString());
            lblTackval.Text = trackBar1.Value.ToString();
            _ck.SpellLavel = trackBar1.Value;
        }



        private void txtIgnoreList_TextChanged(object sender, EventArgs e)
        {            
            
        }


        private void txtIgnoreList_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var bol = txtIgnoreList.Text.Trim().ToCharArray().Where(x => !valid.Contains(x));
            lblErr.Text = string.Empty;

            if (bol.Count() == 0)
            {
                RegistaryApplicationSetting.SetRegistaryKey("txtIgnoreList", txtIgnoreList.Text.Trim());
                _ck.IgnoreChars = txtIgnoreList.Text.Trim();
            }
            else
            {
                string result = new string(bol.ToArray());
                lblErr.Text = result.ToString() + " معتبر نیست ";
                e.Cancel = true;
             }
        }
    }



}

