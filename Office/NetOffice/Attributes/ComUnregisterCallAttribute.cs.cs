using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Indicates a static method is to call from RegAddin while unregister addin
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ComUnregisterCallAttribute : System.Attribute
    {
    }
}
