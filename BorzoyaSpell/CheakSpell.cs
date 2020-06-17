using BorzoyaSpell.Suggests;
using BrozoyaEntitys.EntityData;
using BrozoyaEntitys.EntityOpratins;
using Stemming.Persian;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        static List<char> IgnoreCharList; 

        

        Soundex sundex;
        NorvigSpellChecker norvan;
        ////StringMatcher<String> strmatch;
        PS_PersianWordFrequencyOpration pwfo;
        Stemmer stm;


        int m_SpellLavel = 1;
        public int SpellLavel
        { 
            get { return m_SpellLavel; }
            set 
            {
                /// temp code for Corpus Prepration , now there
                //if (value!= m_SpellLavel)
                //{
                //    m_SpellLavel = 1; /// value;  //backward compatible
                //    GlobalDic.Clear();

                //    List<PS_PersianWordFrequency> l_pwfo;
                //    var pwfo = new PS_PersianWordFrequencyOpration(); //load from DB
                //    l_pwfo = pwfo.GetAllByLavel(m_SpellLavel);

                //    foreach (var item in l_pwfo.Where(x => x.Lavel == (m_SpellLavel )))
                //    {
                //        GlobalDic.Add(item.Val1.Trim());
                //    }

                //    sundex.PS_DIC_List = l_pwfo;
                //    norvan.FillDic(l_pwfo);
                //    stm.FillStm(l_pwfo);

                //} //change if
            }
        }

        public string IgnoreChars
        {
            get { 
                    return new string(IgnoreCharList.ToArray());
                }
            set {
                    IgnoreCharList.Clear();
                    IgnoreCharList.AddRange(value.ToCharArray());
                }
        }

        public bool CheakSteem;
        public bool IgnoreEnglish;

        public CheakSpell()
        {
            try
            {
                GlobalDic = new List<string>();
                UserDic = new List<string>();
                IgnoreList = new List<string>();
                StopWordList = new List<string>();
                IgnoreCharList = new List<char>();

                var pwfo = new PS_PersianWordFrequencyOpration(); //load from DB
                List<PS_PersianWordFrequency> l_pwfo;


                l_pwfo = pwfo.GetAllByLavel(m_SpellLavel);                
                sundex = new Soundex(l_pwfo.Where(x => x.Sundex.Length >0).ToList() );
                norvan = new NorvigSpellChecker(l_pwfo);
                stm = new Stemmer(l_pwfo);
                foreach (var item in l_pwfo)
                {
                    GlobalDic.Add(item.Val1.Trim());
                }


                var lsStop = new PS_StopWordOpration();


                foreach (var item in lsStop.GetAll())
                {
                    StopWordList.Add(item.Val1.Trim());
                }

                UserDicOpration udo = new UserDicOpration();
                UserDic = udo.LoadAll();

            }
            catch (Exception ex)
            { }
        }

        public bool Cheak_Spell(string mword )
       {
            bool b_return =false;
            bool stemmr = CheakSteem;
            string word = RemoveIjnoreChar(mword); 
            
            if (String.IsNullOrEmpty(word.Trim())) b_return = true;

            if (word.Any(char.IsDigit) ) b_return = true;

            if (isHtmlTag(word)) b_return = true;

            if (b_return == false)
                if (IgnoreEnglish==true && Regex.IsMatch(word, "^[a-zA-Z0-9]*$")) b_return = true;

            if (b_return == false)
                b_return = StopWordList.Contains(word);

            if (b_return==false)
                b_return = GlobalDic.Contains(word);

            if (b_return == false)
                b_return = UserDic.Contains(word);

            if (b_return == false && stemmr==true) //stemmrt
                b_return = GlobalDic.Contains(stm.run(word));

            return b_return;
        }

        private bool isHtmlTag(string word)
        {
            Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            // Match the regular expression pattern against a text string.
            MatchCollection m = r.Matches(word);
            return (m.Count > 0);
        }

        private string RemoveIjnoreChar(string word)
        {
            if (IgnoreChars.Count() > 0)
            {
                return  string.Concat(word.Where(c => !IgnoreChars.ToArray().Contains(c)));
            }
                return word;
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
            if (!UserDic.Contains(word) && word.Trim().Length>0)
            {
                UserDic.Add(word.Trim());
                UserDicOpration udo = new UserDicOpration();
                udo.Add(word.Trim());
            }
        }

        public bool isInIgnoreList(string word)
        {
            return IgnoreList.Where (x=>x.Contains(word)).Count() > 0 ;            
        }

        public void DeletebyName(string word)
        {
            UserDicOpration udo = new UserDicOpration();
            udo.Remove(word);
            UserDic.Remove(word); 
        }

        public List<string> GetUserDIcByName(string word)
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

