using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using BrozoyaEntitys;
using BrozoyaEntitys.EntityData;
using BrozoyaEntitys.EntityOpratins;
using Stemming;
using Stemming.Persian;

namespace PersianStemmer.Stemming.Persian
{
    public class Stemmer
    {
        public static Trie<int> lexicon = new Trie<int>();
        public static Trie<string> mokassarDic = new Trie<string>();
        public static Trie<string> cache = new Trie<string>();
        public static Trie<Verb> verbDic = new Trie<Verb>();
        public static List<Rule> _ruleList = new List<Rule>();

        private static readonly string[] VerbAffix =
            {"*ش", "*نده", "*ا", "*ار", "وا*", "اثر*", "فرو*", "پیش*", "گرو*", "*ه", "*گار", "*ن"};

        private static readonly string[] Suffix =
        {
            "كار", "ناك", "وار", "آسا", "آگین", "بار", "بان", "دان", "زار", "سار", "سان", "لاخ", "مند", "دار", "مرد",
            "کننده", "گرا", "نما", "متر"
        };

        private static readonly string[] Prefix = {"بی", "با", "پیش", "غیر", "فرو", "هم", "نا", "یک"};
        private static readonly string[] PrefixException = {"غیر"};
        private static readonly string[] SuffixZamir = {"م", "ت", "ش"};
        private static readonly string[] SuffixException = {"ها", "تر", "ترین", "ام", "ات", "اش"};

        //private static readonly string PATTERN_FILE_NAME = "Patterns.fa";
        //private static readonly string VERB_FILE_NAME = "VerbList.fa";
        //private static readonly string DIC_FILE_NAME = "Dictionary.fa";
        //private static readonly string MOKASSAR_FILE_NAME = "Mokassar.fa";

        private static readonly int patternCount = 1;
        private static readonly bool enableCache = true;
        private static readonly bool enableVerb = true;


        public Stemmer(List<PsPersianWordFrequency> pwfList)
        {
            //dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sBase); 
            //dataPath = Path.Combine(GetAssemblyDirectory(), sBase);

            FillStm(pwfList);
        }

        public Stemmer()
        {
        }

        //private static readonly ILog log = LogManager.GetLogger(typeof(Stemmer));
        private string DataPath { get; set; }


        public static string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public void FillStm(List<PsPersianWordFrequency> pwfList)
        {
            try
            {
                loadRule();
                loadLexicon(pwfList.Where(x => x.Lexi == 1).ToList());
                loadMokassarDic();
                if (enableVerb)
                    loadVerbDic();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

                //System.Console.WriteLine(ex.ToString());  
            }
        }

        //private string[] loadData(string resourceName)
        //{
        //    //try
        //    //{
        //        return File.ReadAllLines(dataPath + resourceName).Where(q => !string.IsNullOrWhiteSpace(q)).ToArray();
        //    //}
        //    //catch (Exception ex) {
        //    //    System.Console.WriteLine(ex.ToString()); 
        //    //}

        //   // return null;
        //}

        private void loadVerbDic()
        {
            if (!verbDic.IsEmpty())
                return;

            //string[] sLines = loadData(VERB_FILE_NAME);
            //string sql = string.Empty;
            var ls = new PS_VERB_FAOpration();

            foreach (var item in ls.GetAll())
                //string[] arr = sLine.Split('\t');
                try
                {
                    verbDic.Add(item.Val1.Trim(), new Verb(item.Val2.Trim(), item.Val3.Trim()));
                }
                catch
                {
                    //log.Warn("Verb " + sLine + " cannot be added. Is it duplicated?");
                }
        }

        private void loadRule()
        {
            if (_ruleList.Count != 0)
                return;

            var ls = new PS_PATTERN_FAOpration();

            foreach (var sLine in ls.GetAll())
                _ruleList.Add(new Rule(sLine.Val1, sLine.Val2, sLine.Val3[0],
                    byte.Parse(sLine.Val4), bool.Parse(sLine.Val5)));
        }

        private void loadLexicon(List<PsPersianWordFrequency> pwfList)
        {
            //var lsLexicon = new PS_Dictionary_FAOpration();

            if (!lexicon.IsEmpty())
                return;

            foreach (var sLine in pwfList) lexicon.Add(sLine.Val1.Trim(), 1);
        }

