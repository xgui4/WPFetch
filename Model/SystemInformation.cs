using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Management;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentSysInfo.Core;
using FluentSysInfo.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WPFetch.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace WPFetch.Model;

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
    public List<string> Gpus { get; private set; } = new List<string>();
    public string NumbertOfTaskRunning { get; private set; }
    public string Battery { get; private set; }

    public SystemInformation()
    {
        OperatingSystemName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.OperatingSystem, "Caption");
        KernelVersion = Environment.OSVersion.ToString();
        MachineName = Environment.MachineName;
        Is64BitOS = Environment.Is64BitProcess;
        ProcessorCount = Environment.ProcessorCount.ToString();
        ProcessorName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.CPU, "Name");
        TotalMemory = "0";
        List<string> mems = SystemManager.GetHardwareInfo(Cim.RAM, "Capacity"); 
        BigInteger now = 0;
        BigInteger temp = 0; 
        foreach (string capacity in mems)
        {
            temp = now + BigInteger.Parse(capacity);
            now = temp;
        }
        TotalMemory = $"{temp / new BigDataManager().Gigaoctect}";
        Storage = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.Disk, "Size");
        Storage = new BigDataManager().BitStringToGigInt(Storage).ToString();
        int numberProc = 0;  
        foreach (var proc_id in SystemManager.GetHardwareInfo(Cim.PROCESSES, "Name")) { numberProc++; }
        NumbertOfTaskRunning = numberProc.ToString(); 
        Battery = SystemManager.GetHardwareInfo(Cim.BATTERY, "EstimatedChargeRemaining").ToArray()[0];

        var gpus = SystemManager.GetHardwareInfo(Cim.GPU, "Name"); 

        foreach (string gpu in gpus)
        {
            Gpus.Add(gpu);
        }
    }
}