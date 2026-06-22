namespace WPFetch.Model.Enums;

/// <summary>
/// Represent an System Informations of WMI query
/// </summary>
public enum Cim
{
#pragma warning disable CS1591
    OS,
    CPU,
    GPU,
    RAM,
    PACKAGES,
    PROCESSES,
    STORAGE,
    BATTERY,
#pragma warning restore CS1591
}

/// <summary>
/// An method extension to get system informations with QMI Query
/// </summary>
public static class CimExtension
{
    private const string Select = "SELECT * FROM";

    /// <summary>
    /// Request an system information with a Wmi query
    /// </summary>
    /// <param name="systemInfo">The System info itself</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string GetWmiQuery(this Cim systemInfo)
    {
        return systemInfo switch
        {
            Cim.OS => $"{Select} Win32_OperatingSystem",
            Cim.CPU => $"{Select} Win32_Processor",
            Cim.GPU => $"{Select} Win32_VideoController",
            Cim.RAM => $"{Select} Win32_PhysicalMemory",
            Cim.PACKAGES => $"{Select} Win32_Product",
            Cim.PROCESSES => $"{Select} Win32_Process",
            Cim.STORAGE => $"{Select} Win32_DiskDrive",
            Cim.BATTERY => $"{Select} Win32_Battery",
            _ => throw new ArgumentException("This is not a valid CIM path, pls try again.")
        };
    }

}

