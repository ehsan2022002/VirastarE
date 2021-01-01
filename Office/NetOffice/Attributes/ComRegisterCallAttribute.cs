using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Indicates a static method is to call from RegAddin while register addin
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ComRegisterCallAttribute : System.Attribute
    {

    }
}
