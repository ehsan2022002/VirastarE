
using System.Collections.Generic;
using System.Data;

namespace BrozoyaEntitys
{
    public class DataUtil
    {
        GetBySQLLight gt;

        public DataUtil()
        {
            gt = new GetBySQLLight();
        }
      
        //////////////////////
        public void initSimilarityCash()
        {
            //read all data and save in list
        }
        public string GetWordSimilarity(string Wrold, int Lavel)
        {
            //if similaritycash.count =0 use sql   
            string r = gt.GetScalerBySQL("select ifnull([key],'') as key from T_similarity_pos where value ='" + Wrold + "' AND lavel=" + Lavel );
            //elseS
            //use cash 
            if (r.Trim().Length == 0)
                r = Wrold;

            return r;
        }        
        public List<string> GetWordSimilarityList(List<string> Wrolds, int Lavel)
        {
            var l = new List<string>();

            foreach (var item in Wrolds)
            {
                l.Add( GetWordSimilarity(item, Lavel));
            }

            return l;
        }

    }
}
