using System.Text.RegularExpressions;

namespace BorzoyaSpell
{
    public class RegexPattern
    {
        public RegexPattern(string pattern, string replace)
            : this(new Regex(pattern), replace)
        {
        }

        public RegexPattern(Regex pattern, string replace)
        {
            Pattern = pattern;
            Replace = replace;
        }

        public Regex Pattern { get; }
        public string Replace { get; }

        public string Apply(string text)
        {
            return Pattern.Replace(text, Replace);
        }
    }
}