using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozoyaEntitys
{
    public class SettingOprtion
    {
        GetBySQLLight gt;
        
        public SettingOprtion()
        {
            gt = new GetBySQLLight();
        }

        public string GetValueByKey(string Key)
        {
            return gt.GetScalerBySQL("select Value from T_Setting where [Key]='" + Key + "'" );            
        }

        public bool GetValueByKeyChk(string Key)
        {
            var t= gt.GetScalerBySQL("select Value from T_Setting where [Key]='" + Key + "'");

            if (t == "1")
                return true;
            else
                return false;
            
        }

        public void SetValueByKey(string Key, string Value)
        {
            string s = string.Empty;
            s = "update T_Setting set Value='" + Value + "' where key='" +  Key + "'";
            gt.SetBySQL(s);
        }

        public void SetValueByKey(string Key, bool Value)
        {
            string t = string.Empty;
            if (Value == true)
                t = "1";
            else
                t = "0";


            string s = string.Empty;
            s = "update T_Setting set Value='" + t + "' where key='" + Key + "'";
            gt.SetBySQL(s);
        }



    }
}
