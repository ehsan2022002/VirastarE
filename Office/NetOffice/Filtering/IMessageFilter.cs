﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetOffice.Filtering
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms693740%28v=vs.85%29.aspx
    /// </summary>
    [ComImport, ComConversionLoss, InterfaceType((short)1), Guid("00000016-0000-0000-C000-000000000046")]
    public interface IMessageFilter
    {
        /// <summary>
        /// Provides a single entry point for incoming calls.
        /// </summary>
        /// <param name="dwCallType">The type of incoming call that has been received. Possible values are from the enumeration CALLTYPE</param>
        /// <param name="htaskCaller">The thread id of the caller</param>
        /// <param name="dwTickCount">The elapsed tick count since the outgoing call was made, if dwCallType is not CALLTYPE_TOPLEVEL. If dwCallType is CALLTYPE_TOPLEVEL, dwTickCount should be ignored</param>
        /// <param name="lpInterfaceInfo">A pointer to an INTERFACEINFO structure that identifies the object, interface, and method being called. In the case of DDE calls, lpInterfaceInfo can be NULL because the DDE layer does not return interface information.</param>
        /// <returns>
        /// This method can return the following values
        /// SERVERCALL_ISHANDLED - The application might be able to process the call
        /// SERVERCALL_REJECTED - The application cannot handle the call due to an unforeseen problem, such as network unavailability, or if it is in the process of terminating
        /// SERVERCALL_RETRYLATER - The application cannot handle the call at this time. An application might return this value when it is in a user-controlled modal state
        /// </returns>
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int HandleInComingCall([In] uint dwCallType, [In] IntPtr htaskCaller, [In] uint dwTickCount, [In, MarshalAs(UnmanagedType.LPArray)] InterfaceInfo[] lpInterfaceInfo);

        /// <summary>
        /// Provides applications with an opportunity to display a dialog box offering retry, cancel, or task-switching options.
        /// </summary>
        /// <param name="htaskCallee">The thread id of the called application</param>
        /// <param name="dwTickCount">The number of elapsed ticks since the call was made</param>
        /// <param name="dwRejectType">Specifies either SERVERCALL_REJECTED or SERVERCALL_RETRYLATER, as returned by the object application</param>
        /// <returns>
        /// This method can return the following value
        /// -1 - The call should be canceled. COM then returns RPC_E_CALL_REJECTED from the original method call
        /// 0 ≤ value ≤ 100 - The call is to be retried immediately.
        /// 100 ≤ value - COM will wait for this many milliseconds and then retry the call
        /// </returns>
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int RetryRejectedCall([In] IntPtr htaskCallee, [In] uint dwTickCount, [In] uint dwRejectType);

        /// <summary>
        /// Indicates that a message has arrived while COM is waiting to respond to a remote call.
        /// </summary>
        /// <param name="htaskCallee">The thread id of the called application</param>
        /// <param name="dwTickCount">The number of ticks since the call was made. It is calculated from the GetTickCount function</param>
        /// <param name="dwPendingType">The type of call made during which a message or event was received. Possible values are from the enumeration PENDINGTYPE, where PENDINGTYPE_TOPLEVEL means the outgoing call was not nested within a call from another application and PENDINTGYPE_NESTED means the outgoing call was nested within a call from another application.</param>
        /// <returns>
        /// This method can return the following values
        /// PENDINGMSG_CANCELCALL - Cancel the outgoing call
        /// PENDINGMSG_WAITNOPROCESS - Continue waiting for the reply, and do not dispatch the message unless it is a task-switching or window-activation message
        /// PENDINGMSG_WAITDEFPROCESS - Keyboard and mouse messages are no longer dispatched. However there are some cases where mouse and keyboard messages could cause the system to deadlock, and in these cases, mouse and keyboard messages are discarded. WM_PAINT messages are dispatched
        /// </returns>
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int MessagePending([In] IntPtr htaskCallee, [In] uint dwTickCount, [In] uint dwPendingType);
    }
}
