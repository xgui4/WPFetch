using CommunityToolkit.Mvvm.ComponentModel;
using DesktopWallpaper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Model;

namespace WPFetch.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public string? fetchImage = GetOsTan();
        
        private static App app = (App)Application.Current;

        private static string GetOsTan()
        {
            if (app.CmdArgs?.Arguments.Count == 0)
            {
                return GetDefaultOSTanPath(); 
            }
            else
            {
                return GetOSTanPathWithCmdArgs();
            }
        }

        private static string GetDefaultOSTanPath()
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

        private static string GetOSTanPathWithCmdArgs()
        {
            Console.WriteLine(app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith("windowsver=")));
            switch (app.CmdArgs?.Arguments.FirstOrDefault(arg => arg.StartsWith("windowsver=")))
            {
                case "windowsver=11":
                    return Os_Tan.WINDOWS_11.GetOsTanPathImgPath();
                case "windowsver=10":
                    return Os_Tan.WINDOWS_10.GetOsTanPathImgPath();
                case "windowsver=8":
                    return Os_Tan.WINDOWS_8.GetOsTanPathImgPath();
                case "windowsver=7":
                    return Os_Tan.WINDOWS_7.GetOsTanPathImgPath();
                case "windowsver=vista":
                    return Os_Tan.WINDOWS_VISTA.GetOsTanPathImgPath();
                case "windowsver=xp":
                    return Os_Tan.WINDOWS_XP.GetOsTanPathImgPath();
                case "windowsver=2000":
                    return Os_Tan.WINDOWS_2000.GetOsTanPathImgPath();
                default:
                    Console.WriteLine("This Windows Version doesn't have a OS-Tan Yet or doesn't exist");
                    return Os_Tan.NT.GetOsTanPathImgPath();
            }
        }
    }
    }
