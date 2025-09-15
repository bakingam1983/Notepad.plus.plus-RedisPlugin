// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

namespace RedisPlugin;

using Npp.DotNet.Plugin;
using Npp.DotNet.Plugin.Extensions;
using System.ComponentModel;
using System.IO;

public class IniFile : DefaultSettings
{
    #region "Redis Default Server"
    [Description("Redis default server"), Category("Strings")]
    public string RedisDefaultServer { get; set; } = "";
    
    //[Description("A sample enum property"), Category("Enum")]
    //public ConsoleColor Color { get; set; } = ConsoleColor.Green;

    //[Description("A sample Boolean property"), Category("Boolean")]
    //public bool AutoClose { get; set; } = false;

    //[Description("A sample integer property"), Category("Integer")]
    //public int MarginWidth { get; set; } = 16;

    //[Description("A sample floating point property"), Category("Double")]
    public double Scale { get; set; } = 2.5;
    #endregion

    public IniFile() : base()
    {
        if (!File.Exists(FilePath)) Save(FilePath);
    }

    public string FilePath { get => Path.Combine(PluginData.Notepad.GetConfigDirectory(), FileName); }

    /// <inheritdoc cref="DefaultSettings.OpenFile"/>
    public override void OpenFile() => PluginData.Notepad.OpenFile(FilePath);

    readonly string FileName = $"{typeof(IniFile).Namespace!.Trim(['\0', '.', '\x20'])}.ini";
}
