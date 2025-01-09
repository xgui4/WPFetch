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

        public string RequestOperatingSystem()
        {
            return system.OperatingSystemName ?? "Not Fetched yet!";
        }

        public string RequestKernel()
        {
            return system.KernelVersion ?? "Not Fetched yet!";
        }

        public string RequestMachineName()
        {
            return system.MachineName ?? "Not Fetched yet!";
        }

        public string RequestIsSystem64Bit()
        {
           try
           {
                int boolean = Convert.ToInt32(Is64BitOS()); 
                
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

        private bool Is64BitOS()
        {
            return system.Is64BitOS ?? throw new Exception("Not Fetched yet!"); 
        }

        public string RequestStorage() 
        {
            if (system.Storage != null)
                return $"{system.Storage} Go";
            else
                return "Not fetched yet !";
        }

        public string RequestCpuThreads()
        {
            return system.ProcessorCount ?? "Not fetched yet !";
        }

        public string RequestCPU()
        {

            return system.ProcessorName ?? "Not fetched yet !";
        }

        public List<GpuModel> RequestGPU()
        {
            List<string> gpusString = system.Gpus ?? new List<string>() { "No GPU Found !" };
            List<GpuModel> gpuModels = new List<GpuModel>();
            GpuModel previousGpu = new SentinelGpuModel();
            GpuModel currentGpu; 
            foreach (string gpu in gpusString)
            {
                gpuModels.Add(currentGpu = new GpuModel(previousGpu, gpu));
                previousGpu = currentGpu;
            }
            return gpuModels; 
        }

        public string RequestRAM()
        {
            if (system.TotalMemory != null)
                return $"{system.TotalMemory} Go"; 
            else
                return "Not fetched yet!"; 
        }

        public string RequestNumberOfTaskRunning()
        {
            return system.NumbertOfTaskRunning ?? "Not fetched yet!";
        }
        public string RequestBatteryPercentage()
        {
            if (system.Battery != null)
                return $"{system.Battery}%";
            else
                return "Not fetched yet!"; 
        }
    }
}
