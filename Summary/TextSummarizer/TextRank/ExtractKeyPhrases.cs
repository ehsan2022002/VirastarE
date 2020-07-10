using System;
using System.Collections.Generic;

namespace TextRank
{
    public class ExtractKeyPhrases
    {

        public Tuple<string, List<string>> Extract(string sentence, string lang,int wordLength = 100)
        {
            var keyWords = ExtractKeyword.Extract.GetKeyWordsList(sentence, lang);

            var summary = ExtractSummary.Extract.ExtractParagraphSummary(sentence, wordLength);

            return new Tuple<string, List<string>>(summary, keyWords);
        }


    }
}


