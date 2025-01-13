using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopWallpaper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Backend;
using WPFetch.Model.System;
using WPFetch.Utils;
using WPFetch.View;

namespace WPFetch.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private static readonly App app = (App)Application.Current;

        private static readonly HardwareInfoService hardwareInfoService = app.HardwareInfoService ?? throw new ApplicationException("HardwareInfoService not found!");

        private static readonly MainImageService mainImageService = app.MainImageService ?? throw new ApplicationException("MainImageService Not Found");

        [ObservableProperty]
        private string? fetchImage = GetOsTan();

        [ObservableProperty]
        private string? windowsVerImage = GetWindowsVerImage();

        [ObservableProperty]
        private string operatingSystemInformationLabel = "Operating System";

        [ObservableProperty]
        private string? operatingSystemInformationValue = hardwareInfoService.RequestOperatingSystem();

        [ObservableProperty]
        private string kernelInformationLabel = "Kernel";

        [ObservableProperty]
        private string? kernelInformationValue = hardwareInfoService.RequestKernel();

        [ObservableProperty]
        private string machineNameInformationLabel = "Machine Name";

        [ObservableProperty]
        private string? machineNameInformationValue = hardwareInfoService.RequestMachineName();

        [ObservableProperty]
        private string is64BitInformationLabel = "Is 64 Bit Operating System";

        [ObservableProperty]
        private string? is64BitInformationValue = hardwareInfoService.RequestIsSystem64Bit();

        [ObservableProperty]
        private string storageInformationLabel = "Storage";

        [ObservableProperty]
        private string? storageInformationValue = hardwareInfoService.RequestStorage();

        [ObservableProperty]
        private string cpuThreadsInformationLabel = "Threads";

        [ObservableProperty]
        private string? cpuThreadsInformationValue = hardwareInfoService.RequestCpuThreads();

        [ObservableProperty]
        private string cpuInformationLabel = "Processor";

        [ObservableProperty]
        private string? cpuInformationValue = hardwareInfoService.RequestCPU();

        [ObservableProperty]
        private ObservableCollection<GpuModel>? gpus = new(hardwareInfoService.RequestGPU());

        [ObservableProperty]
        private string memoryInformationLabel = "Total Memory (RAM)";

        [ObservableProperty]
        private string? memoryInformationValue = hardwareInfoService.RequestRAM();

        [ObservableProperty]
        private string numbersOfTaskRunningLabel = "Numbers of Tasks Running";

        [ObservableProperty]
        private string? numbersOfTaskRunningValue = hardwareInfoService.RequestNumberOfTaskRunning();

        [ObservableProperty]
        private string batteryInformationLabel = "Battery";

        [ObservableProperty]
        private string? batteryInformationValue = hardwareInfoService.RequestBatteryPercentage();

        [ObservableProperty]
        private string? refreshButtonLabel = "🔄️ Refresh";

        [ObservableProperty]
        private string? moreButtonLabel = "➕ More";

        private static string GetOsTan()
        {
            if (app.CmdArgs?.Arguments == null || !app.CmdArgs.Arguments.Any())
            {
                return mainImageService.GetDefaultOSTanPath(); 
            }
            else
            {
                return mainImageService.GetOSTanPathWithCmdArgs();
            }
        }

        private static string GetWindowsVerImage()
        {
            if (app.CmdArgs?.Arguments == null || !app.CmdArgs.Arguments.Any())
            {
                return mainImageService.GetDefaultWindowsVerImage();
            }
            else
            {
                return mainImageService.GetWindowsVerImageWithCmdArgs();
            }
        }

        [RelayCommand]
        private async Task SetRefreshButton()
        {
            await Task.Run(() => { hardwareInfoService.Update(); });
            await Task.Run(() => { UpdateSystemInformationData(); });
        }

        [RelayCommand]
        private void SetAboutButton()
        {
            About about = new();
            about.ShowDialog();
        }

        private void UpdateSystemInformationData()
        {
            var osToCompare = hardwareInfoService.RequestOperatingSystem();
            if (osToCompare != OperatingSystemInformationValue) OperatingSystemInformationValue = osToCompare;

            string kernelToCompare = hardwareInfoService.RequestKernel();
            if (kernelToCompare != KernelInformationValue) KernelInformationValue = kernelToCompare;

            string machineNameToCompare = hardwareInfoService.RequestMachineName();
            if (machineNameToCompare != MachineNameInformationValue) MachineNameInformationValue = machineNameToCompare;

            string newValue = hardwareInfoService.RequestIsSystem64Bit();
            if (newValue != Is64BitInformationValue) Is64BitInformationValue = newValue;

            string storageToCompare = hardwareInfoService.RequestStorage();
            if (storageToCompare != StorageInformationValue) StorageInformationValue = storageToCompare;

            string threadsToCompare = hardwareInfoService.RequestCpuThreads();
            if (threadsToCompare != CpuThreadsInformationValue) CpuThreadsInformationValue = threadsToCompare;

            if (Gpus?.Count == 0 ) Gpus = new ObservableCollection<GpuModel>(hardwareInfoService.RequestGPU());

            string cpuToCompare = hardwareInfoService.RequestCPU();
            if (cpuToCompare != CpuInformationValue) CpuInformationValue = cpuToCompare;

            string memoryToCompare = hardwareInfoService.RequestRAM();
            if (memoryToCompare != MemoryInformationValue) MemoryInformationValue = memoryToCompare;

            string numberOfTaskToCompare = hardwareInfoService.RequestNumberOfTaskRunning();
            if (numberOfTaskToCompare != NumbersOfTaskRunningValue) NumbersOfTaskRunningValue = numberOfTaskToCompare;

            string batteryToCompare = hardwareInfoService.RequestBatteryPercentage();
            if (batteryToCompare != BatteryInformationValue) BatteryInformationValue = batteryToCompare;
        }
      }
    }
