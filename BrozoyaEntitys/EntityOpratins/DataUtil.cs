using System.Collections.Generic;

namespace BrozoyaEntitys.EntityOpratins
{
    public class DataUtil
    {
        private readonly GetBySQLLight gt;

        public DataUtil()
        {
            gt = new GetBySQLLight();
        }

        //////////////////////
        public void InitSimilarityCash()
        {
            //read all data and save in list
        }

        public string GetWordSimilarity(string wrold, int lavel)
        {
            //if similaritycash.count =0 use sql   
            var r = gt.GetScalerBySql("select ifnull([key],'') as key from T_similarity_pos where value ='" + wrold +
                                      "' AND lavel=" + lavel);
            //elseS
            //use cash 
            if (r.Trim().Length == 0)
                r = wrold;

            return r;
        }

        public List<string> GetWordSimilarityList(List<string> wrolds, int lavel)
        {
            var l = new List<string>();

            foreach (var item in wrolds) l.Add(GetWordSimilarity(item, lavel));

            return l;
        }
    }
}