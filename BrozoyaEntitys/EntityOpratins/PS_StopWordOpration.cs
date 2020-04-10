using BrozoyaEntitys.EntityData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrozoyaEntitys.EntityOpratins
{
    public class PS_StopWordOpration
    {
        GetBySQLLight gt;
        public PS_StopWordOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PS_StopWord> GetAll()
        {
            List<PS_StopWord> tl = new List<PS_StopWord>();
            DataTable dt = gt.GetTableBySQL("select * from PS_StopWord");

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                PS_StopWord RSC_STOPWORD = new PS_StopWord();

               
                RSC_STOPWORD.Val1 = item["Val1"].ToString();                

                tl.Add(RSC_STOPWORD);
            }

            return tl;
        }
    }
}

