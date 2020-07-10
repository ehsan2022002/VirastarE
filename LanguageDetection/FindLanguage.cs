using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LanguageDetection
{
    public class FindLanguage
    {
        static string knownLanguagesFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\known_languages.txt";

        public FindLanguage()
        {

        }
        static void Learn(string languageCode, string newLanguageFile, string knownLanguagesFile)
        {
            var learner = new LanguageLearner();

            learner.Learn(languageCode, newLanguageFile, knownLanguagesFile);

            Console.WriteLine("The language '{0}' has been learned!", languageCode);
        }

        public static string Detect(string InputString)
        {

            
            var learner = new LanguageLearner();
            var knownLanguages = learner.Remember(knownLanguagesFile);
            var detector = new LanguageDetector(knownLanguages);


            return detector.Detect(InputString);

            //Console.WriteLine("The language code of the detected language is: {0}", languageCode);
        }

        public static List<string> GetTraindLanguage()
        {
            string line;
            List<string> r = new List<string>();

            using (var reader = new StreamReader(knownLanguagesFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var model = line.Split(':');
                    r.Add(model[0].Trim());
                }
            }

            return r;
        }

    }
}
