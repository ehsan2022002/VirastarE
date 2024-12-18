﻿using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Indicates a class or interface is a base class/interface to bypass COM/C# syntax incompatibilities
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class SyntaxBypassAttribute : System.Attribute
    {
    }
}
