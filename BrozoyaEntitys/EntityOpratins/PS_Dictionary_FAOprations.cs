using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_Dictionary_FAOprations
    {

        GetBySQLLight gt;

        public PS_Dictionary_FAOprations()
        {
            gt = new GetBySQLLight();
        }

        public List<PS_VERB_FA> GetAll()
        {
            List<PS_VERB_FA> tl = new List<PS_VERB_FA>();
            DataTable dt = gt.GetTableBySQL("SELECT ID,VAL1 FROM PS_Dictionary_FA");


            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                var x = new PS_VERB_FA();
                x.Val1 = item["VAL1"].ToString();
                tl.Add(x);
            }

            return tl;
        }

    }
}
