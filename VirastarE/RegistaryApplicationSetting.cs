using Microsoft.Win32;

namespace VirastarE
{
    internal static class RegistaryApplicationSetting
    {
        private static readonly string regLocation = @"SOFTWARE\VirastarE";

        public static void SetRegistaryKey(string mKey, string mVal)
        {
            var key = Registry.CurrentUser.CreateSubKey(regLocation + @"\" + mKey);
            if (key != null)
            {
                key.SetValue(mKey, mVal);
                key.Close();
            }
        }


        public static string GetRegistaryKey(string mKey)
        {
            var key = Registry.CurrentUser.OpenSubKey(regLocation + @"\" + mKey);
            if (key != null) return key.GetValue(mKey).ToString();

            return string.Empty;
        }
    }
}