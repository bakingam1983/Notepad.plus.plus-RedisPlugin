RedisPlugin
=============

Building
--------

### Using Visual Studio

- Double-click the `RedisPlugin.csproj` file

- Select "Build" from the main menu, then "Publish Selection".
  Alternatively, right-click on the project and select "Publish..." from the context menu

- To start a build, click "Publish"

#### Note

Default profiles have been provided for the x64 and ARM64 runtimes. To change a profile,
click the <kbd>&#x25BD;</kbd> button beside the current profile's file name, e.g., `FolderProfile.pubxml`:

<img alt="Select a Publish Profile" width="500"
src="https://raw.githubusercontent.com/npp-dotnet/Npp.DotNet.Plugin/refs/heads/main/doc/img/vs2022-select-publish-profile.png">

A profile can also be configured using the IDE's edit controls. For example, to have the native DLL
written directly to the plugin load path of a Notepad++ installation, set the "Target location" to the
plugin load path's directory:

<img alt="Configure Target Location" width="500"
src="https://raw.githubusercontent.com/npp-dotnet/Npp.DotNet.Plugin/refs/heads/main/doc/img/vs2022-config-profile-target-loc.png">

### Using the [Developer Command Prompt or PowerShell](https://learn.microsoft.com/visualstudio/ide/reference/command-prompt-powershell)

- Make a folder named `RedisPlugin` in the `plugins` directory of a 64-bit Notepad++ installation:

  * __Fully installed versions *(requires elevated privleges)*__
    + `%ProgramFiles%\Notepad++\plugins\RedisPlugin`

  * __Portable versions__
    + Locate the folder where `notepad++.exe` is installed
    + `$(PORTABLE_INSTALLATION_PATH)\plugins\RedisPlugin`

- Change into the same directory as `RedisPlugin.csproj`

- To build for x86_64 Notepad++:

        dotnet publish -f net9.0-windows -r win-x64 -o $(PLUGIN_FOLDER_PATH)

- To build for ARM64 Notepad++:

        dotnet publish -f net9.0-windows -r win-arm64 -o $(PLUGIN_FOLDER_PATH)
