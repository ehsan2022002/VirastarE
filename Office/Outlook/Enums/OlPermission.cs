﻿using NetOffice.Attributes;
namespace NetOffice.OutlookApi.Enums
{
    /// <summary>
    /// SupportByVersion Outlook 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff861270.aspx </remarks>
    [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum OlPermission
    {
        /// <summary>
        /// SupportByVersion Outlook 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
        olUnrestricted = 0,

        /// <summary>
        /// SupportByVersion Outlook 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
        olDoNotForward = 1,

        /// <summary>
        /// SupportByVersion Outlook 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
        olPermissionTemplate = 2
    }
}