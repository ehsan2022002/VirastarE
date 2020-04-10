using BorzoyaSpell.Suggests;
using BrozoyaEntitys.EntityOpratins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace BorzoyaSpell
{
    public class CheakSpell
    {

        static List<string> GlobalDic;
        static List<string> StopWordList;
        static List<string> UserDic;
        static List<string> IgnoreList;


        Soundex sundex;
        NorvigSpellChecker norvan;
        //StringMatcher<String> strmatch;
        PS_PersianWordFrequencyOpration pwfo;
        

        //private static StringMatcher<String> _stringMatcher = new StringMatcher<String>();
        public CheakSpell()
        {
            try
            {
                GlobalDic = new List<string>();
                UserDic = new List<string>();
                IgnoreList = new List<string>();
                StopWordList = new List<string>();

                var pwfo = new PS_PersianWordFrequencyOpration(); //load from DB
                var lsStop = new PS_StopWordOpration();

                sundex = new Soundex();
                norvan = new NorvigSpellChecker();
                //strmatch = new StringMatcher<String>();
                
                foreach (var item in pwfo.GetAll())
                {
                    GlobalDic.Add(item.Val1.Trim());
                }

                foreach (var item in lsStop.GetAll())
                {
                    StopWordList.Add(item.Val1.Trim());
                }

            }
            catch (Exception ex)
            { }
        }

        public bool Cheak_Spell(string word)
        {
            bool b_return =false;

            if (String.IsNullOrEmpty(word.Trim())) b_return = true;

            if (word.Any(char.IsDigit) ) b_return = true;
            if (isHtmlTag(word)) b_return = true;

            if (b_return == false)
                b_return = StopWordList.Contains(word);

            if (b_return==false)
                b_return = GlobalDic.Contains(word);

            if (b_return == false)
                b_return = UserDic.Contains(word);
            return b_return;
        }

        private bool isHtmlTag(string word)
        {
            Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            // Match the regular expression pattern against a text string.
            MatchCollection m = r.Matches(word);
            return (m.Count > 0);
        }

        public List<string> Suggest(string word)
        {
            List<string> ls = new List<string>();

            ls.Add(norvan.Correct(word));
            ls.AddRange(sundex.GetSuggest(word).Where(x=>x.StartsWith(word.Substring(0,2))).Take(4).Except(ls)) ;
            
            return ls;

        }

        public void AddToIgnoreList(string word)
        {
            IgnoreList.Add(word);
        }

        public void AddtoUserDic(string word)
        {
            UserDic.Add(word.Trim());

            UserDicOpration udo = new UserDicOpration();

            udo.Add(word.Trim());
        }

        public bool isInIgnoreList(string word)
        {
            return IgnoreList.Contains(word);            
        }

        public void DeletebyName(string word)
        {
            UserDicOpration udo = new UserDicOpration();
            udo.Remove(word);
            UserDic.Remove(word); 
        }

        public List<string> GetByName(string word)
        {            
            //l = GlobalDic.AsParallel().Where(s => s.Contains(word)).ToList();

            UserDicOpration udo = new UserDicOpration();

            if (word.Trim().Length > 0)
            {
                return udo.LoadAll().Where(s => s.Contains(word)).ToList();
            }
            else
                return udo.LoadAll();

        }
    }
}

