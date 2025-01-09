using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Model;

namespace WPFetch.Backend
{
    public class HardwareInfoService
    {
        private SystemInformation system; 
        
        public HardwareInfoService()
        {
            system = new SystemInformation();
        }

        public void Update()
        {
            system.Fetch(); 
        }

        public string getOS()
        {
            return system.OperatingSystemName ?? "Not Fetched yet!";
        }

        public string getKernel()
        {
            return system.KernelVersion ?? "Not Fetched yet!";
        }

        public string getMachineName()
        {
            return system.MachineName ?? "Not Fetched yet!";
        }

        public string is64BitOsString()
        {
           try
           {
                int boolean = Convert.ToInt32(is64BitOS()); 
                
                if (boolean == 1)
                {
                    return "true"; 
                }

                return "false";
           } 
           catch (Exception ex) 
           {
                return ex.Message;
           }
        } 

        private bool is64BitOS()
        {
            return system.Is64BitOS ?? throw new Exception("Not Fetched yet!"); 
        }

        public string getStorage() 
        { 
            return system.Storage ?? "Not fetched yet !";
        }

        public string getCpusThreads()
        {
            return system.ProcessorCount ?? "Not fetched yet !";
        }

        public string getCpuInfo()
        {

            return system.ProcessorName ?? "Not fetched yet!";
        }

        public List<string> getGpusInfo()
        {
            return system.Gpus ?? new List<string>(); 
        }

        public string getMemoryInfo()
        {
            return system.TotalMemory ?? "Not fetched yet!";
        }

        public string getNumberOfProcess()
        {
            return system.NumbertOfTaskRunning ?? "Not fetched yet!";
        }
        public string getBatteryPercentage()
        {
            return system.Battery ?? "Not fetched yet!";   
        }
    }
}
