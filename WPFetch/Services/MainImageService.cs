using WPFetch;

using WPFetch.Model.Enums;

namespace WPFetch.Services;

/// <summary>
/// The main image of the application (the os-tan and os logo) service manager
/// </summary>
public class MainImageService
{
    private readonly App _app;

    private const string MainImageArg = "os-tan=";
    private const string WindowsVerImageArg = "windowsver=";

    /// <summary>
    /// The Main image service constructor, with an App object as parameters 
    /// </summary>
    /// <param name="app">the App Image</param>
    public MainImageService(App app)
    {
        _app = app;
    }
    private string GetDefaultOSTanPath()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22000))
            return Os_Tan.Windows11.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
            return Os_Tan.Windows10.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
            return Os_Tan.Windows8.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
            return Os_Tan.Windows7.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
            return Os_Tan.WindowsVista.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
            return Os_Tan.WindowsXP.GetOsTanPathImgPath();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
            return Os_Tan.Windows2000.GetOsTanPathImgPath();
        else
            return Os_Tan.NT.GetOsTanPathImgPath();
    }

    /// <summary>
    /// Request the os-tan image file.
    /// </summary>
    /// <returns>the OS-Tan image file</returns>
    public string RequestOSTanPath()
    {
        return (_app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(MainImageArg))) switch
        {
            $"{MainImageArg}11_ALT" => Os_Tan.Windows11Alt.GetOsTanPathImgPath(),
            $"{MainImageArg}11" => Os_Tan.Windows11.GetOsTanPathImgPath(),
            $"{MainImageArg}10" => Os_Tan.Windows10.GetOsTanPathImgPath(),
            $"{MainImageArg}8" => Os_Tan.Windows8.GetOsTanPathImgPath(),
            $"{MainImageArg}7" => Os_Tan.Windows7.GetOsTanPathImgPath(),
            $"{MainImageArg}vista" => Os_Tan.WindowsVista.GetOsTanPathImgPath(),
            $"{MainImageArg}xp" => Os_Tan.WindowsXP.GetOsTanPathImgPath(),
            $"{MainImageArg}2000" => Os_Tan.Windows2000.GetOsTanPathImgPath(),
            $"{MainImageArg}ME" => Os_Tan.WindowsME.GetOsTanPathImgPath(),
            $"{MainImageArg}1" => Os_Tan.Windows1.GetOsTanPathImgPath(),
            $"{MainImageArg}2" => Os_Tan.Windows2.GetOsTanPathImgPath(),
            $"{MainImageArg}3.1" => Os_Tan.Windows3Dot1.GetOsTanPathImgPath(),
            $"{MainImageArg}3" => Os_Tan.Windows3Dot1.GetOsTanPathImgPath(),
            $"{MainImageArg}NT" => Os_Tan.NT.GetOsTanPathImgPath(),
            $"{MainImageArg}95" => Os_Tan.Windows95.GetOsTanPathImgPath(),
            $"{MainImageArg}97" => Os_Tan.Windows7.GetOsTanPathImgPath(),
            $"{MainImageArg}98" => Os_Tan.Windows98.GetOsTanPathImgPath(),
            $"{MainImageArg}Neptune" => Os_Tan.WindowsNeptune.GetOsTanPathImgPath(),
            $"{MainImageArg}Odyssey" => Os_Tan.WindowsOdyssey.GetOsTanPathImgPath(),
            $"{MainImageArg}server_2K3" => Os_Tan.WindowsServer2003.GetOsTanPathImgPath(),
            $"{MainImageArg}server_2K8" => Os_Tan.WindowsServer2008.GetOsTanPathImgPath(),
            _ => GetDefaultOSTanPath(),
        };
    }

    private string GetDefaultWindowsVerImage()
    {
        return _app.Theme == "Dark" ? GetWindowsVerImagePathDarkMode() : GetWindowsVerImagePathLightMode();
    }

    /// <summary>
    /// Retrieves the file path for the Windows version logo based on the application's theme and command-line
    /// arguments.  
    /// </summary>
    /// <returns>A string representing the file path of the Windows version logo.</returns>
    public string RequestWindowsVerLogoPath()
    {
        if (_app.Theme == "Dark")
        {
            return (_app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(WindowsVerImageArg))) switch
            {
                $"{WindowsVerImageArg}11" => WindowsVerImage.WIN_11.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}10" => WindowsVerImage.WIN_10.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}8" => WindowsVerImage.WIN_8.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}7" => WindowsVerImage.WIN_7.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}vista" => WindowsVerImage.WIN_VISTA.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}xp" => WindowsVerImage.WIN_XP.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}2000" => WindowsVerImage.WIN_2K.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}ME" => WindowsVerImage.WIN_ME.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}1" => WindowsVerImage.WIN_1.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}2" => WindowsVerImage.WIN_2.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}3.1" => WindowsVerImage.WIN_3.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}3" => WindowsVerImage.WIN_3.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}NT" => WindowsVerImage.WIN_NT.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}95" => WindowsVerImage.WIN_95.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}98" => WindowsVerImage.WIN_98.GetWindowsVerPathForDarkMode(),
                $"{WindowsVerImageArg}Neptune" => WindowsVerImage.WIN_NEPTUNE.GetWindowsVerPathForDarkMode(),
                _ => GetDefaultWindowsVerImage(),
            };
        }
        else
        {
            return (_app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(WindowsVerImageArg))) switch
            {
                $"{WindowsVerImageArg}11" => WindowsVerImage.WIN_11.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}10" => WindowsVerImage.WIN_10.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}8" => WindowsVerImage.WIN_8.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}7" => WindowsVerImage.WIN_7.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}vista" => WindowsVerImage.WIN_VISTA.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}xp" => WindowsVerImage.WIN_XP.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}2000" => WindowsVerImage.WIN_2K.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}ME" => WindowsVerImage.WIN_ME.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}1" => WindowsVerImage.WIN_1.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}2" => WindowsVerImage.WIN_2.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}3.1" => WindowsVerImage.WIN_3.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}3" => WindowsVerImage.WIN_3.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}NT" => WindowsVerImage.WIN_NT.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}95" => WindowsVerImage.WIN_95.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}98" => WindowsVerImage.WIN_98.GetWindowsVerPathForLightMode(),
                $"{WindowsVerImageArg}Neptune" => WindowsVerImage.WIN_NEPTUNE.GetWindowsVerPathForLightMode(),
                _ => GetDefaultWindowsVerImage(),
            };
        }
    }
    private static string GetWindowsVerImagePathLightMode()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22000))
            return WindowsVerImage.WIN_11.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
            return WindowsVerImage.WIN_10.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
            return WindowsVerImage.WIN_8.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
            return WindowsVerImage.WIN_7.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
            return WindowsVerImage.WIN_VISTA.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
            return WindowsVerImage.WIN_XP.GetWindowsVerPathForLightMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
            return WindowsVerImage.WIN_2K.GetWindowsVerPathForLightMode();
        else
            return WindowsVerImage.WIN_NT.GetWindowsVerPathForLightMode();
    }

    private static string GetWindowsVerImagePathDarkMode()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22000))
            return WindowsVerImage.WIN_11.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
            return WindowsVerImage.WIN_10.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
            return WindowsVerImage.WIN_8.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
            return WindowsVerImage.WIN_7.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
            return WindowsVerImage.WIN_VISTA.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
            return WindowsVerImage.WIN_XP.GetWindowsVerPathForDarkMode();
        if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
            return WindowsVerImage.WIN_2K.GetWindowsVerPathForDarkMode();
        else
            return WindowsVerImage.WIN_NT.GetWindowsVerPathForDarkMode();
    }
}
