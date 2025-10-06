// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

using System.Runtime.InteropServices;
using Npp.DotNet.Plugin;
using static Npp.DotNet.Plugin.Winforms.WinGDI;
using static Npp.DotNet.Plugin.Winforms.WinUser;

namespace RedisPlugin
{
    partial class Main : IDotNetPlugin
    {
        #region "Implement the plugin interface"
        /// <summary>
        /// This method runs when Notepad++ calls the 'setInfo' API function.
        /// You can assume the application window handle is valid here.
        /// </summary>
        public void OnSetInfo()
        {       
            (int maj, int min, int patch) = PluginData.Notepad.GetNppVersion();

            Utils.SetCommand(
                "Show dialog",
                ToggleDialog,
                new ShortcutKey(ctrl: false, alt: true, shift: false, Keys.F10));

            Utils.MakeSeparator();
              
            Utils.SetCommand(
                "About",
                () => { 
                    var dialog = new AboutDialog();
                    dialog.ShowDialog();
                },
                new ShortcutKey(ctrl: true, alt: false, shift: true, Keys.F12));

            // TODO: Add a command to manage plugin settings:
            // 1. Enter your project's *.csproj directory and run: `dotnet new npp-plugin-ini`
            // 2. Uncomment the following:

            Utils.SetCommand(
                "Open settings file",
                () =>
                {
                    var config = new IniFile();
                    config.OpenFile();
                },
                new ShortcutKey(ctrl: false, alt: true, shift: false, Keys.F5));

        }

        /// <summary>
        /// This method runs when Notepad++ calls the 'beNotified' API function.
        /// </summary>
        public void OnBeNotified(ScNotification notification)
        {
            // TODO: provide callbacks for editor events and notifications.
            // For example:
            if (notification.Header.HwndFrom == PluginData.NppData.NppHandle)
            {
                uint code = notification.Header.Code;
                switch ((NppMsg)code)
                {
                    case NppMsg.NPPN_READY:
                        // TODO: perform late-phase initialization
                        break;
                    case NppMsg.NPPN_TBMODIFICATION:
                        PluginData.FuncItems.RefreshItems();                     
                        break;
                    case NppMsg.NPPN_DARKMODECHANGED:
                        _form1?.ToggleDarkMode(PluginData.Notepad.IsDarkModeEnabled());
                        break;
                    case NppMsg.NPPN_SHUTDOWN:
                        PluginCleanUp();
                        break;
                }
            }
        }

        /// <summary>
        /// This method runs when Notepad++ calls the 'onMessageProc' API function.
        /// </summary>
        public NativeBool OnMessageProc(uint msg, UIntPtr wParam, IntPtr lParam)
        {
            // TODO: provide callbacks for Win32 window messages.
            return Win32.TRUE;
        }
        #endregion

        #region "Initialize your plugin's properties"
        /// <summary>
        /// The main constructor must be static to ensure data is initialized *before*
        /// the Notepad++ application calls any unmanaged methods.
        /// At the very least, assign a unique name to 'Npp.DotNet.Plugin.PluginData.PluginNamePtr',
        /// otherwise the default name -- "Npp.DotNet.Plugin" -- will be used.
        /// </summary>
        static Main()
        {
            Instance = new Main();
            PluginData.PluginNamePtr = Marshal.StringToHGlobalUni($"{PluginName}\0");
        }

        /// <summary>
        /// Object reference to the main class -- must be initialized statically!
        /// </summary>
        static readonly IDotNetPlugin Instance;

        /// <summary>
        /// The unique name of the plugin -- appears in the 'Plugins' drop-down menu
        /// </summary>
        static readonly string PluginName = "Redis";

        /// <summary>
        /// Index within <see cref="PluginData.FuncItems"/> of the plugin command that launches the docking dialog.
        /// </summary>
        static readonly int DialogIndex = 1;

        /// <summary>
        /// Default dimensions of a 16x16 BMP icon.
        /// </summary>
        static readonly int MinBmpSize = 16;

        /// <summary>
        /// Default dimensions of a 32x32 ICO icon.
        /// </summary>
        static readonly int MinIcoSize = 32;

        /// <inheritdoc cref="Npp.DotNet.Plugin.Extensions.NppUtils.AssemblyVersionString"/>
        static string AssemblyVersionString
        {
            get
            {
                string version = "1.0.0.0";
                try
                {
                    string assemblyName = typeof(Main).Namespace!;
                    version =
                        System.Diagnostics.FileVersionInfo.GetVersionInfo(
                            Path.Combine(
                                PluginData.Notepad.GetPluginsHomePath(), assemblyName, $"{assemblyName}.dll")
                            )
                        .FileVersion!;
                }
                catch { }
                return version;
            }
        }

   
        /// <inheritdoc cref="Npp.DotNet.Plugin.Winforms.Classes.DockingForm"/>
        Form1? _form1 = null;
        #endregion

        #region "Define your plugin's business logic"
        /// <summary>
        /// Clean up resources.
        /// </summary>
        void PluginCleanUp()
        {
            _form1?.Dispose();
            PluginData.FuncItems.Dispose();
            PluginData.PluginNamePtr = IntPtr.Zero;
        }

        /// <summary>
        /// Show or hide the docking dialog, creating it first, if needed.
        /// </summary>
        void ToggleDialog()
        {
            if (_form1 == null)
            {    
                _form1 = new Form1(DialogIndex, $"{PluginName}.dll",null);
                return;
            }

            if (!_form1.Visible)
                _form1.ShowDockingForm();
            else
                _form1.HideDockingForm();
        }             
        #endregion
    }
}
