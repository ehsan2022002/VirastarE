﻿using NetOffice.Attributes;
namespace NetOffice.OutlookApi.Enums
{
    /// <summary>
    /// SupportByVersion Outlook 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff869338.aspx </remarks>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum OlRuleExecuteOption
    {
        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olRuleExecuteAllMessages = 0,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olRuleExecuteReadMessages = 1,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olRuleExecuteUnreadMessages = 2
    }
}