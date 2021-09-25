using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using BorzoyaSpell;
using NUnit.Framework;

namespace UnitTestProjectDataGen
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AppendRandomChar()
        {
            AlfaBet ab = new AlfaBet();
            string myWord = "غبار";
            string s = ab.GetRandomFarsiChar(1);

            Debug.Print(s);

            //append random char/string in text 
            var r = new Random();
            int i = r.Next(1, myWord.Trim().Length);

            char[] array = myWord.ToCharArray();

            string result = myWord.Substring(0, i) + s + myWord.Substring(i);

            Debug.Print(result);

            Assert.Pass();
        }


        [Test]
        public void SwapChar()
        {
            AlfaBet ab = new AlfaBet();
            string myWord = "غبار";
            var r = new Random();
            int i = r.Next(1, myWord.Trim().Length);

            string result = ab.SwapChars(myWord, i - 1);

            Debug.Print(result);


            Assert.Pass();
        }

        [Test]
        public void DeleteChar()
        {
            AlfaBet ab = new AlfaBet();
            var r = new Random();
            string myWord = "غبار";

            int i = r.Next(1, myWord.Trim().Length);
            string result = ab.DeleteChar(myWord, i);
            Debug.Print(result);


            Assert.Pass();
        }


        [Test]
        public void DubleChar()
        {
            AlfaBet ab = new AlfaBet();
            var r = new Random();
            string myWord = "غبار";

            int i = r.Next(1, myWord.Trim().Length);
            string result = ab.RepeatChars(myWord, i);
            Debug.Print(result);


            Assert.Pass();
        }


        [Test]
        private void MakeFailFile()
        {
            //read word file. 
            // run each algoritem 
            //save  word . new_word 
            string myWord;
            AlfaBet ab = new AlfaBet();
            var r = new Random();
            string result;
            int i = 0;

            var f= File.ReadAllLines(Environment.CurrentDirectory + @"\..\..\File\correct_word.txt");

            foreach (var l in f)
            {
                if (l.Length > 2)
                {
                    myWord = l.ToString();
                    string mychar = ab.GetRandomFarsiChar(1);
                    //string myWord = "تستی";
                    char[] array = myWord.ToCharArray();
                    i = r.Next(1, myWord.Trim().Length);
                    result = myWord.Substring(0, i) + mychar + myWord.Substring(i);
                    File.AppendAllText(Environment.CurrentDirectory + @"\..\..\File\All_word.txt",
                        l + @"," + result + Environment.NewLine);




                    i = r.Next(1, myWord.Trim().Length);
                    result = ab.SwapChars(myWord, i - 1);
                    File.AppendAllText(Environment.CurrentDirectory + @"\..\..\File\All_word.txt",
                        l + @"," + result + Environment.NewLine);



                    i = r.Next(1, myWord.Trim().Length);
                    result = ab.DeleteChar(myWord, i);
                    File.AppendAllText(Environment.CurrentDirectory + @"\..\..\File\All_word.txt",
                        l + @"," + result + Environment.NewLine);



                    i = r.Next(1, myWord.Trim().Length);
                    result = ab.RepeatChars(myWord, i);
                    File.AppendAllText(Environment.CurrentDirectory + @"\..\..\File\All_word.txt",
                        l + @"," + result + Environment.NewLine);


                }
            }

            Assert.Pass();

        }


        [Test]
        public void DeleteCorrectWords()
        {
            var _chkSpell = new CheakSpell();
            var f = File.ReadAllLines(Environment.CurrentDirectory + @"\..\..\..\File\All_word.txt");
            string _correctWord = string.Empty;
            string _failWord = string.Empty;
            string _isFalseWord = string.Empty;
            string _isInSuggestList = string.Empty;
            string _isDefineYet = string.Empty;
            string result;

            foreach (var l in f)
            {
                if (l.Length > 2)
                {

                    var words = l.Split(',');
                    
                    _correctWord = words[0];
                    _failWord = words[1];

                    if (_chkSpell.Cheak_Spell(_correctWord) == false)
                    {
                        _isDefineYet = "not_define";
                    }
                    else
                    {
                        _isDefineYet = "define";
                    }


                    if (_chkSpell.Cheak_Spell(_failWord) == false)
                    {
                        _isFalseWord = "false_word";

                        if (_chkSpell.Suggest(_failWord).Contains(_correctWord))
                            _isInSuggestList = "Suggested";
                        else
                            _isInSuggestList = "NoSuggest";


                    }
                    else
                    {
                        _isFalseWord = "true_word";
                    }

                    result = _isDefineYet + @"," + _correctWord + @"," + _failWord + @"," + _isFalseWord + @"," + _isInSuggestList;
                             


                             File.AppendAllText(Environment.CurrentDirectory + @"\..\..\..\File\All_data.txt",
                         result + Environment.NewLine);
                    Thread.Sleep(1000);

                }

            }
        }
    }
}