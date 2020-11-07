using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BorzoyaSpell
{
    public class PunctuationCkeak
    {
        public static List<PunchPattern> PunctuationChk(string inputValue)
        {
            PunchPattern pattern;
            var punchPatternsList = new List<PunchPattern>();
            var puctuationList = InitPuctuation();


            if (!IsBalanced(inputValue))
            {
                pattern = new PunchPattern(0)
                {
                    ErroMessage = @"پرانتز یا کروشه یا آکولاد باز بدون بستن",
                    ErrorCode = 80,
                    ErrorCorrection = @"علامتهای باز و بسته را برسی کنید"
                };
                punchPatternsList.Add(pattern);
            }

            try
            {
                foreach (var punchPattern in puctuationList)
                {
                    //var xAll = Regex.Matches(inputValue, t.Regax, RegexOptions.IgnoreCase);
                    var matchesList =
                        (from Match m in Regex.Matches(inputValue, punchPattern.Regax, RegexOptions.IgnoreCase)
                            select m).ToList();
                    foreach (var x in matchesList)
                        if (x.Success)
                        {
                            pattern = new PunchPattern(0);
                            pattern = punchPattern;
                            pattern.IndexStart = x.Index;
                            pattern.IndexLenght = x.Length;
                            punchPatternsList.Add(pattern);
                        }
                }
            }
            catch (Exception)
            {
                // ignored
            }


            return punchPatternsList;
        }

        public static bool IsBalanced(string input)
        {
            var bracketPairs = new Dictionary<char, char>
            {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'},
                {'<', '>'},
                {'«', '»'}
            };

            var brackets = new Stack<char>();
            try
            {
                // Iterate through each character in the input string
                foreach (var c in input)
                    // check if the character is one of the 'opening' brackets
                    if (bracketPairs.Keys.Contains(c))
                    {
                        // if yes, push to stack
                        brackets.Push(c);
                    }
                    else
                        // check if the character is one of the 'closing' brackets
                    if (bracketPairs.Values.Contains(c))
                    {
                        // check if the closing bracket matches the 'latest' 'opening' bracket
                        if (c == bracketPairs[brackets.First()])
                            brackets.Pop();
                        else
                            // if not, its an unbalanced string
                            return false;
                    }
            }
            catch
            {
                // an exception will be caught in case a closing bracket is found, 
                // before any opening bracket.
                // that implies, the string is not balanced. Return false
                return false;
            }

            // Ensure all brackets are closed
            return !brackets.Any() ? true : false;
        }

        private static List<PunchPattern> InitPuctuation()
        {
            var punchPatterns = new List<PunchPattern>
            {
                new PunchPattern(@"[ ‌]+(;)", "قبل از نقطه ويرگول فاصله نمي‌آيد", "فاصله را حذف كنيد", 10),
                new PunchPattern(@"(;)(([ ‌]+)?[\.,;:!؟\-…]+)+",
                    "بعد از نقطه ويرگول علامتي قرار نمي‌گيرد", "علايم بعد از نقطه ويرگول را حذف كنيد", 11),
                new PunchPattern(@"([;])([^ \)»\]\n\d\u0002])", "بعد از نقطه ويرگول فاصله لازم است",
                    "فاصله بگذاريد", 12),
                new PunchPattern(@"; *(\n)", "در انتهاي پاراگراف نقطه ويرگول ‌نمي‌آيد", "نقطه بگذاريد",
                    13),
                new PunchPattern(@"([\(\[«])[ ‌]*[;]", "نقطه ويرگول در ابتداي علامت باز قرار نمي‌گيرد",
                    "نقطه ويرگول را به خارج  منتقل كنيد يا حذف كنيد", 14),
                new PunchPattern(@"[ ‌]+(,)", "قبل از ويرگول فاصله نمي‌آيد", "فاصله را حذف كنيد", 15),
                new PunchPattern(@"(,)([ ‌]+)?([,;:!؟\-][\.,;:!؟\-]*|\.(?!\.))",
                    "بعد از ويرگول اين علامت(ها) قرار نمي‌گيرد", "علامت(هاي) بعد از ويرگول را حذف كنيد", 16),
                new PunchPattern(@"([,])([^ \)»\]\n\d\u0002])", "بعد از ويرگول فاصله لازم است",
                    "فاصله بگذاريد", 17),
                new PunchPattern(@"([,])([ ‌\n]+)?$", "در انتهاي جمله ويرگول نمي‌آيد",
                    "در انتهاي جمله نقطه بگذاريد", 18),
                new PunchPattern(@"[,]([\)»\]])", "ويرگول قبل از علامت بسته قرار نمي‌گيرد",
                    "ويرگول را به بيرون انتقال دهيد", 19),
                new PunchPattern(@"([\(\[«])[ ‌]*[,]", "ويرگول در ابتداي علامت باز قرار نمي‌گيرد",
                    "ويرگول را به خارج  منتقل كنيد يا حذف كنيد", 20),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])([»\)\]]?)[ ‌]+[.](?![\.\d])",
                    "قبل از نقطه فاصله نمي‌آيد", "فاصله را حذف كنيد", 21),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])([»\)\]]?)[ ]*(\. +\. +\.|\.\. +\.|\. +\.\.|\.\.\. \.+)",
                    "بين نقاط فاصله نگذاريد", "سه‌نقطه قرار دهيد", 22),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])([»\)\]]?)([ ‌]*)(\.\.(?!\.)|\.\.\.\.[.]+)",
                    "سه نقطه قرار دهيد", "سه نقطه قرار دهيد", 23),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])([ ‌]+)?\.\.\.\.(?!\.)",
                    "چهار نقطه صحيح نيست", "سه نقطه قرار دهيد", 24),
                new PunchPattern(@"(?<!\.)\.([ ]*[,;:!؟]+)", "بعد از نقطه اين علايم نمي‌آيند",
                    "علايم بعد از نقطه را حذف كنيد", 25),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[.]([^ \)»\]\n\d\.\u0002])",
                    "بعد از نقطه فاصله لازم است", "فاصله بگذاريد", 26),
                new PunchPattern(
                    @"([\(\[«])[.]+([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])",
                    "نقطه در ابتداي علامت باز قرار نمي‌گيرد", "نقطه را به خارج  منتقل كنيد يا حذف كنيد", 27),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[.][ ‌]*(\))",
                    "نقطه در داخل پرانتز", "نقطه را به خارج  منتقل كنيد يا حذف كنيد", 28),
                new PunchPattern(@"(?<![\d\.])(\.) (كه|و|بنابراين|لذا)[ ]",
                    "در صورت وابستگي معني جملات بهتر است نقطه‌ويرگول قرار دهيد", "به جاي نقطه, نقطه‌ويرگول قرار دهيد",
                    29),
                new PunchPattern(@"([^ \(\[])(«)", "قبل از گيومه باز فاصله لازم است", "فاصله بگذاريد", 30),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])(\()",
                    "قبل از پرانتز باز فاصله لازم است", "فاصله بگذاريد", 31),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])(\[)",
                    "قبل از براكت باز فاصله لازم است", "فاصله بگذاريد", 32),
                new PunchPattern(
                    @"([«\(\[])([ ‌‌]+)([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])",
                    "بعد از علامت باز فاصله يا نيم‌فاصله نگذاريد", "فاصله يا نيم‌فاصله را حذف كنيد", 33),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[ ‌]+([»\)\]])",
                    "قبل از علامت بسته فاصله يا نيم‌فاصله نگذاريد", "فاصله يا نيم‌فاصله را حذف كنيد", 34),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2\d])([\]\)\»])([^ !؟,;.»\)\]\n\u0002])",
                    "بعد از علامت بسته فاصله يا نيم‌فاصله لازم است", "فاصله يا نيم‌فاصله بگذاريد", 35),
                new PunchPattern(@"([\!\؟])[\!\؟]{2,}", "تكرار علامت", "علامت‌هاي تكراري را حذف كنيد", 36),
                new PunchPattern(@"[\؟][\!\؟]", "علامت گذاري نادرست", "ترتيب علايم را درست كنيد", 37),
                new PunchPattern(@"([\!\؟])([^ \)»\]\n\!\؟\.,;\u0002])",
                    "بعد از علامت‌هاي سوال و تعجب فاصله لازم است", "فاصله بگذاريد", 38),
                new PunchPattern(@"[ ‌]+([\!\؟])", "قبل از ! و ؟ فاصله يا نيم فاصله قرار نميگيرد",
                    "فاصله را حذف كنيد", 39),
                new PunchPattern(@"([^ ‌])([‌]{2,})", "نيم‌فاصله اضافي وجود دارد", "فاصله را حذف كنيد",
                    40),
                new PunchPattern(@"([^ ‌])([ ‌]{2,})", "فاصله يا نيم‌فاصله اضافي وجود دارند",
                    "فاصله را حذف كنيد", 41),
                new PunchPattern(@"([^ ])[ ‌]+$", "فاصله در انتهاي جمله لازم نيست", "فاصله را حذف كنيد",
                    42),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[ ]*[?]",
                    "نويسه غيرفارسي", "از نويسه فارسي استفاده كنيد", 43),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[ ]*[;]",
                    "نويسه غيرفارسي", "از نويسه فارسي استفاده كنيد", 44),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[ ]*[,]",
                    "نويسه غيرفارسي", "از نويسه فارسي استفاده كنيد", 45),
                new PunchPattern(
                    @"(\d+)([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2]+)",
                    "عدد منتهي به كلمه", "بين حروف و اعداد فاصله بگذاريد", 46),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2]+)(\d+)",
                    "كلمه منتهي به رقم", "بين حروف و اعداد فاصله بگذاريد", 47),
                new PunchPattern(
                    @"([a-zA-Z]+)([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2]+)",
                    "كلمه انگليسي منتهي به الفباي فارسي", "بين كلمات فارسي و انگليسي فاصله بگذاريد", 48),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2]+)([a-zA-Z]+)",
                    "كلمه فارسي منتهي به الفباي انگليسي", "بين كلمات فارسي و انگليسي فاصله بگذاريد", 49),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])[ ]+([\u0002])",
                    "فاصله قبل از شماره پاورقي", "فاصله قبل از شماره پاورقي را حذف كنيد", 50),
                new PunchPattern(@"([\)\»\.])[ ]*([\u0002])(.)", "پاورقی در جای نادرست", "", 51),
                new PunchPattern(
                    @"([\u0621-\u0655\u067E\u0686\u0698\u06AF\u06A9\u0643\u06AA\uFED9\uFEDA\u06CC\uFEF1\uFEF2])([\u0002])([^ \.!؟\;,\)\]\»])",
                    "فاصله بعد از پاورقي لازم است", "بعد از پاورقي فاصله بگذاريد", 52),
                new PunchPattern(@"([^\(\)\»\«\\inputValue])([\u0001])", "فاصله قبل از فرمول لازم است",
                    "قبل از فرمول فاصله بگذاريد", 53),
                new PunchPattern(@"[ ]([\u0001])([^\(\)\»\«\\inputValue,\;;,!؟\?!])", "فاصله بعد از فرمول لازم است",
                    "بعد از پاورقي فاصله بگذاريد", 54)
            };


            //

            return punchPatterns;
        }
    }
}