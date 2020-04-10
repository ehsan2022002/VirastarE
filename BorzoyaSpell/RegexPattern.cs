using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Pattern = pattern;
            this.Replace = replace;
        }

        public Regex Pattern { get; private set; }
        public string Replace { get; private set; }

        public string Apply(string text)
        {
            return Pattern.Replace(text, Replace);
        }
    }
}
