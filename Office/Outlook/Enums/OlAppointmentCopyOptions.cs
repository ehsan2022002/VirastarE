﻿using NetOffice.Attributes;
namespace NetOffice.OutlookApi.Enums
{
    /// <summary>
    /// SupportByVersion Outlook 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff868627.aspx </remarks>
    [SupportByVersion("Outlook", 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum OlAppointmentCopyOptions
    {
        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        olPromptUser = 0,

        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        olCreateAppointment = 1,

        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        olCopyAsAccept = 2
    }
}