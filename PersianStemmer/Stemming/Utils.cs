using System;
using System.Text.RegularExpressions;

namespace Stemming
{
    public class Utils
    {

        public static string ExactMatch(string q)
        {
            q = q.Replace("\"", "");
            /*if (!q.startsWith("\""))
                q = "\"".concat(q);
            if (!q.endsWith("\""))
                q = q.concat("\"");*/

            q = "\"" + q + "\"";
            return q;
        }

        public static bool IsAdvanceQuery(string input)
        {
            //return input.matches(".*[+:-].*");
            return Regex.IsMatch(input, ".*[+:-].*");
        }

        public static bool IsPhraseQuery(string input)
        {
            //return input.matches("\".+\"");
            return Regex.IsMatch(input, "\".+\"");
        }

        public static bool IsEnglish(string input)
        {
            //return input.matches("[a-z,:/`;'\\?A-Z *+~!@#=\\[\\]{}\\$%^&*().0-9]+");
            return Regex.IsMatch(input, "[a-z,:/`;'\\?A-Z*+~!@#=\\[\\]{}\\$%^&*().0-9]+");
        }

        public static bool IsNumber(string input)
        {
            //return input.matches("[0-9,.]+");
            return Regex.IsMatch(input, "[0-9,.]+"); // what about "^[-+]?[0-9]*\.?[0-9]*$"   ?
        }

        public static int WordCount(string input)
        {
            //return string.IsNullOrEmpty(input.Trim()) ? 0 : input.Trim().Split("\\s+").length;
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        //public static BufferedReader getBufferedReader(Reader reader)
        //{
        //    return (reader is BufferedReader) ? (BufferedReader)reader : new BufferedReader(reader);
        //}
    }
}
