﻿using NetOffice.Attributes;
using NetOffice.CollectionsGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    /// <summary>
    /// DispatchInterface Attachments 
    /// SupportByVersion Outlook, 9,10,11,12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864730.aspx </remarks>
    [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Custom), HasIndexProperty(IndexInvoke.Method, "Item")]
    public class Attachments : COMObject, IEnumerableProvider<NetOffice.OutlookApi.Attachment>
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
                    _type = typeof(Attachments);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public Attachments(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public Attachments(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Attachments(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864727.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Application Application
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._Application>(this, "Application");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff862724.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlObjectClass Class
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlObjectClass>(this, "Class");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868551.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._NameSpace Session
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._NameSpace>(this, "Session");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869064.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869883.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Count
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Count");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="index">object index</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [NetRuntimeSystem.Runtime.CompilerServices.IndexerName("Item"), IndexProperty]
        public NetOffice.OutlookApi.Attachment this[object index]
        {
            get
            {
                return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.Attachment>(this, "Item", NetOffice.OutlookApi.Attachment.LateBindingApiWrapperType, index);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869553.aspx </remarks>
        /// <param name="source">object source</param>
        /// <param name="type">optional object type</param>
        /// <param name="position">optional object position</param>
        /// <param name="displayName">optional object displayName</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Attachment Add(object source, object type, object position, object displayName)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.Attachment>(this, "Add", NetOffice.OutlookApi.Attachment.LateBindingApiWrapperType, source, type, position, displayName);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869553.aspx </remarks>
        /// <param name="source">object source</param>
        [CustomMethod]
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Attachment Add(object source)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.Attachment>(this, "Add", NetOffice.OutlookApi.Attachment.LateBindingApiWrapperType, source);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869553.aspx </remarks>
        /// <param name="source">object source</param>
        /// <param name="type">optional object type</param>
        [CustomMethod]
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Attachment Add(object source, object type)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.Attachment>(this, "Add", NetOffice.OutlookApi.Attachment.LateBindingApiWrapperType, source, type);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869553.aspx </remarks>
        /// <param name="source">object source</param>
        /// <param name="type">optional object type</param>
        /// <param name="position">optional object position</param>
        [CustomMethod]
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Attachment Add(object source, object type, object position)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.Attachment>(this, "Add", NetOffice.OutlookApi.Attachment.LateBindingApiWrapperType, source, type, position);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868839.aspx </remarks>
        /// <param name="index">Int32 index</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Remove(Int32 index)
        {
            Factory.ExecuteMethod(this, "Remove", index);
        }

        #endregion

        #region IEnumerableProvider<NetOffice.OutlookApi.Attachment>

        ICOMObject IEnumerableProvider<NetOffice.OutlookApi.Attachment>.GetComObjectEnumerator(ICOMObject parent)
        {
            return this;
        }

        IEnumerable IEnumerableProvider<NetOffice.OutlookApi.Attachment>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.OutlookApi.Attachment item in innerEnumerator)
                yield return item;
        }

        #endregion

        #region IEnumerable<NetOffice.OutlookApi.Attachment>

        /// <summary>
        /// SupportByVersion Outlook, 9,10,11,12,14,15,16
        /// This is a custom enumerator from NetOffice
        /// </summary>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [CustomEnumerator]
        public IEnumerator<NetOffice.OutlookApi.Attachment> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.OutlookApi.Attachment item in innerEnumerator)
                yield return item;
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// SupportByVersion Outlook, 9,10,11,12,14,15,16
        /// This is a custom enumerator from NetOffice
        /// </summary>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [CustomEnumerator]
        IEnumerator NetRuntimeSystem.Collections.IEnumerable.GetEnumerator()
        {
            int count = Count;
            object[] enumeratorObjects = new object[count];
            for (int i = 0; i < count; i++)
                enumeratorObjects[i] = this[i + 1];

            foreach (object item in enumeratorObjects)
                yield return item;
        }

        #endregion

#pragma warning restore
    }
}