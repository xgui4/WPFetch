using System.Numerics;
using FluentSysInfo.Core.Enums;
using WPFetch.Utils;

namespace WPFetch.Model;

public class SystemInformationModel
{
    public string? OperatingSystemName { get; private set; } = null;
    public string? KernelVersion { get; private set; } = null;
    public string? MachineName { get; private set; } = null;
    public bool? Is64BitOS { get; private set; } = null;
    public string? ProcessorCount { get; private set; } = null;
    public string? ProcessorName { get; private set; } = null;
    public string? TotalMemory { get; private set; } = null;
    public string? Storage { get; private set; } = null;
    public List<string>? Gpus { get; private set; } = [];
    public string? NumbertOfTaskRunning { get; private set; } = null; 
    public string? Battery { get; private set; } = null; 

    public void FetchAll()
    {
        FetchOperatingSystemName();
        FetchKernelVersion();
        FetchMachineName();
        FetchOsIsX64();
        FetchThreads();
        FetchProcessorInfo();
        FetchTotalMemoryInfo();
        FetchStorage();
        FetchNumberOfProcessRunning();
        FetchBatteryInfo();
        FetchGpusInfo();
    }

    public void FetchOperatingSystemName()
    {
        OperatingSystemName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.OperatingSystem, "Caption");
    }

    public void FetchKernelVersion()
    {
        KernelVersion = Environment.OSVersion.ToString();
    }

    public void FetchMachineName()
    {
        MachineName = Environment.MachineName;
    }

    public void FetchOsIsX64()
    {
        Is64BitOS = Environment.Is64BitProcess;
    }

    public void FetchThreads()
    {
        ProcessorCount = Environment.ProcessorCount.ToString();
    }

    public void FetchProcessorInfo()
    {
        ProcessorName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.CPU, "Name");
    }

    public void FetchBatteryInfo()
    {
        Battery = SystemManager.GetHardwareInfo(Cim.BATTERY, "EstimatedChargeRemaining").ToArray()[0];
    }

    public void FetchNumberOfProcessRunning()
    {
        int numberProc = 0;
        foreach (var proc_id in SystemManager.GetHardwareInfo(Cim.PROCESSES, "Name")) { numberProc++; }
        NumbertOfTaskRunning = numberProc.ToString();
    }

    public void FetchStorage()
    {
        Storage = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.Disk, "Size");
        Storage = new BigDataManager().BitStringToGigInt(Storage).ToString();
    }

    public void FetchTotalMemoryInfo()
    {
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
    }

    public void FetchGpusInfo()
    {
        var gpus = SystemManager.GetHardwareInfo(Cim.GPU, "Name");

        foreach (string gpu in gpus)
        {
            Gpus?.Add(gpu);
        }
    }
}