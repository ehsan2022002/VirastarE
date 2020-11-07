using System.Collections.Generic;
using System.Data;
using BrozoyaEntitys.EntityData;

namespace BrozoyaEntitys
{
    public class PS_VERB_FAOpration
    {

        GetBySQLLight gt;

        public PS_VERB_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PsVerbFa> GetAll()
        {
            List<PsVerbFa> tl = new List<PsVerbFa>();
            DataTable dt = gt.GetTableBySql("SELECT * FROM PS_VERB_FA");


            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                var x = new PsVerbFa();
                x.Val1 = item["VAL1"].ToString();
                x.Val2 = item["VAL2"].ToString();
                x.Val3 = item["VAL3"].ToString();
                x.Val4 = item["VAL4"].ToString();

                tl.Add(x);
            }

            return tl;
        }
    }
}
