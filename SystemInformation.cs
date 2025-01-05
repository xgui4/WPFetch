using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentSysInfo.Core;
using FluentSysInfo.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DesktopWallpaper;

public class SystemInformation
{
    public string OperatingSystemName { get; private set; }
    public string KernelVersion { get; private set; }
    public string MachineName { get; private set; }
    public bool Is64BitOS { get; private set; }
    public string ProcessorCount { get; private set; }
    public string ProcessorName { get; private set; }
    public string TotalMemory { get; private set; }
    public string Storage { get; private set; }
    public List <string> Gpus { get; private set; } = new List<string>();
    public string MemoryUsed { get; private set; }
    public string CpuUsed { get; private set; }
    public string NumbertOfTaskRunning { get; private set; }
    public string Theme { get; private set; }
    public string SystemFont { get; private set; }

    public SystemInformation()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_VideoController");

        OperatingSystemName = new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.OperatingSystem);
        KernelVersion = Environment.OSVersion.ToString();
        MachineName = Environment.MachineName;
        Is64BitOS = Environment.Is64BitProcess;
        ProcessorCount = Environment.ProcessorCount.ToString();
        ProcessorName = new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.CPU);
        TotalMemory = new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.PhysicalMemory);
        Storage = new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.Disk);
        MemoryUsed = "Not supported yet!";
        CpuUsed = Environment.CpuUsage.TotalTime.ToString() ?? "Unknown Processor";
        NumbertOfTaskRunning = new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.RunningProcesses);
        Theme = "Not suppported yet!";
        SystemFont = "Not supported yet!";

        OperatingSystemName = FilterJson(OperatingSystemName.Normalize(), "Caption", "Unkown Operating System");
        Storage = FilterJson(Storage.Normalize(), "Size", "Unknown Storage Device");
        ProcessorName = FilterJson(ProcessorName.Normalize(), "Name", "Unknown CPU");
        TotalMemory = FilterJson(TotalMemory.Normalize(), "Size", "N/A");
        NumbertOfTaskRunning = "Not supported Yet !"; 

        foreach (ManagementObject gpu in searcher.Get().Cast<ManagementObject>())
        {
            Gpus.Add((gpu["Name"]).ToString() ?? "Unknown Graphic Card");
        }
    }
    private string FilterJson(string jsonString, string property, string defaultOutput)
    { 
        try {
            var tempStr = jsonString.Replace(@"\\", @"\").Replace(@"//", @"/");
            jsonString = tempStr.Replace(@"\", @"\\").Replace(@"/", @"//");
            JObject jsonObj = JObject.Parse(jsonString); 
            return jsonObj[property]?.ToString() ?? defaultOutput;
        }
        catch (JsonReaderException e) {
            Console.WriteLine(jsonString); 
            Console.WriteLine($"JSON Parsing Error: {e.Message}"); 
            return "Error while fetching"; 
        } 
    }
}