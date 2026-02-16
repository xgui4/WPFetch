# WPFetch

<img src="Assets/icons/appicon.png" alt="WPFetch Logo" width="75" height="75">

> [!Note]
> This project is a hobby project and may be one day stopped being updated and isnt covered by any warranty

## Summary

A utility to fetch you system info with a OS-tan

## Features

- Fetch you hardware like noefetch does but with a GUI and with customisable main image
- Show OS-Tan as main images and windows logo on top on of the setup info
- Command line argurment
- Configuration via GUI (coming soon)
- Link for a the github release page in the check update button (might do more in the future)

## Nuget Packages && Framework used

- Community Toolkit
- FluentSysInfo.Core
- Newtonsoft.Json
- System.Drawing.Common
- System.Management
- Windows Presentation Foundation
- Inno Setup for the installer

## Compilation and Installation

- **Option 1: Compile from Source**

    **Install the app**
    1. ```dotnet publish``` with the right arch (X86 or X86-64 are officially supported) on the path of the source code
    2. Open the installer script file in Inno Setup for the desirable architecture.
    3. Compile the installer.
    4. Open the installer as admin (if you run it as a normal user, it will not install correctly).
    5. Reboot the computer when the installer has finished (required to register the app for cmd.exe).
    6. If you are in Windows 10 amd before you need to intall this font from this website : https://aka.ms/SegoeFluentIcons
    7. You are now done!

    **Create a portable app**
    1. ```dotnet publish``` with the right arch (X86 or X86-64 are officially supported) on the path of the source code
    2. Add the bin path (where you download or unzip the source code) to the PATH (tutorial: <https://windowsloop.com/how-to-add-to-windows-path/>).
    3. Confirm the change, try in a new cmd prompt. If it doesn't work, try to reboot.
    4. If you are in Windows 10 amd before you need to intall this font from this website : https://aka.ms/SegoeFluentIcons
    5. You are now done!

- **Option 2: Use the "stable" installer file from GitHub Release**

    1. Open the installer as admin (if you run it as a normal user, it will not install correctly).
    2. Reboot the computer when the installer has finished (required to register the app for cmd.exe).
    3. If you are in Windows 10 amd before you need to intall this font from this website : https://aka.ms/SegoeFluentIcons
    4. You are now done!

- **Option 3: Download the portable app (.zip)**

    1. Download the .zip file.
    2. Unzip the folder to the desirable path.
    3. Add the bin path to the PATH (tutorial: <https://windowsloop.com/how-to-add-to-windows-path/>).
    4. Confirm the change, try in a new cmd prompt. If it doesn't work, try to reboot.
    5. If you are in Windows 10 amd before you need to intall this font from this website : https://aka.ms/SegoeFluentIcons
    6. You are now done!

## License

MIT

## Credits

[Images Credits](THANKS.md)

## Legal disclaimer

This product isn't a official product by Microsoft and isn't affliated (and never will) by them.