        private void loadMokassarDic()
        {
            var ls = new PS_MOKASSAR_FAOpration();

            if (!mokassarDic.IsEmpty())
                return;

            //string[] sLines = loadData(MOKASSAR_FILE_NAME);
            foreach (var item in ls.GetAll()) mokassarDic.Add(item.Val1.Trim(), item.Val2.Trim());
        }

        private string normalization(string s)
        {
            var newString = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
                switch (s[i])
                {
                    case 'ي':
                        newString.Append('ی');
                        break;
                    //case 'ة':
                    case 'ۀ':
                        newString.Append('ه');
                        break;
                    case '‌':
                        newString.Append(' ');
                        break;
                    case '‏':
                        newString.Append(' ');
                        break;
                    case 'ك':
                        newString.Append('ک');
                        break;
                    case 'ؤ':
                        newString.Append('و');
                        break;
                    case 'إ':
                    case 'أ':
                        newString.Append('ا');
                        break;
                    case '\u064B': //FATHATAN
                    case '\u064C': //DAMMATAN
                    case '\u064D': //KASRATAN
                    case '\u064E': //FATHA
                    case '\u064F': //DAMMA
                    case '\u0650': //KASRA
                    case '\u0651': //SHADDA
                    case '\u0652': //SUKUN
                        break;
                    default:
                        newString.Append(s[i]);
                        break;
                }

            return newString.ToString();
        }

        private bool validation(string sWord)
        {
            return lexicon.Contains(sWord);
        }

        private string IsMokassar(string sInput, bool bState)
        {
            var sRule = "^(?<stem>.+?)((?<=(ا|و))ی)?(ها)?(ی)?((ات)?( تان|تان| مان|مان| شان|شان)|ی|م|ت|ش|ء)$";
            if (bState)
                sRule = "^(?<stem>.+?)((?<=(ا|و))ی)?(ها)?(ی)?(ات|ی|م|ت|ش| تان|تان| مان|مان| شان|شان|ء)$";

            return extractStem(sInput, sRule);
        }

        private string GetMokassarStem(string sWord)
        {
            var sTemp = mokassarDic.ContainsKey(sWord);
            if (string.IsNullOrEmpty(sTemp))
            {
                var sNewWord = IsMokassar(sWord, true);
                sTemp = mokassarDic.ContainsKey(sNewWord);
                if (string.IsNullOrEmpty(sTemp))
                {
                    sNewWord = IsMokassar(sWord, false);
                    sTemp = mokassarDic.ContainsKey(sNewWord);
                    if (!string.IsNullOrEmpty(sTemp))
                        return sTemp;
                }
                else
                {
                    return sTemp;
                }
            }
            else
            {
                return sTemp;
            }

            return "";
        }

        private string VerbValidation(string sWord)
        {
            if (sWord.IndexOf(' ') > -1)
                return "";

            for (var j = 0; j < VerbAffix.Length; j++)
            {
                var sTemp = "";
                if (j == 0 && (sWord[sWord.Length - 1] == 'ا' || sWord[sWord.Length - 1] == 'و'))
                    sTemp = VerbAffix[j].Replace("*", sWord + "ی");
                else
                    sTemp = VerbAffix[j].Replace("*", sWord);

                if (NormalizeValidation(sTemp, true))
                    return VerbAffix[j];
            }

            return "";
        }

        private bool inRange(int d, int from, int to)
        {
            return d >= from && d <= to;
        }

        private string getPrefix(string sWord)
        {
            foreach (var sPrefix in Prefix)
                if (sWord.StartsWith(sPrefix))
                    return sPrefix;

            return "";
        }

        private string getPrefixException(string sWord)
        {
            foreach (var sPrefix in PrefixException)
                if (sWord.StartsWith(sPrefix))
                    return sPrefix;

            return "";
        }

        private string getSuffix(string sWord)
        {
            foreach (var sSuffix in Suffix)
                if (sWord.EndsWith(sSuffix))
                    return sSuffix;

            return "";
        }

