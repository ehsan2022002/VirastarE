using System.Collections.Generic;
using System.Data;
using BrozoyaEntitys.EntityData;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_MOKASSAR_FAOpration
    {
        GetBySQLLight gt;

        public PS_MOKASSAR_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PsMokassarFa> GetAll()
        {
            List<PsMokassarFa> tl = new List<PsMokassarFa>();
            DataTable dt = gt.GetTableBySql("SELECT ID,VAL1,VAL2 FROM PS_MOKASSAR_FA");

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                var x = new PsMokassarFa();
                x.Val1 = item["VAL1"].ToString();
                x.Val2 = item["VAL2"].ToString();

                tl.Add(x);
            }

            return tl;
        }
    }
}
