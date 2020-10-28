using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BorzoyaSpell
{
    public class FarsiNormalizer
    {
        private readonly bool _affixSpacing = true;
        private readonly List<RegexPattern> _affixSpacingPatterns; //

        private readonly bool _characterRefinement = true;
        private readonly List<RegexPattern> _characterRefinementPatterns;

        private readonly string _puncAfter = @"!:\.،؛؟»\]\)\}";
        private readonly string _puncBefore = @"«\[\(\{";

        private readonly bool _punctuationSpacing = true;
        private readonly List<RegexPattern> _punctuationSpacingPatterns;

        private readonly MakeTrans _translations;

        public FarsiNormalizer()
            : this(true, true, true)
        {
        }

        public FarsiNormalizer(bool characterRefinement, bool punctuationSpacing, bool affixSpacing)
        {
            _characterRefinement = characterRefinement;
            _punctuationSpacing = punctuationSpacing;
            _affixSpacing = affixSpacing;

            //this._translations = new MakeTrans(" كي;%1234567890", " کی؛٪۱۲۳۴۵۶۷۸۹۰");
            _translations = new MakeTrans(" كي;%1234567890", " کی؛٪1234567890");

            var r = new Regex("");
            if (_characterRefinement)
            {
                _characterRefinementPatterns = new List<RegexPattern>
                {
                    new RegexPattern(@"[ـ\r]", ""), new RegexPattern(" +", " "), new RegexPattern(@" ?\.\.\.", " …")
                };
                // remove "keshide" and "carriage return" characters
                // remove extra spaces
                // remove extra newlines
                //this._characterRefinementPatterns.Add(new RegexPattern(@"\n\n+", "\n\n"));
                // replace 3 dots
            }

            if (_punctuationSpacing)
            {
                _punctuationSpacingPatterns = new List<RegexPattern>
                {
                    new RegexPattern(" ([" + _puncAfter + "])", "$1"),
                    new RegexPattern("([" + _puncBefore + "]) ", "$1"),
                    new RegexPattern("([" + _puncAfter + "])([^ " + _puncAfter + "])",
                        "$1 $2"),
                    new RegexPattern("([^ " + _puncBefore + "])([" + _puncBefore + "])",
                        "$1 $2")
                };
                // remove space before punctuation
                // remove space after punctuation
                // put space after
                // put space before
            }

            if (_affixSpacing)
            {
                _affixSpacingPatterns = new List<RegexPattern>
                {
                    new RegexPattern("([^ ]ه) ی ", @"$1‌ی "),
                    new RegexPattern("(^| )(ن?می) ", @"$1$2‌"),
                    new RegexPattern(" (تر(ی(ن)?)?|ها(ی)?)(?=[ \n" + _puncAfter + _puncBefore + "]|$)", @"‌$1"),
                    new RegexPattern("([^ ]ه) (ا(م|ت|ش|ی))(?=[ \n" + _puncAfter + "]|$)",
                        @"$1‌$2")
                };
                // fix ی space
                // put zwnj after می, نمی
                // put zwnj before تر, ترین, ها, های
                // join ام, ات, اش, ای
            }
        }

        public string Run(string text)
        {
            if (_characterRefinement)
                text = CharacterRefinement(text);

            if (_punctuationSpacing)
                text = PunctuationSpacing(text);

            if (_affixSpacing)
                text = AffixSpacing(text);

            return text;
        }

        public string CharacterRefinement(string text)
        {
            text = _translations.Translate(text);
            foreach (var pattern in _characterRefinementPatterns)
                text = pattern.Apply(text);
            return text;
        }

        private string PunctuationSpacing(string text)
        {
            // TODO: don't put space inside time and float numbers
            foreach (var pattern in _punctuationSpacingPatterns)
                text = pattern.Apply(text);
            return text;
        }

        private string AffixSpacing(string text)
        {
            foreach (var pattern in _affixSpacingPatterns)
                text = pattern.Apply(text);
            return text;
        }
    } //
}