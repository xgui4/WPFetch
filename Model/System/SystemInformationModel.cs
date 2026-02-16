using System.Numerics;
using FluentSysInfo.Core.Enums;
using WPFetch.Model.Enums;
using WPFetch.Utils;

namespace WPFetch.Model.System;

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

    public void FetchKernelVersion()
    {
        KernelVersion = Environment.OSVersion.ToString();
    }

    public void FetchMachineName()
    {
        MachineName = Environment.MachineName;
    }

    public void FetchThreads()
    {
        ProcessorCount = Environment.ProcessorCount.ToString();
    }

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

    public void FetchStorage()
    {
        try
        {
            Storage = FluentSystemManager.GetHardwareInfo(FluentSysInfoTypes.Disk, "Size");
            Storage = new BigDataManager().BitStringToGigInt(Storage).ToString();
        }
        catch (Exception ex)
        {
            ErrorsDuringFetch.Add(ex.Message);
            Storage = "N/A"; 
        }
    }

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