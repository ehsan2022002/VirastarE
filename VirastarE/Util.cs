﻿using System;
using System.Globalization;
using Microsoft.Win32;

namespace VirastarE
{
    public class Util
    {
        private readonly PersianCalendar persiancalendar;

        public Util()
        {
            persiancalendar = new PersianCalendar();
        }


        public string GetShamsiDateNow()
        {
            return persiancalendar.GetYear(DateTime.Now) + "/" +
                   persiancalendar.GetMonth(DateTime.Now) + "/" +
                   persiancalendar.GetDayOfMonth(DateTime.Now) + " " +
                   DateTime.Now.ToString("HH:mm:ss");
        }

        public string GetVersionFromRegistry()
        {
            var maxDotNetVersion = "";
            // Opens the registry key for the .NET Framework entry.
            using (var ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "")
                .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                foreach (var versionKeyName in ndpKey.GetSubKeyNames())
                    if (versionKeyName.StartsWith("v"))
                    {
                        var versionKey = ndpKey.OpenSubKey(versionKeyName);
                        var name = (string) versionKey.GetValue("Version", "");
                        var sp = versionKey.GetValue("SP", "").ToString();
                        var install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                        {
                            Console.WriteLine(versionKeyName + @"  " + name);
                            if (string.CompareOrdinal(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                        }
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + @"  SP" + sp);
                                if (string.CompareOrdinal(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                            }
                        }

                        if (name != "") continue;
                        foreach (var subKeyName in versionKey.GetSubKeyNames())
                        {
                            var subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string) subKey.GetValue("Version", "");
                            if (name != "") sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "")
                            {
                                //no install info, must be later.
                                Console.WriteLine(versionKeyName + "  " + name);
                                if (string.CompareOrdinal(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                            }
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    Console.WriteLine(@"  " + subKeyName + @"  " + name + @"  SP" + sp);
                                    if (string.CompareOrdinal(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                }
                                else if (install == "1")
                                {
                                    Console.WriteLine(@"  " + subKeyName + "  " + name);
                                    if (string.CompareOrdinal(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                } // if
                            } // if
                        } // for
                    } // if
            } // using

            return maxDotNetVersion;
        }

        public static class UtilMessagesEnum
        {
            public const string ChkPuncInProcess = " بازبینی نگارش ... ";
            public const string ChkPuncProcessCompilite = " بازبینی نگارش انجام شد ";
            public const string ChkSpellInProcess = " بازبینی املا ... ";
            public const string ChkSpellProcessCompilite = " بازبینی املایی انجام شد ";
            public const string ToolbarMessageSetting = "تنظیمات";
            public const string ToolbarMessageLda = "تاپیک مدلینگ";
            public const string NotValid = " معتبر نیست ";
            public const string Processing = " در حال پردازش ";
            public const string ProcessingCompilite = " پردازش نویسه خوان انجام شد ";
        }


        public static class UtilSystemEnum
        {
            public const string ChkRecSpell = "chkRecSpell";
            public const string ChkPunkRec = "chkPunkRec";
            public const string OnKey = "1";
            public const string OffKey = "0";

            public const string StartCustomRecordPunc = "VirastarE Punc";
            public const string StartCustomRecordSpell = "VirastarE Spell";

            public const string ChkIgnoreEnglish = "chkIgnoreEnglish";
            public const string ChkStemSpell = "chkStemSpell";
            public const string TxtIgnoreList = "txtIgnoreList";
        }
    }
}