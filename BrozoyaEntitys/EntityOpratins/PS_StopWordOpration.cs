using System.Collections.Generic;
using System.Data;
using BrozoyaEntitys.EntityData;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_StopWordOpration
    {
        GetBySQLLight gt;
        public PS_StopWordOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PsStopWord> GetAll()
        {
            List<PsStopWord> tl = new List<PsStopWord>();
            DataTable dt = gt.GetTableBySql("select * from PS_StopWord");

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                PsStopWord RSC_STOPWORD = new PsStopWord();


                RSC_STOPWORD.Val1 = item["Val1"].ToString();

                tl.Add(RSC_STOPWORD);
            }

            return tl;
        }
    }
}

