using System.Globalization;

namespace Tesseract.Internal
{
    /// <summary>
    ///     Utility helpers to handle converting variable values.
    /// </summary>
    internal static class TessConvert
    {
        public static bool TryToString(object value, out string result)
        {
            if (value is bool)
            {
                result = ToString((bool) value);
            }
            else if (value is decimal)
            {
                result = ToString((decimal) value);
            }
            else if (value is double)
            {
                result = ToString((double) value);
            }
            else if (value is float)
            {
                result = ToString((float) value);
            }
            else if (value is short)
            {
                result = ToString((short) value);
            }
            else if (value is int)
            {
                result = ToString((int) value);
            }
            else if (value is long)
            {
                result = ToString((long) value);
            }
            else if (value is ushort)
            {
                result = ToString((ushort) value);
            }
            else if (value is uint)
            {
                result = ToString((uint) value);
            }
            else if (value is ulong)
            {
                result = ToString((ulong) value);
            }
            else if (value is string)
            {
                result = (string) value;
            }
            else
            {
                result = null;
                return false;
            }

            return true;
        }

        public static string ToString(bool value)
        {
            return value ? "TRUE" : "FALSE";
        }

        public static string ToString(decimal value)
        {
            return value.ToString("R", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(double value)
        {
            return value.ToString("R", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(float value)
        {
            return value.ToString("R", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(short value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(int value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(long value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(ushort value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(uint value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }

        public static string ToString(ulong value)
        {
            return value.ToString("D", CultureInfo.InvariantCulture.NumberFormat);
        }
    }
}