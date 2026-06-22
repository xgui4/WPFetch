using WPFetch.Backend;
using WPFetch.Model.System;

namespace WPFetch.Services;

/// <summary>
/// The system info service : the system info fetcher
/// </summary>
public class SystemInfoService
{
    private const string Unknown = "N/A";

    private readonly LoggerService _logger;

    private readonly SystemInformationModel _system; 
    
    /// <summary>
    /// Initializes a new instance of the SystemInfoService class.
    /// </summary>
    /// <param name="ressourcesManagerService">Service used to manage application resources.</param>
    public SystemInfoService(RessourcesManagerService ressourcesManagerService)
    {
        _system = new SystemInformationModel();
        _logger = new LoggerService("SystemInfoService", ressourcesManagerService);
    }

    /// <summary>
    /// Update the systemInfo data in memory
    /// </summary>
    public void Update()
    {
        _system.FetchAll();
        GenerateLog();
    }

    /// <summary>
    /// Retrieves the name of the operating system.
    /// </summary>
    /// <returns>The name of the operating system, or "Unknown" if not available.</returns>
    public string RequestOperatingSystem()
    {
        return _system.OperatingSystemName ?? Unknown;
    }

    /// <summary>
    /// Retrieves the name of the kernel info.
    /// </summary>
    /// <returns>The name of the  name of the kernel, or "Unknown" if not available.</returns>
    public string RequestKernel()
    {
        return _system.KernelVersion ?? Unknown;
    }

    /// <summary>
    /// Retrieves the name of the machine name.
    /// </summary>
    /// <returns>The name of the machine, or "Unknown" if not available.</returns>
    public string RequestMachineName()
    {
        return _system.MachineName ?? Unknown;
    }

    /// <summary>
    /// Retrieves storage information
    /// </summary>
    /// <returns>the storage in Go, or "Unknown" if not available.</returns>
    public string RequestStorage() 
    {
        return _system.Storage != null ? $"{_system.Storage} Go" : Unknown;
    }

    /// <summary>
    /// Retrieves the CPU thread counts in string
    /// </summary>
    /// <returns>The CPU threads counts in string or "Unknown" if not available.</returns>
    public string RequestCpuThreads()
    {
        return _system.ProcessorCount ?? Unknown;
    }

    /// <summary>
    /// Retrieves the name of the CPU.
    /// </summary>
    /// <returns>The name of the CPU, or "Unknown" if not available.</returns>
    public string RequestCPU()
    {

        return _system.ProcessorName ?? Unknown;
    }

    /// <summary>
    /// Retrieves a collection of GPU models detected on the system.
    /// </summary>
    /// <returns>A list of GpuModel instances representing the available GPUs.</returns>
    public List<GpuModel> RequestGPU()
    {
        List<string> gpusString = _system.Gpus ?? ["No GPU Found !"];
        List<GpuModel> gpuModels = [];
        GpuModel previousGpu = new SentinelGpuModel();
        GpuModel currentGpu; 
        foreach (string gpu in gpusString)
        {
            gpuModels.Add(currentGpu = new GpuModel(previousGpu, gpu));
            previousGpu = currentGpu;
        }
        return gpuModels; 
    }

    /// <summary>
    /// Retrieves the installed RAM in Go in the systems
    /// </summary>
    /// <returns>The installed  of the system in string, or "Unknown" if not available.</returns>
    public string RequestRAM()
    {
        return _system.TotalMemory != null ? $"{_system.TotalMemory} Go" : Unknown;
    }

    /// <summary>
    /// Retrieves the number of task running in string
    /// </summary>
    /// <returns>The number task running in task of the operating system in string, or "Unknown" if not available.</returns>
    public string RequestNumberOfTaskRunning()
    {
        return _system.NumbertOfTaskRunning ?? Unknown;
    }

    /// <summary>
    /// Retrive the battery percentages in string 
    /// </summary>
    /// <returns>the battery percentages in string , or Unknown if not availaible</returns>
    public string RequestBatteryPercentage()
    {
        return _system.Battery != null ? $"{_system.Battery}%" : Unknown;
    }

    /// <summary>
    /// Log information with a message 
    /// </summary>
    /// <param name="message">The nessage to logs</param>
    public void LogInformation(string message)
    {
        _logger.Log(message); 
    }

    /// <summary>
    /// Logs all errors encountered during the fetch process.
    /// </summary>
    public void GenerateLog()
    {
        foreach (var error in _system.ErrorsDuringFetch) { 
            _logger.Log(error); 
        }
    }
}
