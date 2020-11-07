using System.Collections.Generic;

namespace LDA
{
    public class WordDictionary
    {
        public int Count;
        public Dictionary<string, int> Word2Id;
        public List<string> Words;

        public WordDictionary()
        {
            Word2Id = new Dictionary<string, int>();
            Words = new List<string>();
            Count = 0;
        }

        public string GetString(int id)
        {
            if (id > Count) return null;
            return Words[id];
        }

        public int GetWords(string str)
        {
            if (Word2Id.ContainsKey(str))
                return Word2Id[str];
            return AddWord(str);
        }

        public int AddWord(string str)
        {
            if (!Word2Id.ContainsKey(str))
            {
                Words.Add(str);
                Word2Id[str] = Count;
                Count++;
                return Count - 1;
            }

            return -1;
        }
    }
}