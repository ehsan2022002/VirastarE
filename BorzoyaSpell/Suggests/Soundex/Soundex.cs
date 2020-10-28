using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrozoyaEntitys.EntityData;

namespace BorzoyaSpell.Suggests.Soundex
{
    public class Soundex
    {

        public List<PS_PersianWordFrequency> psDICList; //

        public Soundex(List<PS_PersianWordFrequency> psDICWordFreq)
        {
            psDICList = new List<PS_PersianWordFrequency>();

            //var ls = new PS_Dictionary_FAOpration();
            psDICList = psDICWordFreq;

        }

        public Soundex()
        {
        }

        public List<string> GetSuggest(string word)
        {
            string wordsound = FA_Computeintial2(word, 8);

            return psDICList.Where(x => x.Sundex == wordsound).Select(y => y.Val1).ToList();

        }

        public string FA_Computeintial2(string word, int length)
        {
            // Value to return
            string value = string.Empty;

            //delete first latter A
            //switch (word[0])
            //{
            //    case 'ا':
            //    case 'أ':
            //    case 'إ':
            //    case 'آ':
            //        {
            //            word = word.Substring(1, word.Length - 1);
            //        }
            //        break;

            //}

            // Size of the word to process
            int size = word.Length;
            // Make sure the word is at least two characters in length
            if (size > 1)
            {

                // Convert the word to character array for faster processing
                char[] chars = word.ToCharArray();
                // Buffer to build up with character codes
                StringBuilder buffer = new StringBuilder();
                buffer.Length = 0;
                // The current and previous character codes
                int prevCode = 0;
                int currCode = 0;
                // Ignore first character and replace it with fixed value

                buffer.Append('x');

                // Loop through all the characters and convert them to the proper character code
                for (int i = 1; i < size; i++)
                {
                    switch (chars[i])
                    {
                        case 'ا':
                        case 'أ':
                        case 'إ':
                        case 'آ':
                        case 'ح':
                        case 'خ':

                        case 'ه':
                        case 'ع':
                        case 'غ':
                        case 'ش':
                        case 'و':
                        case 'ي':
                            currCode = 0;
                            break;
                        case 'ف':
                        case 'ب':
                        case 'پ': //added
                            currCode = 1;
                            break;

                        case 'ج':
                        case 'چ': //added
                        case 'ز':
                        case 'س':
                        case 'ص':
                        case 'ظ':
                        case 'ق':
                        case 'ك':
                        case 'گ': //added
                            currCode = 2;
                            break;
                        case 'ت':
                        case 'ث':
                        case 'د':
                        case 'ذ':
                        case 'ض':
                        case 'ط':
                            currCode = 3;
                            break;
                        case 'ل':
                            currCode = 4;
                            break;
                        case 'م':
                        case 'ن':
                            currCode = 5;
                            break;
                        case 'ر':
                        case 'ژ': //added
                            currCode = 6;
                            break;
                    }

                    // Check to see if the current code is the same as the last one
                    if (currCode != prevCode)
                    {
                        // Check to see if the current code is 0 (a vowel); do not process vowels
                        if (currCode != 0)
                            buffer.Append(currCode);
                    }
                    // Set the new previous character code
                    prevCode = currCode;
                    // If the buffer size meets the length limit, then exit the loop
                    if (buffer.Length == length)
                        break;
                }
                // Pad the buffer, if required
                size = buffer.Length;
                if (size < length)
                    buffer.Append('0', (length - size));
                // Set the value to return
                value = buffer.ToString();
            }
            // Return the value
            return value;
        }

    }
}
