// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Npp.DotNet.Plugin;

namespace RedisPlugin
{
    partial class Main
    {
        #region "======================== **DO NOT EDIT** ========================"
        [UnmanagedCallersOnly(EntryPoint = "setInfo", CallConvs = [typeof(CallConvCdecl)])]
        internal unsafe static void SetInfo(NppData* notepadPlusData)
        {
            PluginData.NppData = *notepadPlusData;
            Instance.OnSetInfo();
        }

        [UnmanagedCallersOnly(EntryPoint = "beNotified", CallConvs = [typeof(CallConvCdecl)])]
        internal unsafe static void BeNotified(ScNotification* notification)
        {
            Instance.OnBeNotified(*notification);
        }

        [UnmanagedCallersOnly(EntryPoint = "messageProc", CallConvs = [typeof(CallConvCdecl)])]
        internal static NativeBool MessageProc(uint msg, UIntPtr wParam, IntPtr lParam)
        {
            return Instance.OnMessageProc(msg, wParam, lParam);
        }

        [UnmanagedCallersOnly(EntryPoint = "getFuncsArray", CallConvs = [typeof(CallConvCdecl)])]
        internal static IntPtr GetFuncsArray(IntPtr nbF) => IDotNetPlugin.OnGetFuncsArray(nbF);

        [UnmanagedCallersOnly(EntryPoint = "getName", CallConvs = [typeof(CallConvCdecl)])]
        internal static IntPtr GetName() => IDotNetPlugin.OnGetName();

        [UnmanagedCallersOnly(EntryPoint = "isUnicode", CallConvs = [typeof(CallConvCdecl)])]
        internal static NativeBool IsUnicode() => IDotNetPlugin.OnIsUnicode();
        #endregion
    }
}
