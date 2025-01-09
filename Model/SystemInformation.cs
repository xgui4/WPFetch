using System.Numerics;
using FluentSysInfo.Core.Enums;
using WPFetch.Utils;
namespace WPFetch.Model;

public class SystemInformation
{
    public string? OperatingSystemName { get; private set; } = null;
    public string? KernelVersion { get; private set; } = null;
    public string? MachineName { get; private set; } = null;
    public bool? Is64BitOS { get; private set; } = null;
    public string? ProcessorCount { get; private set; } = null;
    public string? ProcessorName { get; private set; } = null;
    public string? TotalMemory { get; private set; } = null;
    public string? Storage { get; private set; } = null;
    public List<string>? Gpus { get; private set; } = new List<string>();
    public string? NumbertOfTaskRunning { get; private set; } = null; 
    public string? Battery { get; private set; } = null; 

    public void Fetch()
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
            Gpus?.Add(gpu);
        }
    }
}