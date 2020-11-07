namespace BrozoyaEntitys
{
    public class SettingOprtion
    {
        private readonly GetBySQLLight gt;

        public SettingOprtion()
        {
            gt = new GetBySQLLight();
        }

        public string GetValueByKey(string key)
        {
            return gt.GetScalerBySql("select Value from T_Setting where [Key]='" + key + "'");
        }

        public bool GetValueByKeyChk(string key)
        {
            var t = gt.GetScalerBySql("select Value from T_Setting where [Key]='" + key + "'");

            if (t == "1")
                return true;
            return false;
        }

        public void SetValueByKey(string key, string value)
        {
            var s = string.Empty;
            s = "update T_Setting set Value='" + value + "' where key='" + key + "'";
            gt.SetBySql(s);
        }

        public void SetValueByKey(string key, bool value)
        {
            var t = string.Empty;
            if (value)
                t = "1";
            else
                t = "0";


            var s = string.Empty;
            s = "update T_Setting set Value='" + t + "' where key='" + key + "'";
            gt.SetBySql(s);
        }
    }
}