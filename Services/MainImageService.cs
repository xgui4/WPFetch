using DesktopWallpaper;
using WPFetch.Model.Enums;

namespace WPFetch.Backend
{
    public class MainImageService
    {
        private readonly App app;

        private const string MainImageArg = "os-tan=";
        private const string WindowsVerImageArg = "windowsver=";

        public MainImageService(App app)
        {
            this.app = app;
        }
        private string GetDefaultOSTanPath()
        {
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22000))
                return Os_Tan.WINDOWS_11.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
                return Os_Tan.WINDOWS_10.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
                return Os_Tan.WINDOWS_8.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
                return Os_Tan.WINDOWS_7.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
                return Os_Tan.WINDOWS_VISTA.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
                return Os_Tan.WINDOWS_XP.GetOsTanPathImgPath();
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
                return Os_Tan.WINDOWS_2000.GetOsTanPathImgPath();
            else
                return Os_Tan.NT.GetOsTanPathImgPath();
        }

        public string RequestOSTanPath()
        {
            return (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(MainImageArg))) switch
            {
                $"{MainImageArg}11_ALT" => Os_Tan.WINDOWS_11_ALT.GetOsTanPathImgPath(),
                $"{MainImageArg}11" => Os_Tan.WINDOWS_11.GetOsTanPathImgPath(),
                $"{MainImageArg}10" => Os_Tan.WINDOWS_10.GetOsTanPathImgPath(),
                $"{MainImageArg}8" => Os_Tan.WINDOWS_8.GetOsTanPathImgPath(),
                $"{MainImageArg}7" => Os_Tan.WINDOWS_7.GetOsTanPathImgPath(),
                $"{MainImageArg}vista" => Os_Tan.WINDOWS_VISTA.GetOsTanPathImgPath(),
                $"{MainImageArg}xp" => Os_Tan.WINDOWS_XP.GetOsTanPathImgPath(),
                $"{MainImageArg}2000" => Os_Tan.WINDOWS_2000.GetOsTanPathImgPath(),
                $"{MainImageArg}ME" => Os_Tan.WINDOWS_ME.GetOsTanPathImgPath(),
                $"{MainImageArg}1" => Os_Tan.WINDOWS_1.GetOsTanPathImgPath(),
                $"{MainImageArg}2" => Os_Tan.WINDOWS_2.GetOsTanPathImgPath(),
                $"{MainImageArg}3.1" => Os_Tan.WINDOWS_3dot1.GetOsTanPathImgPath(),
                $"{MainImageArg}3" => Os_Tan.WINDOWS_3dot1.GetOsTanPathImgPath(),
                $"{MainImageArg}NT" => Os_Tan.NT.GetOsTanPathImgPath(),
                $"{MainImageArg}95" => Os_Tan.WINDOWS_95.GetOsTanPathImgPath(),
                $"{MainImageArg}97" => Os_Tan.WINDOWS_97.GetOsTanPathImgPath(),
                $"{MainImageArg}98" => Os_Tan.WINDOWS_98.GetOsTanPathImgPath(),
                $"{MainImageArg}Neptune" => Os_Tan.WINDOWS_NEPTUNE.GetOsTanPathImgPath(),
                $"{MainImageArg}Odyssey" => Os_Tan.WINDOWS_ODYSSEY.GetOsTanPathImgPath(),
                $"{MainImageArg}server_2K3" => Os_Tan.WINDOWS_SERVER_2003.GetOsTanPathImgPath(),
                $"{MainImageArg}server_2K8" => Os_Tan.WINDOWS_SERVER_2008.GetOsTanPathImgPath(),
                _ => GetDefaultOSTanPath(),
            };
        }

        private string GetDefaultWindowsVerImage()
        {
            if (app.Theme == "Dark")
            {
                return GetWindowsVerImagePathDarkMode();
            }
            else
            {
                return GetWindowsVerImagePathLightMode();
            }
        }

        public string RequestWindowsVerLogoPath()
        {
            if (app.Theme == "Dark")
            {
                return (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(WindowsVerImageArg))) switch
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
                return (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(WindowsVerImageArg))) switch
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
}
