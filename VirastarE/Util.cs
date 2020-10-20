

namespace VirastarE
{
    using System;
    using System.Globalization;
    public class Util
    {

        public static class UtilMessagesEnum
        {
            public const string ChkPuncInProcess = " بازبینی نگارش ... ";
            public const string ChkPuncProcessCompilite = " بازبینی نگارش انجام شد ";
            public const string ChkSpellInProcess = " بازبینی املا ... ";
            public const string ChkSpellProcessCompilite = " بازبینی املایی انجام شد ";
            public const string ToolbarMessageSetting = "تنظیمات";
            public const string ToolbarMessageLDA = "تاپیک مدلینگ";
        }
    

        public static class UtilSystemEnum
        {
            public const string chkRecSpell = "chkRecSpell";
            public const string chkPunkRec = "chkPunkRec";
            public const string OnKey = "1";
            public const string StartCustomRecordPunc = "VirastarE Punc";
            public const string StartCustomRecordSpell = "VirastarE Spell";
        }

        private PersianCalendar persiancalendar;

        public string GetShamsiDateNow()
        {
            

            return persiancalendar.GetYear(DateTime.Now) + "/" +
                   persiancalendar.GetMonth(DateTime.Now) + "/" +
                   persiancalendar.GetDayOfMonth(DateTime.Now) + " " +
                   DateTime.Now.ToString("HH:mm:ss");
        }

    }
}
