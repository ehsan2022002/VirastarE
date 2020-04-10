using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BrozoyaEntitys.EntityOpratins
{
    class ParaOpration
    {

        GetBySQLLight gt;
        public ParaOpration()
        {
            gt = new GetBySQLLight();
        }
        

        public void InsertPara(T_PARA PARA)
        {
            string sql = string.Empty;

            sql = "insert into T_PARA (ID,T_DOC_ID,PARA,SORT_ID)" +
                " values(" +
                "NULL,'" + PARA.T_DOC_ID + "','" + PARA.PARA + "','" + PARA.SORT_ID  + "')";

            gt.SetBySQL(sql);            
        }

        public void DelParaByID(T_PARA PARA)
        {
            string sql = string.Empty;

            sql = "delete from T_PARA where ID=" + PARA.Id;
            gt.SetBySQL(sql); 
        }

        public List<T_PARA> GetParaByDoc(T_Doc TDOC)
        {

            List<T_PARA> tl = new List<T_PARA>();
            DataTable dt = gt.GetTableBySQL("SELECT * from T_PARA where T_DOC_ID =" + TDOC.Id + "" );
            
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                T_PARA TPARA = new T_PARA();

                TPARA.Id = int.Parse(item["Id"].ToString());
                TPARA.T_DOC_ID = int.Parse(item["T_DOC_ID"].ToString());
                TPARA.PARA = item["PARA"].ToString();
                TPARA.SORT_ID = int.Parse(item["SORT_ID"].ToString());
                tl.Add(TPARA);
            }

            return tl;
        }
        

    }
}
