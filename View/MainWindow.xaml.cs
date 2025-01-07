using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using WPFetch.Model;

namespace DesktopWallpaper;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SystemInformation systemInformation = new SystemInformation();
        DisplaySystemInfo(systemInformation);
    }

    private void DisplaySystemInfo(SystemInformation system)
    {
        string gpusString = GenerateGPUsString(system);

        Information.Content =
            $"""
            Operating System : {system.OperatingSystemName}
            Kernel Version : {system.KernelVersion}
            Machine Name : {system.MachineName}
            Is 64 Bit : {system.Is64BitOS}
            Storage : {system.Storage} Go
            CPU Threads Counts : {system.ProcessorCount}
            Processor : {system.ProcessorName}
            {gpusString}
            Total Memory (RAM) : {system.TotalMemory} Go
            Number of Task Running : {system.NumbertOfTaskRunning}
            Battery : {system.Battery}
            """;
    }
    private static string GenerateGPUsString(SystemInformation system)
    {
        string gpusString = ""; 
        int index = 0;
        foreach (string gpu in system.Gpus)
        {
            gpusString += $"GPU {index++} : {gpu}";
            if (index != system.Gpus.Count) gpusString += "\n";
        }
        return gpusString;
    }
}
