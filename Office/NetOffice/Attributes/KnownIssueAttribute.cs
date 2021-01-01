using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Method or property has known issues
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    public class KnownIssueAttribute : System.Attribute
    {
    }
}