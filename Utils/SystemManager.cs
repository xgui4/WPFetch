using System.Management;
using WPFetch.Model.Enums;

namespace WPFetch.Utils
{
    public static class SystemManager
    {
        public static List<string> GetHardwareInfo(Cim cim, string outputType)
        {
            List<string> output = []; 
            string query = cim.GetWmiQuery(); 
            using (ManagementObjectSearcher searcher = new(query))
            {
                try
                {
                    foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
                    {
                        output.Add(managementObject[outputType]?.ToString() ?? "N/A");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    output.Add("N/A");
                }
            }
            return output;
        }
    }
}
