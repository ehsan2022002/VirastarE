using Microsoft.Win32;

namespace VirastarE
{
    static class RegistaryApplicationSetting
    {

        static string regLocation = @"SOFTWARE\VirastarE";
        public static void SetRegistaryKey(string mKey, string mVal)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(regLocation + @"\" + mKey);
            if (key != null)
            {
                key.SetValue(mKey, mVal);
                key.Close();
            }
        }


        public static string GetRegistaryKey(string mKey)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(regLocation + @"\" + mKey);
            if (key != null)
            {
                return key.GetValue(mKey).ToString();
            }

            return string.Empty;
        }

    }
}
