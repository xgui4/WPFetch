using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopWallpaper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Backend;
using WPFetch.Model;
using WPFetch.Utils;
using WPFetch.View;

namespace WPFetch.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {

        private static App app = (App)Application.Current;

        private static HardwareInfoService hardwareInfoService = new HardwareInfoService();

        [ObservableProperty]
        private string? fetchImage = GetOsTan();

        [ObservableProperty]
        private string? operatingSystemInformationLabel = "Operating System";

        [ObservableProperty]
        private string? operatingSystemInformationValue = hardwareInfoService.RequestOperatingSystem();

        [ObservableProperty]
        private string? kernelInformationLabel = "Kernel";

        [ObservableProperty]
        private string? kernelInformationValue = hardwareInfoService.RequestKernel();

        [ObservableProperty]
        private string? machineNameInformationLabel = "Machine Name";

        [ObservableProperty]
        private string? machineNameInformationValue = hardwareInfoService.RequestMachineName();

        [ObservableProperty]
        private string? is64BitInformationLabel = "64 Bit Operating System";

        [ObservableProperty]
        private string? is64BitInformationValue = hardwareInfoService.RequestIsSystem64Bit();

        [ObservableProperty]
        private string? storageInformationLabel = "Storage";

        [ObservableProperty]
        private string? storageInformationValue = hardwareInfoService.RequestStorage();

        [ObservableProperty]
        private string? cpuThreadsInformationLabel = "Threads";

        [ObservableProperty]
        private string? cpuThreadsInformationValue = hardwareInfoService.RequestCpuThreads();

        [ObservableProperty]
        private string? cpuInformationLabel = "Processor";

        [ObservableProperty]
        private string? cpuInformationValue = hardwareInfoService.RequestCPU();

        [ObservableProperty]
        private ObservableCollection<GpuModel>? gpus = new ObservableCollection<GpuModel>(hardwareInfoService.RequestGPU()); 

        [ObservableProperty]
        private string? memoryInformationLabel = "Total Memory (RAM)";

        [ObservableProperty]
        private string? memoryInformationValue = hardwareInfoService.RequestRAM();

        [ObservableProperty]
        private string? numbersOfTaskRunningLabel = "Numbers of Tasks Running"; 

        [ObservableProperty]
        private string? numbersOfTaskRunningValue = hardwareInfoService.RequestNumberOfTaskRunning();

        [ObservableProperty]
        private string? batteryInformationLabel = "Battery";

        [ObservableProperty]
        private string? batteryInformationValue = hardwareInfoService.RequestBatteryPercentage(); 

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

        [RelayCommand]
        private void SetRefreshButton()
        {
            hardwareInfoService.Update();
            UpdateModel();
        }

        [RelayCommand]
        private void SetAboutButton()
        {
            About about = new About();
            about.Show();
        }

        private void UpdateModel()
        {
            OperatingSystemInformationValue = hardwareInfoService.RequestOperatingSystem(); 
            KernelInformationValue = hardwareInfoService.RequestKernel();
            MachineNameInformationValue = hardwareInfoService.RequestMachineName(); 
            Is64BitInformationValue = hardwareInfoService.RequestIsSystem64Bit();
            StorageInformationValue = hardwareInfoService.RequestStorage(); 
            CpuThreadsInformationValue = hardwareInfoService.RequestCpuThreads();
            Gpus = new ObservableCollection<GpuModel>(hardwareInfoService.RequestGPU());
            CpuInformationValue = hardwareInfoService.RequestCPU(); 
            MemoryInformationValue = hardwareInfoService.RequestRAM();
            NumbersOfTaskRunningValue = hardwareInfoService.RequestNumberOfTaskRunning(); 
            BatteryInformationValue = hardwareInfoService.RequestBatteryPercentage(); 
        }
      }
    }
