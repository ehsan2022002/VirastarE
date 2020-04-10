using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_Dictionary_FAOpration
    {
        GetBySQLLight gt;
        public PS_Dictionary_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PS_Dictionary_FA> GetAll()
        {
            List<PS_Dictionary_FA> tl = new List<PS_Dictionary_FA>();
            DataTable dt = gt.GetTableBySQL("select * from PS_Dictionary_FA");

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                PS_Dictionary_FA RSC_DIC_FA = new PS_Dictionary_FA();

                RSC_DIC_FA.Id = int.Parse(item["Id"].ToString());
                RSC_DIC_FA.Val1 = item["Val1"].ToString();
                RSC_DIC_FA.Sundex = item["sundex"].ToString();

                tl.Add(RSC_DIC_FA);
            }

            return tl;
        }
    }
}
