using System.Numerics;
using FluentSysInfo.Core.Enums;
using WPFetch.Model.Enums;
using WPFetch.Utils;

namespace WPFetch.Model.System;

/// <summary>
/// Thr systemInforation in memory database
/// </summary>
public class SystemInformationModel
{
    public string? OperatingSystemName { get; private set; } = null;
    public string? KernelVersion { get; private set; } = null;
    public string? MachineName { get; private set; } = null;
    public string? ProcessorCount { get; private set; } = null;
    public string? ProcessorName { get; private set; } = null;
    public string? TotalMemory { get; private set; } = null;
    public string? Storage { get; private set; } = null;
    public List<string>? Gpus { get; private set; } = [];
    public string? NumbertOfTaskRunning { get; private set; } = null;
    public string? Battery { get; private set; } = null;
    public List<string> ErrorsDuringFetch { get; private set; } = [];

    /// <summary>
    /// Fetch All the system informations
    /// </summary>
    public void FetchAll()
    {
        FetchOperatingSystemName();
        FetchKernelVersion();
        FetchMachineName();
        FetchThreads();
        FetchProcessorInfo();
        FetchTotalMemoryInfo();
        FetchStorage();
        FetchNumberOfProcessRunning();
        FetchBatteryInfo();
        FetchGpusInfo();
    }

    /// <summary>
    /// Fetch the operating system name
    /// </summary>
    public void FetchOperatingSystemName()
    {
        try
        {
            OperatingSystemName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.OperatingSystem, "Caption");
        }
        catch (Exception ex) {
            ErrorsDuringFetch.Add(ex.Message);
            OperatingSystemName = "N/A";
        }
    }

    /// <summary>
    /// Fetch the kernel information
    /// </summary>
    public void FetchKernelVersion()
    {
        KernelVersion = Environment.OSVersion.ToString();
    }

    /// <summary>
    /// Fetch the machine name
    /// </summary>
    public void FetchMachineName()
    {
        MachineName = Environment.MachineName;
    }

    /// <summary>
    /// Fetch the threds informations
    /// </summary>
    public void FetchThreads()
    {
        ProcessorCount = Environment.ProcessorCount.ToString();
    }

    /// <summary>
    /// Fetch the processors info
    /// </summary>
    public void FetchProcessorInfo()
    {
        try
        {
            ProcessorName = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.CPU, "Name");
        }
        catch (Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            ProcessorName = "N/A";
        }
    }

    /// <summary>
    /// Fetch the battery info
    /// </summary>
    public void FetchBatteryInfo()
    {
        try
        {
            Battery = SystemManager.GetHardwareInfo(Cim.BATTERY, "EstimatedChargeRemaining").ToArray()[0];
        }
        catch(Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            Battery = "N/A"; 
        }
    }

    /// <summary>
    /// Fetch the processors counts
    /// </summary>
    public void FetchNumberOfProcessRunning()
    {
        try
        {
            var numberProc = 0;
            foreach (var proc_id in SystemManager.GetHardwareInfo(Cim.PROCESSES, "Name")) { numberProc++; }
            NumbertOfTaskRunning = numberProc.ToString();
        }
        catch (Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            NumbertOfTaskRunning = "N/A";
        }
    }

    /// <summary>
    /// Fetch the storage informations
    /// </summary>
    public void FetchStorage()
    {
        try
        {
            Storage = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.Disk, "Size");
            Storage = new BigDataManager().BitStringToGoInt(Storage).ToString();
        }
        catch (Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            Storage = "N/A"; 
        }
    }

    /// <summary>
    /// Fetch the total memory info (installed RAM)
    /// </summary>
    public void FetchTotalMemoryInfo()
    {
        try
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
        catch (Exception e)
        {
            ErrorsDuringFetch.Add(e.Message);
            TotalMemory = "N/A"; 
        }
    }

    /// <summary>
    /// Fetch the GPUS infos
    /// </summary>
    public void FetchGpusInfo()
    {
        try
        {
            var gpus = SystemManager.GetHardwareInfo(Cim.GPU, "Name");

            foreach (string gpu in gpus)
            {
                Gpus?.Add(gpu);
            }
        }

        catch (Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            Gpus?.Add("Error while find GPU Info");
        }
    }
}