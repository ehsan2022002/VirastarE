
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys
{
   
    public class SC_DIC_FAOpration
    {
        GetBySQLLight gt;
        public SC_DIC_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<SC_DIC_FA> GetAll()
    {
            List<SC_DIC_FA> tl = new List<SC_DIC_FA>();
            DataTable dt = gt.GetTableBySQL("select * from SC_DIC_FA");
            
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                SC_DIC_FA RSC_DIC_FA = new SC_DIC_FA();

                RSC_DIC_FA.Id = int.Parse(item["Id"].ToString());
                RSC_DIC_FA.Val1 = item["Val1"].ToString();
                RSC_DIC_FA.val2 = item["val2"].ToString();
                
                tl.Add(RSC_DIC_FA);
            }

        return tl;
    }

    }
}
