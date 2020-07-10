using System;
using System.Collections.Generic;

namespace LanguageDetection
{
    public class LanguageDetector
    {
        private const int MaxLength = 4096;
        private const int MaxPenalty = 300;

        private readonly Dictionary<string, Dictionary<string, int>> _availableLanguages;

        public LanguageDetector()
        {
        }

        public LanguageDetector(Dictionary<string, Dictionary<string, int>> availableLanguages)
        {
            _availableLanguages = availableLanguages;
        }

        public string Detect(string text)
        {
            //score = 0;
            //var text = String.Empty;

            
            var ngramBuilder = new NgramBuilder(MaxLength, true);

            var ngrams = ngramBuilder.Get(text); //create an ngram dictionary

            if (ngrams == null)
            {
                return null;
            }

            var shortestDistance = int.MaxValue;

            var probability = 0;

            string lowestScoringLanguage = null;

            foreach (var availableLanguage in _availableLanguages)
            {
                //calculate distance between language and ngrams

                var distance = 0;

                var probabilityHits = 0;

                foreach (var ngram in ngrams)
                {
                    if (availableLanguage.Value.ContainsKey(ngram.Key))
                    {
                        distance += ngram.Value - availableLanguage.Value[ngram.Key];

                        probabilityHits++;
                    }
                    else
                    {
                        distance += MaxPenalty;
                    }

                    if (distance > shortestDistance)
                    {
                        break;
                    }
                }

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    lowestScoringLanguage = availableLanguage.Key;
                    probability = probabilityHits;
                }
            }

            //score = probability;

            return lowestScoringLanguage;
        }
    }
}