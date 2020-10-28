using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorzoyaSpell
{
    internal class MakeTrans
    {
        private readonly Dictionary<char, char> _dic;

        public MakeTrans(string intab, string outab)
        {
            _dic = Enumerable.Range(0, intab.Length).ToDictionary(i => intab[i], i => outab[i]);
        }

        public string Translate(string src)
        {
            var sb = new StringBuilder(src.Length);
            foreach (var srcC in src)
                sb.Append(_dic.ContainsKey(srcC) ? _dic[srcC] : srcC);
            return sb.ToString();
        }
    }
}