        private bool NormalizeValidation(string sWord, bool bRemoveSpace)
        {
            var l = sWord.Trim().Length - 2;
            sWord = sWord.Trim();
            var result = validation(sWord);

            if (!result && sWord.IndexOf('ا') == 0) result = validation(replaceFirst(sWord, "ا", "آ"));

            if (!result && inRange(sWord.IndexOf('ا'), 1, l)) result = validation(sWord.Replace('ا', 'أ'));

            if (!result && inRange(sWord.IndexOf('ا'), 1, l)) result = validation(sWord.Replace('ا', 'إ'));

            if (!result && inRange(sWord.IndexOf("ئو"), 1, l)) result = validation(sWord.Replace("ئو", "ؤ"));

            if (!result && sWord.EndsWith("ء"))
                result = validation(sWord.Replace("ء", ""));

            if (!result && inRange(sWord.IndexOf("ئ"), 1, l))
                result = validation(sWord.Replace("ئ", "ی"));

            if (bRemoveSpace)
                if (!result && inRange(sWord.IndexOf(' '), 1, l))
                    result = validation(sWord.Replace(" ", ""));
            // دیندار
            // دین دار
            if (!result)
            {
                var sSuffix = getSuffix(sWord);
                if (!string.IsNullOrEmpty(sSuffix))
                    result = validation(sSuffix == "مند"
                        ? sWord.Replace(sSuffix, "ه " + sSuffix)
                        : sWord.Replace(sSuffix, " " + sSuffix));
            }

            if (!result)
            {
                var sPrefix = getPrefix(sWord);
                if (!string.IsNullOrEmpty(sPrefix))
                {
                    if (sWord.StartsWith(sPrefix + " "))
                        result = validation(sWord.Replace(sPrefix + " ", sPrefix));
                    else
                        result = validation(sWord.Replace(sPrefix, sPrefix + " "));
                }
            }

            if (!result)
            {
                var sPrefix = getPrefixException(sWord);
                if (!string.IsNullOrEmpty(sPrefix))
                {
                    if (sWord.StartsWith(sPrefix + " "))
                        result = validation(replaceFirst(sWord, sPrefix + " ", ""));
                    else
                        result = validation(replaceFirst(sWord, sPrefix, ""));
                }
            }

            return result;
        }

        public string replaceFirst(string word, string oldValue, string newValue)
        {
            var i = word.IndexOf(oldValue);
            if (i >= 0) return word.Substring(0, i) + newValue + word.Substring(i + oldValue.Length);
            return word;
        }

        private bool isMatch(string sInput, string sRule)
        {
            return Regex.IsMatch(sInput, sRule);
        }

        private string extractStem(string sInput, string sRule, string sReplacement)
        {
            return Regex.Replace(sInput, sRule, sReplacement).Trim();
        }

        private string extractStem(string sInput, string sRule)
        {
            return extractStem(sInput, sRule, "${stem}");
        }

        private string getVerb(string input)
        {
            var tmpNode = verbDic.FindNode(input);
            if (tmpNode != null && !string.IsNullOrEmpty(tmpNode.Key))
            {
                var vs = tmpNode.Value;
                if (validation(vs.GetPresent()))
                    return vs.GetPresent();

                return vs.GetPast();
            }

            return "";
        }

        private bool PatternMatching(string input, List<string> stemList)
        {
            var terminate = false;
            var s = "";
            var sTemp = "";
            foreach (var rule in _ruleList)
            {
                if (terminate)
                    return terminate;

                var sReplace = rule.GetSubstitution().Split(';');
                var pattern = rule.GetBody();

                if (!isMatch(input, pattern))
                    continue;

                var k = 0;
                foreach (var t in sReplace)
                {
                    if (k > 0)
                        break;

                    s = extractStem(input, pattern, t);
                    if (s.Length < rule.GetMinLength())
                        continue;

                    switch (rule.GetPoS())
                    {
                        case 'K': // Kasre Ezafe
                            if (stemList.Count == 0)
                            {
                                sTemp = GetMokassarStem(s);
                                if (!string.IsNullOrEmpty(sTemp))
                                {
                                    stemList.Add(sTemp); //, pattern + " [جمع مکسر]");
                                    k++;
                                }
                                else if (NormalizeValidation(s, true))
                                {
                                    stemList.Add(s); //, pattern);
                                    k++;
                                }
                            }

                            break;
                        case 'V': // Verb

                            sTemp = VerbValidation(s);
                            if (!string.IsNullOrEmpty(sTemp))
                            {
                                stemList.Add(s /* pattern + " : [" + sTemp + "]"*/);
                                k++;
                            }

                            break;
                        default:
                            if (NormalizeValidation(s, true))
                            {
                                stemList.Add(s /*, pattern*/);
                                if (rule.GetState())
                                    terminate = true;
                                k++;
                            }

                            break;
                    }
                }
            }

            return terminate;
        }


