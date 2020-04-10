using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozoyaEntitys.EntityOpratins
{
    public class DocTreeOpration
    {
        GetBySQLLight gt;

        public DocTreeOpration()
        {
            gt = new GetBySQLLight();
        }

        public List<T_DocTree> GetDocTreeByPID(string PID)
        {

            List<T_DocTree> tl = new List<T_DocTree>();
            DataTable dt = gt.GetTableBySQL("SELECT * from T_DocTree where PID="+ PID);


            foreach (DataRow item in dt.Rows)  //loop through the columns. 
            {
                T_DocTree TDocTree = new T_DocTree();

                TDocTree.Id = int.Parse(item["Id"].ToString());                
                TDocTree.PId = int.Parse(item["pId"].ToString());                
                TDocTree.NodeTitle = item["NodeTitle"].ToString();
                TDocTree.NodeType = int.Parse(item["NodeType"].ToString());
                
                tl.Add(TDocTree);
            }
            return tl;
        }

        public int AddNodeAndGetId(T_DocTree DT)
        {
            // string sql = "SELECT last_insert_rowid()";            
            gt.SetBySQL("INSERT INTO T_DOCTREE	(ID,PID, NodeTitle, NodeType)VALUES (null,"+ DT.PId + ",' "+ DT.NodeTitle + "', '"+ DT.NodeType.ToString() +"')");
            return int.Parse(gt.GetLastInsertID("T_DOCTREE"));
        }

        public void UpdateTitle(T_DocTree DT)
        {        
            gt.SetBySQL("UPDATE	T_DOCTREE SET NodeTitle='" + DT.NodeTitle + "' WHERE ID=" + DT.Id );            
        }

        public void DeleteById(T_DocTree DT)
        {
            if (DT.Id == 0 || DT.Id == 1)
                return;

            gt.SetBySQL("DELETE FROM T_DOCTREE WHERE ID=" + DT.Id);            
        }

    }
}
