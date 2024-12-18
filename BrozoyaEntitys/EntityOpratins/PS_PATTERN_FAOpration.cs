﻿using System.Collections.Generic;
using System.Data;
using BrozoyaEntitys.EntityData;

namespace BrozoyaEntitys
{
    public class PS_PATTERN_FAOpration
    {

        GetBySQLLight gt;

        public PS_PATTERN_FAOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<PsPatternFa> GetAll()
        {
            List<PsPatternFa> tl = new List<PsPatternFa>();
            DataTable dt = gt.GetTableBySql("SELECT * FROM PS_PATTERN_FA");

            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                var x = new PsPatternFa();
                x.Val1 = item["VAL1"].ToString();
                x.Val2 = item["VAL2"].ToString();
                x.Val3 = item["VAL3"].ToString();
                x.Val4 = item["VAL4"].ToString();
                x.Val5 = item["VAL5"].ToString();

                tl.Add(x);
            }

            return tl;
        }
    }
}
