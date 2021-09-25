using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectDataGen
{
    public class AlfaBet
    {
        public string GetRandomFarsiChar(int maxSize)
        {
            char[] chars = new char[62];
            chars = "آابپتتثجچحخدذرزسشصضطظعغفقکگلمنوهی".ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public string SwapChars(string value, int index)
        {
            if (index == value.Length - 1)
            {
                return null;
            }
            char[] array = value.ToCharArray();
            char temp1 = array[index];
            char temp2 = array[index + 1];
            if (temp1 == temp2)
            {
                return null;
            }
            array[index] = temp2;
            array[index + 1] = temp1;
            return new string(array);
        }

        /// <summary>
        /// RepeatChars.
        /// [Repeat 1 char]
        /// </summary>
        public string RepeatChars(string value, int index)
        {
            return value.Substring(0, index) + value.Substring(index, 1) +
                   value.Substring(index);
        }

        /// <summary>
        /// DeleteChar.
        /// </summary>
        public string DeleteChar(string value, int index)
        {
            return value.Substring(0, index) + value.Substring(index + 1);
        }
    }

}
