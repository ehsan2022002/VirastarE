using BrozoyaEntitys.EntityData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_PersianWordFrequencyOpration
    {

        GetBySQLLight gt;
        public PS_PersianWordFrequencyOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PS_PersianWordFrequency> GetAll()
        {
            List<PS_PersianWordFrequency> tl = new List<PS_PersianWordFrequency>();
            DataTable dt = gt.GetTableBySQL("select * from PS_PersianWordFrequency " );

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                PS_PersianWordFrequency DIC_PSWF = new PS_PersianWordFrequency();

                DIC_PSWF.Val1 = item["Val1"].ToString().Trim();
                DIC_PSWF.Val2 = item["Val2"].ToString().Trim();
                DIC_PSWF.Sundex = item["SUNDEX"].ToString().Trim();
                DIC_PSWF.Lavel = int.Parse(item["Lavel"].ToString().Trim());
                DIC_PSWF.Lexi = int.Parse(item["lexi"].ToString().Trim());

                tl.Add(DIC_PSWF);
            }

            return tl;
        }

        public void DeleteByName(string word)
        {
            try
            {
                var strsql = "delete from PS_PersianWordFrequency where val1='" + word.Replace("'", "") + "'";
                gt.SetBySQL(strsql);
            }
            catch
            {

            }

        }

        public void AddByName(string word)
        {
            try
            {

                var strsql = "INSERT INTO PS_PersianWordFrequency (val1, val2) VALUES ('" + word.Replace("'", "") +
                             "', '1')";
                gt.SetBySQL(strsql);
            }
            catch
            {

            }
        }
        public List<PS_PersianWordFrequency> GetByName(string word)
        {
            List<PS_PersianWordFrequency> tl = new List<PS_PersianWordFrequency>();
            DataTable dt = gt.GetTableBySQL("select * from PS_PersianWordFrequency where val1 ='" + word + "' " );

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                PS_PersianWordFrequency DIC_FA = new PS_PersianWordFrequency();

                DIC_FA.Val1 = item["Val1"].ToString().Trim();
                DIC_FA.Val2 = item["Val2"].ToString().Trim();

                tl.Add(DIC_FA);
            }

            return tl;

        }
    }
}