namespace NetOffice.OfficeApi.Tools
{
    /// <summary>
    ///  Represents an addin implementation trough IDTExtensibility2 and Ribbon/TaskPane support
    /// </summary>
    public interface IOfficeCOMAddin : NetOffice.Tools.ICOMAddin, Native.IRibbonExtensibility, Native.ICustomTaskPaneConsumer
    {
    }
}