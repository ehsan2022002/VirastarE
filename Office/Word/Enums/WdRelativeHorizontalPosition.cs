﻿using NetOffice.Attributes;
namespace NetOffice.WordApi.Enums
{
    /// <summary>
    /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff845860.aspx </remarks>
    [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum WdRelativeHorizontalPosition
    {
        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        wdRelativeHorizontalPositionMargin = 0,

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        wdRelativeHorizontalPositionPage = 1,

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        wdRelativeHorizontalPositionColumn = 2,

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        wdRelativeHorizontalPositionCharacter = 3,

        /// <summary>
        /// SupportByVersion Word 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Word", 12, 14, 15, 16)]
        wdRelativeHorizontalPositionLeftMarginArea = 4,

        /// <summary>
        /// SupportByVersion Word 12, 14, 15, 16
        /// </summary>
        /// <remarks>5</remarks>
        [SupportByVersion("Word", 12, 14, 15, 16)]
        wdRelativeHorizontalPositionRightMarginArea = 5,

        /// <summary>
        /// SupportByVersion Word 12, 14, 15, 16
        /// </summary>
        /// <remarks>6</remarks>
        [SupportByVersion("Word", 12, 14, 15, 16)]
        wdRelativeHorizontalPositionInnerMarginArea = 6,

        /// <summary>
        /// SupportByVersion Word 12, 14, 15, 16
        /// </summary>
        /// <remarks>7</remarks>
        [SupportByVersion("Word", 12, 14, 15, 16)]
        wdRelativeHorizontalPositionOuterMarginArea = 7
    }
}