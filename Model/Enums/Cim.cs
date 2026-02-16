namespace WPFetch.Model.Enums
{
    public enum Cim
    {
        OS,
        CPU,
        GPU,
        RAM,
        PACKAGES,
        PROCESSES,
        STORAGE,
        BATTERY,
    }

    public static class CimExtension
    {
        private const string Select = "SELECT * FROM";

        public static string GetWmiQuery(this Cim cim)
        {
            return cim switch
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
}

