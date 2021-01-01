using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Method or property returns a native COM proxy
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class NativeResultAttribute : System.Attribute
    {
    }
}
