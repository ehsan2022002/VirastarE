using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;
using VBIDE = NetOffice.VBIDEApi;
using NetOffice.VBIDEApi.Enums;

namespace VirastarE
{
    public partial class MyTaskPane : UserControl , Office.Tools.ITaskPane
    {
		#region Ctor
        
		public MyTaskPane()
        {
            InitializeComponent();
        }

		#endregion

		#region Properties
		
		private Addin ParentAddin { get; set; }

		#endregion
		
        #region ITaskpane

        public void OnConnection(ICOMObject application, Office._CustomTaskPane parentPane, object[] customArguments)
        {
			if(customArguments.Length > 0)
				ParentAddin = customArguments[0] as Addin;
        }

        public void OnDisconnection()
        {

        }

        public void OnDockPositionChanged(MsoCTPDockPosition position)
        {
            
        }

        public void OnVisibleStateChanged(bool visible)
        {
			if(null != ParentAddin && null != ParentAddin.RibbonUI)
				ParentAddin.RibbonUI.InvalidateControl("tooglePaneVisibleButton");
        }

        #endregion
    }
}
