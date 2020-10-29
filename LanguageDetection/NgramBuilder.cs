using System;
using System.Collections.Generic;

namespace LanguageDetection
{
    public class NgramBuilder
    {
        private const int NgramSize = 3; //the length of an ngram, use trigrams by default
        private const int NgramCount = 100; //fifty ngrams should be enough, too high can lead to unreliable results

        private readonly bool _absoluteScoring;

        private readonly int _maxLength;

        public NgramBuilder(int maxLength = int.MaxValue, bool absoluteScoring = false)
        {
            _maxLength = maxLength;

            _absoluteScoring = absoluteScoring;
        }

        public Dictionary<string, int> Get(string text)
        {
            text = text.Clean(_maxLength);

            if (string.IsNullOrWhiteSpace(text)) return null;

            // NOTE: a dictionary might be nicer than two lists, but that cannot easily be sorted without a huge performance hit
            var keys = new List<string>();
            var scores = new List<int>();

            for (var i = 0; i < text.Length - NgramSize; i++)
            {
                var key = "" + text[i] + text[i + 1] + text[i + 2];

                var index = keys.IndexOf(key);

                if (index >= 0)
                {
                    scores[index]++;
                }
                else
                {
                    keys.Add(key);
                    scores.Add(1);
                }
            }

            var arrKeys = keys.ToArray();
            var arrScores = scores.ToArray();

            Array.Sort(arrScores, arrKeys);
            Array.Reverse(arrKeys);
            Array.Reverse(arrScores);

            var result = new Dictionary<string, int>();

            for (var i = 0; i < arrKeys.Length && i < NgramCount; i++)
                result.Add(arrKeys[i], _absoluteScoring ? arrScores[i] : NgramCount - i);

            return result;
        }

        public Dictionary<string, int> Load(string[] ngrams)
        {
            var result = new Dictionary<string, int>();

            for (var i = 0; i < ngrams.Length && i < NgramCount; i++) result.Add(ngrams[i], NgramCount - i);

            return result;
        }
    }
}