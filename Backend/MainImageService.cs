using DesktopWallpaper;
using WPFetch.Model.Enums;

namespace WPFetch.Backend
{
    public class MainImageService
    {
        private readonly App app;

        private const string MainImageArg = "os-tan=";
        private const string WindowsVerImageArg = "windowsver=";
 
        private const string NoOsTanFound = "This Windows Version doesn't have a OS-Tan Yet or doesn't exist";

        public MainImageService(App app)
        {
            this.app = app;
        }
        public string GetDefaultOSTanPath()
        {
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22))
            {
                return Os_Tan.WINDOWS_11.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
            {
                return Os_Tan.WINDOWS_10.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
            {
                return Os_Tan.WINDOWS_8.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
            {
                return Os_Tan.WINDOWS_7.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
            {
                return Os_Tan.WINDOWS_VISTA.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
            {
                return Os_Tan.WINDOWS_XP.GetOsTanPathImgPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
            {
                return Os_Tan.WINDOWS_2000.GetOsTanPathImgPath();
            }
            else
            {
                return Os_Tan.NT.GetOsTanPathImgPath();
            }
        }

        public string GetOSTanPathWithCmdArgs()
        {
            switch (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(MainImageArg)))
            {
                case $"{MainImageArg}11":
                    return Os_Tan.WINDOWS_11.GetOsTanPathImgPath();
                case $"{MainImageArg}10":
                    return Os_Tan.WINDOWS_10.GetOsTanPathImgPath();
                case $"{MainImageArg}8":
                    return Os_Tan.WINDOWS_8.GetOsTanPathImgPath();
                case $"{MainImageArg}7":
                    return Os_Tan.WINDOWS_7.GetOsTanPathImgPath();
                case $"{MainImageArg}vista":
                    return Os_Tan.WINDOWS_VISTA.GetOsTanPathImgPath();
                case $"{MainImageArg}xp":
                    return Os_Tan.WINDOWS_XP.GetOsTanPathImgPath();
                case $"{MainImageArg}2000":
                    return Os_Tan.WINDOWS_2000.GetOsTanPathImgPath();
                case $"{MainImageArg}ME":
                    return Os_Tan.WINDOWS_ME.GetOsTanPathImgPath();
                case $"{MainImageArg}1":
                    return Os_Tan.WINDOWS_1.GetOsTanPathImgPath();
                case $"{MainImageArg}2":
                    return Os_Tan.WINDOWS_2.GetOsTanPathImgPath();
                case $"{MainImageArg}3.1":
                    return Os_Tan.WINDOWS_3dot1.GetOsTanPathImgPath();
                case $"{MainImageArg}3":
                    return Os_Tan.WINDOWS_3dot1.GetOsTanPathImgPath();
                case $"{MainImageArg}NT":
                    return Os_Tan.NT.GetOsTanPathImgPath();
                case $"{MainImageArg}95":
                    return Os_Tan.WINDOWS_95.GetOsTanPathImgPath();
                case $"{MainImageArg}97":
                    return Os_Tan.WINDOWS_97.GetOsTanPathImgPath();
                case $"{MainImageArg}98":
                    return Os_Tan.WINDOWS_98.GetOsTanPathImgPath();
                case $"{MainImageArg}Neptune":
                    return Os_Tan.WINDOWS_NEPTUNE.GetOsTanPathImgPath();
                case $"{MainImageArg}Odyssey":
                    return Os_Tan.WINDOWS_ODYSSEY.GetOsTanPathImgPath();
                case $"{MainImageArg}server_2K3":
                    return Os_Tan.WINDOWS_SERVER_2003.GetOsTanPathImgPath();
                case $"{MainImageArg}server_2K8":
                    return Os_Tan.WINDOWS_SERVER_2008.GetOsTanPathImgPath();
                default:
                    Console.WriteLine(NoOsTanFound);
                    return Os_Tan.NT.GetOsTanPathImgPath();
            }
        }

        public string GetDefaultWindowsVerImage()
        {
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 22))
            {
                return WindowsVerImage.WIN_11.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 10, 0, 0))
            {
                return WindowsVerImage.WIN_10.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 2, 0))
            {
                return WindowsVerImage.WIN_8.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 1, 0))
            {
                return WindowsVerImage.WIN_7.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 6, 0, 0))
            {
                return WindowsVerImage.WIN_VISTA.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 1, 0))
            {
                return WindowsVerImage.WIN_XP.GetWindowsVerPath();
            }
            if (OperatingSystem.IsOSPlatformVersionAtLeast("Windows", 5, 0, 0))
            {
                return WindowsVerImage.WIN_2K.GetWindowsVerPath();
            }
            else
            {
                return WindowsVerImage.WIN_NT.GetWindowsVerPath();
            }
        }

        public string GetWindowsVerImageWithCmdArgs()
        {
            switch (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith(WindowsVerImageArg)))
            {
                case $"{WindowsVerImageArg}11":
                    return WindowsVerImage.WIN_11.GetWindowsVerPath();
                case $"{WindowsVerImageArg}10":
                    return WindowsVerImage.WIN_10.GetWindowsVerPath();
                case $"{WindowsVerImageArg}8":
                    return WindowsVerImage.WIN_8.GetWindowsVerPath();
                case $"{WindowsVerImageArg}7":
                    return WindowsVerImage.WIN_7.GetWindowsVerPath();
                case $"{WindowsVerImageArg}vista":
                    return WindowsVerImage.WIN_VISTA.GetWindowsVerPath();
                case $"{WindowsVerImageArg}xp":
                    return WindowsVerImage.WIN_XP.GetWindowsVerPath();
                case $"{WindowsVerImageArg}2000":
                    return WindowsVerImage.WIN_2K.GetWindowsVerPath();
                case $"{WindowsVerImageArg}ME":
                    return WindowsVerImage.WIN_ME.GetWindowsVerPath();
                case $"{WindowsVerImageArg}1":
                    return WindowsVerImage.WIN_1.GetWindowsVerPath();
                case $"{WindowsVerImageArg}2":
                    return WindowsVerImage.WIN_2.GetWindowsVerPath();
                case $"{WindowsVerImageArg}3.1":
                    return WindowsVerImage.WIN_3.GetWindowsVerPath();
                case $"{WindowsVerImageArg}3":
                    return WindowsVerImage.WIN_3.GetWindowsVerPath();
                case $"{WindowsVerImageArg}NT":
                    return WindowsVerImage.WIN_NT.GetWindowsVerPath();
                case $"{WindowsVerImageArg}95":
                    return WindowsVerImage.WIN_95.GetWindowsVerPath();
                case $"{WindowsVerImageArg}98":
                    return WindowsVerImage.WIN_98.GetWindowsVerPath();
                case $"{WindowsVerImageArg}Neptune":
                    return WindowsVerImage.WIN_NEPTUNE.GetWindowsVerPath();
                default:
                    Console.WriteLine(NoOsTanFound);
                    return WindowsVerImage.WIN_NT.GetWindowsVerPath();
            }
        } 
    }
}