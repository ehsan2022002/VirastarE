using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BorzoyaSpell.Suggests;
using BorzoyaSpell.Suggests.Norvig;
using BorzoyaSpell.Suggests.Soundex;
using BrozoyaEntitys.EntityData;
using BrozoyaEntitys.EntityOpratins;
using PersianStemmer.Stemming.Persian;
using Stemming.Persian;

namespace BorzoyaSpell
{
    public class CheakSpell
    {
        private static List<string> _globalDic;
        private static List<string> _stopWordList;
        private static List<string> _userDic;
        private static List<string> _ignoreList;
        private static List<char> _ignoreCharList;
        private readonly NorvigSpellChecker _norvan;
        //private PS_PersianWordFrequencyOpration _parsianWordFreqOpratiom;
        private readonly Stemmer _stemmr;


        private readonly Soundex _sundex;

        public bool CheakSteem;
        public bool IgnoreEnglish;

        public CheakSpell()
        {
            try
            {
                _globalDic = new List<string>();
                _userDic = new List<string>();
                _ignoreList = new List<string>();
                _stopWordList = new List<string>();
                _ignoreCharList = new List<char>();

                var persianWordFrequencyOpration = new PS_PersianWordFrequencyOpration(); //load from DB


                var listParsianWordfreq = persianWordFrequencyOpration.GetAll();
                _sundex = new Soundex(listParsianWordfreq.Where(x => x.Sundex.Length > 0).ToList());
                _norvan = new NorvigSpellChecker(listParsianWordfreq);
                _stemmr = new Stemmer(listParsianWordfreq);
                foreach (var item in listParsianWordfreq) _globalDic.Add(item.Val1.Trim());


                var lsStop = new PS_StopWordOpration();


                foreach (var item in lsStop.GetAll()) _stopWordList.Add(item.Val1.Trim());

                var userDicOpration = new UserDicOpration();
                _userDic = userDicOpration.LoadAll();
            }
            catch (Exception)
            {
                // ignored
            }
        }


        //int m_SpellLavel = 1;
        //public int SpellLavel
        //{
        //    get { return m_SpellLavel; }
        //    set
        //    {
        //    }
        //}

        public string IgnoreChars
        {
            get => new string(_ignoreCharList.ToArray());
            set
            {
                _ignoreCharList.Clear();
                _ignoreCharList.AddRange(value.ToCharArray());
            }
        }

        public bool Cheak_Spell(string mword)
        {
            var bReturn = false;
            var bStemmr = CheakSteem;
            var word = RemoveIjnoreChar(mword);

            if (string.IsNullOrEmpty(word.Trim())) bReturn = true;

            if (word.Any(char.IsDigit)) bReturn = true;

            if (isHtmlTag(word)) bReturn = true;

            if (bReturn == false)
                if (IgnoreEnglish && Regex.IsMatch(word, "^[a-zA-Z0-9]*$"))
                    bReturn = true;

            if (bReturn == false)
                bReturn = _stopWordList.Contains(word);

            if (bReturn == false)
                bReturn = _globalDic.Contains(word);

            if (bReturn == false)
                bReturn = _userDic.Contains(word);

            if (bReturn == false && bStemmr) //stemmrt
                bReturn = _globalDic.Contains(_stemmr.run(word));

            return bReturn;
        }

        private bool isHtmlTag(string word)
        {
            var r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            // Match the regular expression pattern against a text string.
            var m = r.Matches(word);
            return m.Count > 0;
        }

        private string RemoveIjnoreChar(string word)
        {
            if (IgnoreChars.Any()) return string.Concat(word.Where(c => !IgnoreChars.ToArray().Contains(c)));
            return word;
        }

        public List<string> Suggest(string word)
        {
            var suggestList = new List<string> {_norvan.Correct(word)};

            suggestList.AddRange(_sundex.GetSuggest(word).Where(x => x.StartsWith(word.Substring(0, 2))).Take(4).Except(suggestList));

            return suggestList;
        }

        public void AddToIgnoreList(string word)
        {
            _ignoreList.Add(word);
        }

        public void AddtoUserDic(string word)
        {
            if (!_userDic.Contains(word) && word.Trim().Length > 0)
            {
                _userDic.Add(word.Trim());
                var udo = new UserDicOpration();
                udo.Add(word.Trim());
            }
        }

        public bool IsInIgnoreList(string word)
        {
            return _ignoreList.Where(x => x.Contains(word)).Count() > 0;
        }

        public void DeletebyName(string word)
        {
            var udo = new UserDicOpration();
            udo.Remove(word);
            _userDic.Remove(word);
        }

        public List<string> GetUserDIcByName(string word)
        {
            //l = _globalDic.AsParallel().Where(s => s.Contains(word)).ToList();

            var userDicOpration = new UserDicOpration();

            if (word.Trim().Length > 0)
                return userDicOpration.LoadAll().Where(s => s.Contains(word)).ToList();
            return userDicOpration.LoadAll();
        }
    }
}