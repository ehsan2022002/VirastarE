using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LanguageDetection
{
    public class FindLanguage
    {
        static string _knownLanguagesFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\known_languages.txt";

        static void Learn(string languageCode, string newLanguageFile, string knownLanguagesFile)
        { 
            //if you want add language
            var learner = new LanguageLearner();

            learner.Learn(languageCode, newLanguageFile, knownLanguagesFile);

            Console.WriteLine("The language '{0}' has been learned!", languageCode);
        }

        public static string Detect(string inputString)
        {

            
            var learner = new LanguageLearner();
            var knownLanguages = learner.Remember(_knownLanguagesFile);
            var detector = new LanguageDetector(knownLanguages);


            return detector.Detect(inputString);

            //Console.WriteLine("The language code of the detected language is: {0}", languageCode);
        }

        public static List<string> GetTraindLanguage()
        {
            List<string> traindLanguageList = new List<string>();

            using (var reader = new StreamReader(_knownLanguagesFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var model = line.Split(':');
                    traindLanguageList.Add(model[0].Trim());
                }
            }

            return traindLanguageList;
        }

    }
}
