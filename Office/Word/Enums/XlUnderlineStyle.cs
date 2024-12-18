﻿using NetOffice.Attributes;
namespace NetOffice.WordApi.Enums
{
    /// <summary>
    /// SupportByVersion Word 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff836609.aspx </remarks>
    [SupportByVersion("Word", 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum XlUnderlineStyle
    {
        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-4119</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlUnderlineStyleDouble = -4119,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>5</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlUnderlineStyleDoubleAccounting = 5,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-4142</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlUnderlineStyleNone = -4142,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlUnderlineStyleSingle = 2,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlUnderlineStyleSingleAccounting = 4
    }
}