using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_MOKASSAR_FAOpration
    {
        GetBySQLLight gt;

        public PS_MOKASSAR_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PS_MOKASSAR_FA> GetAll()
        {
            List<PS_MOKASSAR_FA> tl = new List<PS_MOKASSAR_FA>();
            DataTable dt = gt.GetTableBySQL("SELECT ID,VAL1,VAL2 FROM PS_MOKASSAR_FA");
            
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                var x = new PS_MOKASSAR_FA();
                x.Val1 = item["VAL1"].ToString();
                x.Val2 = item["VAL2"].ToString();

                tl.Add(x);
            }

            return tl;
        }
    }
}
