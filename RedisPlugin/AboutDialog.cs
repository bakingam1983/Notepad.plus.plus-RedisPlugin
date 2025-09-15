using Npp.DotNet.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisPlugin
{
    public partial class AboutDialog : Form
    {        
        public AboutDialog()
        {
            InitializeComponent();

            string assemblyName = typeof(Main).Namespace!;
            LblVersion.Text=System.Diagnostics.FileVersionInfo.GetVersionInfo(
                            Path.Combine(
                                PluginData.Notepad.GetPluginsHomePath(), assemblyName, $"{assemblyName}.dll")
                            )
                        .FileVersion!;
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e)
        {                        
            var info = new System.Diagnostics.ProcessStartInfo();
            info.UseShellExecute = true;
            info.FileName=linkLabel1.Text;
            System.Diagnostics.Process.Start(info);
        }
    }
}