        public List<string> runList(List<string> ls)
        {
            var nsl = new List<string>();

            foreach (var item in ls) nsl.Add(run(item));

            return nsl;
        }

        public string run(string input)
        {
            input = normalization(input).Trim();

            if (string.IsNullOrEmpty(input))
                return "";

            //Integer or english 
            if (Utils.IsEnglish(input) || Utils.IsNumber(input) || input.Length <= 2)
                return input;

            if (enableCache)
            {
                var stm = cache.ContainsKey(input);
                if (!string.IsNullOrEmpty(stm))
                    return stm;
            }

            var s = GetMokassarStem(input);
            if (NormalizeValidation(input, false))
            {
                //stemList.add(input/*, "[فرهنگ لغت]"*/);
                if (enableCache)
                    cache.Add(input, input);
                return input;
            }

            if (!string.IsNullOrEmpty(s))
            {
                //addToLog(s/*, "[جمع مکسر]"*/);
                //stemList.add(s);
                if (enableCache)
                    cache.Add(input, s);
                return s;
            }

            var stemList = new List<string>();
            var terminate = PatternMatching(input, stemList);

            if (enableVerb)
            {
                s = getVerb(input);
                if (!string.IsNullOrEmpty(s))
                {
                    stemList.Clear();
                    stemList.Add(s);
                }
            }

            if (stemList.Count == 0)
            {
                if (NormalizeValidation(input, true))
                {
                    //stemList.add(input, "[فرهنگ لغت]");
                    if (enableCache)
                        cache.Add(input, input); //stemList.get(0));
                    return input; //stemList.get(0);
                }

                stemList.Add(input); //, "");            
            }

            if (terminate && stemList.Count > 1) return nounValidation(stemList);

            const int I = 0;
            if (patternCount != 0)
            {
                if (patternCount < 0)
                    stemList.Reverse();
                else
                    stemList.Sort();

                while (I < stemList.Count && stemList.Count > Math.Abs(patternCount))
                    stemList.RemoveAt(I);
                //patternList.remove(I);
            }

            if (enableCache)
                cache.Add(input, stemList[0]);
            return stemList[0];
        }

        /*private void addToLog(string sStem) {
        
            if (sStem.isEmpty() || stemList.contains(sStem)) 
                return;

            stemList.add(sStem);
            //patternList.add(sRule);
        }    */

        public int stem(char[] s, int len) /*throws Exception*/
        {
            var input = new StringBuilder();
            for (var i = 0; i < len; i++) input.Append(s[i]);
            var sOut = run(input.ToString());

            if (sOut.Length > s.Length)
                s = new char[sOut.Length];
            for (var i = 0; i < sOut.Length; i++) s[i] = sOut[i];
            /*try {
                for (int i=0; i< Math.min(sOut.length(), s.length); i++) {
                    s[i] = sOut.charAt(i);
                }    
            }
            catch (Exception e) {
                throw new Exception("stem: "+sOut+" - input: "+ input.toString());
            }*/

            return sOut.Length;
        }

        private string nounValidation(List<string> stemList)
        {
            stemList.Sort();
            var lastIdx = stemList.Count - 1;
            var lastStem = stemList[lastIdx];

            if (lastStem.EndsWith("ان")) return lastStem;

            var firstStem = stemList[0];
            var secondStem = stemList[1].Replace(" ", "");

            /*if (secondStem.equals(firstStem.concat("م"))) {
                    return firstStem;
                }
                else if (secondStem.equals(firstStem.concat("ت"))) {
                    return firstStem;
                }
                else if (secondStem.equals(firstStem.concat("ش"))) {
                    return firstStem;
                }*/

            foreach (var sSuffix in SuffixZamir)
                if (secondStem.Equals(firstStem + sSuffix))
                    return firstStem;
            return lastStem;
        }
    }
}