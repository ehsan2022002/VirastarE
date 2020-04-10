using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using java.io;
using java.util;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;


namespace FarsiPOSTagger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loading POS Tagger
            var tagger = new MaxentTagger(@"Resources/english-bidirectional-distsim.tagger");

            // Text for tagging
            //var text = @"یک روز آمدم ";
            var text = "hello how are you?";
            IList<Tuple<string, string>> tagged = new List<Tuple<string, string>>();


            var sentences = MaxentTagger.tokenizeText(new StringReader(text)).toArray();
            foreach (ArrayList sentence in sentences)
            {
                var taggedSentence = tagger.tagSentence(sentence);
                System.Console.WriteLine(SentenceUtils.listToString(taggedSentence, false));

                for (int i = 0; i < taggedSentence.size(); i++)
                {
                    var t = taggedSentence.toArray()[i].ToString().Split('/');
                    tagged.Add(Tuple.Create(t[0], t[1]));
                }

            }
        }


        
    
    }
}
