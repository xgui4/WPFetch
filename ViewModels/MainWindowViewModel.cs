using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Model;

namespace WPFetch.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public string? fetchImage = GetDefaultOsTan();

        private static string GetDefaultOsTan()
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
    }
    }
