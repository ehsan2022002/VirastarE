using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    /// <summary>
    /// DispatchInterface _CategoryRuleCondition 
    /// SupportByVersion Outlook, 12,14,15,16
    /// </summary>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), BaseType]
    public class _CategoryRuleCondition : COMObject
    {
#pragma warning disable

        #region Type Information

        /// <summary>
        /// Instance Type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), Category("NetOffice"), CoreOverridden]
        public override Type InstanceType
        {
            get
            {
                return LateBindingApiWrapperType;
            }
        }

        private static Type _type;

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(_CategoryRuleCondition);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public _CategoryRuleCondition(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public _CategoryRuleCondition(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _CategoryRuleCondition(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864750.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Application Application
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._Application>(this, "Application");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864455.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlObjectClass Class
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlObjectClass>(this, "Class");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869796.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._NameSpace Session
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._NameSpace>(this, "Session");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868817.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff860359.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public bool Enabled
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "Enabled");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Enabled", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff861565.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlRuleConditionType ConditionType
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlRuleConditionType>(this, "ConditionType");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866733.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public object Categories
        {
            get
            {
                return Factory.ExecuteVariantPropertyGet(this, "Categories");
            }
            set
            {
                Factory.ExecuteVariantPropertySet(this, "Categories", value);
            }
        }

        #endregion

        #region Methods

        #endregion

#pragma warning restore
    }
}
