﻿using NetOffice.Attributes;
namespace NetOffice.WordApi.Enums
{
    /// <summary>
    /// SupportByVersion Word 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff821128.aspx </remarks>
    [SupportByVersion("Word", 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum XlErrorBarInclude
    {
        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlErrorBarIncludeBoth = 1,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlErrorBarIncludeMinusValues = 3,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-4142</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlErrorBarIncludeNone = -4142,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlErrorBarIncludePlusValues = 2
    }
}