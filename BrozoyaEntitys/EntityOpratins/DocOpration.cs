using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozoyaEntitys.EntityOpratins
{
    public class DocOpration
    {
        GetBySQLLight gt;

        public DocOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<T_Doc> GetDocAll()
        {

            List<T_Doc> tl = new List<T_Doc>();
            DataTable dt = gt.GetTableBySQL("SELECT * from T_Doc");

            
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                T_Doc TDoc = new T_Doc();

                TDoc.Id = int.Parse(item["Id"].ToString());
                TDoc.DocTitle = item["DocTitle"].ToString();
                TDoc.Doc = item["Doc"].ToString();
                TDoc.FullDoc = item["FullDoc"].ToString();
                TDoc.CreateDate = item["CreateDate"].ToString();
                TDoc.InsetDate = item["InsetDate"].ToString();
                TDoc.UserID = item["UserID"].ToString();
                TDoc.Address = item["Address"].ToString();
                TDoc.Keywords = item["Keywords"].ToString();
                TDoc.DOCTREE_ID = int.Parse(item["DOCTREE_ID"].ToString());

                tl.Add(TDoc);
            }

            return tl;
        }

        public T_Doc GetDocByID(int ID)
        {

            DataTable dt = gt.GetTableBySQL("SELECT * from T_Doc where ID=" + ID.ToString());

            T_Doc TDoc = new T_Doc();
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                TDoc.Id = int.Parse(item["Id"].ToString());
                TDoc.DocTitle = item["DocTitle"].ToString();
                TDoc.Doc = item["Doc"].ToString();
                TDoc.FullDoc = item["FullDoc"].ToString();
                TDoc.CreateDate = item["CreateDate"].ToString();
                TDoc.InsetDate = item["InsetDate"].ToString();
                TDoc.UserID = item["UserID"].ToString();
                TDoc.Address = item["Address"].ToString();
                TDoc.Keywords = item["Keywords"].ToString();
                TDoc.DOCTREE_ID = int.Parse(item["DOCTREE_ID"].ToString());
            }
            return TDoc;
        }

        public List<T_Doc> GetDocBy_DOCTREE_ID(string DOCTREE_ID)
        {

            DataTable dt = gt.GetTableBySQL("SELECT * from T_Doc where DOCTREE_ID=" + DOCTREE_ID + " order by id");
            List<T_Doc> tl = new List<T_Doc>();
            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                T_Doc TDoc = new T_Doc();

                TDoc.Id = int.Parse(item["Id"].ToString());
                TDoc.DocTitle = item["DocTitle"].ToString();
                TDoc.Doc = item["Doc"].ToString();
                TDoc.FullDoc = item["FullDoc"].ToString();
                TDoc.CreateDate = item["CreateDate"].ToString();
                TDoc.InsetDate = item["InsetDate"].ToString();
                TDoc.UserID = item["UserID"].ToString();
                TDoc.Address = item["Address"].ToString();
                TDoc.Keywords = item["Keywords"].ToString();
                TDoc.DOCTREE_ID = int.Parse(item["DOCTREE_ID"].ToString());

                tl.Add(TDoc);
            }

            return tl;
        }
        public void InsertDoc(T_Doc Tdoc)
        {
            string sql = string.Empty;

            sql = "insert into t_doc (DocTitle,Doc,CreateDate,InsetDate,UserID,Address,Keywords,DOCTREE_ID,FullDoc)" +
                " values(" +
                "'" + Tdoc.DocTitle + "','" +  Tdoc.Doc + "','" + Tdoc.CreateDate + "','" + Tdoc.InsetDate +
                "','" + Tdoc.UserID + "','" + Tdoc.Address + "','" + Tdoc.Keywords + "','" + Tdoc.DOCTREE_ID + "','" +
                Tdoc.FullDoc + "')";
            gt.SetBySQL(sql);

            if (Tdoc.blobDoc != null)
            {
                sql = "Update t_doc SET blobData = @img where ID=" + gt.GetLastInsertID("T_Doc");
                gt.SetBlob(sql, Tdoc.blobDoc);
            }

        }



        public void UpdateDoc(T_Doc Tdoc)
        {
            string sql = string.Empty;
            sql = "update t_doc set " +
                " DocTitle='" + Tdoc.DocTitle + "'," +
                " Doc='" + Tdoc.Doc + "'," +
                " CreateDate ='" + Tdoc.CreateDate + "'," +
                " InsetDate ='" + Tdoc.InsetDate + "'," +
                " UserID ='" + Tdoc.UserID + "'," +
                " Address ='" + Tdoc.Address + "'," +
                " Keywords ='" + Tdoc.Keywords + "'," +
                " DOCTREE_ID ='" + Tdoc.DOCTREE_ID + "'," +
                " FullDoc ='" + Tdoc.FullDoc + "'" +
                " Where ID=" + Tdoc.Id;
            
            gt.SetBySQL(sql);

        }
        public void DelDoc(T_Doc Tdoc)
        {
            string sql = string.Empty;
            sql = "delete from t_doc  where ID=" + Tdoc.Id;
            gt.SetBySQL(sql);

        }

        public void UpdatePID(T_Doc Tdoc, T_DocTree NewTdoctree)
        {
            string sql = string.Empty;
            sql = "update t_doc set " + " DOCTREE_ID ='" + NewTdoctree.Id + "' " + "  where ID=" + Tdoc.Id;
            gt.SetBySQL(sql);
        }

        public byte[] GetDocBlobBy(T_Doc Tdoc)
        {
            return gt.GetBlobByID("SELECT blobData FROM t_doc WHERE Id="+ Tdoc.Id);

        }
        

    }
}
