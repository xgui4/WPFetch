using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;

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
        Information.Content =
            $"""
                Operating System : {system.OperatingSystemName}
                Kernel Version : {system.KernelVersion}
                Machine Name : {system.MachineName}
                Is 64 Bit : {system.Is64BitOS}
                Storage : {system.Storage}
                Processor Count : {system.ProcessorCount}
                Processor Name : {system.ProcessorName}
                GPU : {system.Gpus[0]}
                Total Memory (RAM) : {system.TotalMemory}
                Memory Used (RAM): {system.MemoryUsed}
                CPU Usage : {system.CpuUsed}
                Number of Task Running : {system.NumbertOfTaskRunning}
                Theme : {system.Theme}
                System Font : {system.SystemFont}
            """;
    }
}
