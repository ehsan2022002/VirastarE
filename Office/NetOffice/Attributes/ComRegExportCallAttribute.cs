using System;

namespace NetOffice.Attributes
{
    /// <summary>
    /// Indicates a static method is to call from RegAddin while create a register file(.reg)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ComRegExportCallAttribute : System.Attribute
    {

    }
}
