using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using java.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FarsiPOSTagger
{
    public static class POSTagger
    {

        public static IList<Tuple<string, string>> getTags(string santance )
        {
            MaxentTagger tagger;
            string lng = "persian";
            try
            {

            if ( Regex.IsMatch(santance, @"^[\u0000-\u007F]+$"))
            {
                    lng = "english";
            }
            
            //tagger = new MaxentTagger(@"Resources/"+ lng +".tagger");

            string ResurchPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\" + lng + ".tagger";

            if (!System.IO.File.Exists(ResurchPath))
                    throw new Exception("resource not found  " + ResurchPath);
            

            tagger = new MaxentTagger(ResurchPath);
            IList<Tuple<string, string>> tagged = new List<Tuple<string, string>>();
                        
            // Text for tagging
            //var text = @"یک روز آمدم ";
            var text = santance;// "hello how are you?";

            var sentences = MaxentTagger.tokenizeText(new StringReader(text)).toArray();
            foreach (ArrayList sentence in sentences)
            {
                var taggedSentence = tagger.tagSentence(sentence);
                //System.Console.WriteLine(SentenceUtils.listToString(taggedSentence, false));

                for (int i = 0; i < taggedSentence.size(); i++)
                {
                    var t = taggedSentence.toArray()[i].ToString().Split('/');
                    tagged.Add(Tuple.Create(t[0], t[1]));
                }
            }

                return tagged;                               
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally 
            {
                tagger = null;                
            }
            
        }


    }
}
