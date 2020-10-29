using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LanguageDetection
{
    public static class Helper
    {
        public static string Clean(this string text, int maxLength = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(text)) return null; //there is no text, return null

            if (text.Length > maxLength) //shorten the text, because MaxLength is a good enough size
                text = text.Substring(0, maxLength);

            text = Regex.Replace(text, @"[^\w\s]", string.Empty); //remove everything that is not a word or a space

            text = Regex.Replace(text, @"\s\s+", " "); //replace all sequential whitespace with a space

            text = text.Trim(); //remove trailing and leading whitespace

            text = text.ToLower(); //convert string to lowercase

            return text;
        }

        public static string GetFileContents(string path)
        {
            using (var reader = new StreamReader(path, Encoding.Unicode))
            {
                return reader.ReadToEnd();
            }
        }
    }
}