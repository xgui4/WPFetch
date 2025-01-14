using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Model.System;

namespace WPFetch.Backend
{
    public class HardwareInfoService
    {
        private const string Unknown = "N/A";

        private readonly SystemInformationModel system; 
        
        public HardwareInfoService()
        {
            system = new SystemInformationModel();
        }

        public void Update()
        {
            system.FetchAll();
            GenerateLog();
        }

        public string RequestOperatingSystem()
        {
            return system.OperatingSystemName ?? Unknown;
        }

        public string RequestKernel()
        {
            return system.KernelVersion ?? Unknown;
        }

        public string RequestMachineName()
        {
            return system.MachineName ?? Unknown;
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
            return system.Is64BitOS ?? throw new Exception(Unknown); 
        }

        public string RequestStorage() 
        {
            if (system.Storage != null)
                return $"{system.Storage} Go";
            else
                return Unknown;
        }

        public string RequestCpuThreads()
        {
            return system.ProcessorCount ?? Unknown;
        }

        public string RequestCPU()
        {

            return system.ProcessorName ?? Unknown;
        }

        public List<GpuModel> RequestGPU()
        {
            List<string> gpusString = system.Gpus ?? ["No GPU Found !"];
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

        public string RequestRAM()
        {
            if (system.TotalMemory != null)
                return $"{system.TotalMemory} Go"; 
            else
                return Unknown; 
        }

        public string RequestNumberOfTaskRunning()
        {
            return system.NumbertOfTaskRunning ?? Unknown;
        }
        public string RequestBatteryPercentage()
        {
            if (system.Battery != null)
                return $"{system.Battery}%";
            else
                return Unknown; 
        }

        public void GenerateLog()
        {
            string logsFolderPath = Environment.CurrentDirectory + "\\logs\\";

            if (!Directory.Exists(logsFolderPath))
            {
                Directory.CreateDirectory(logsFolderPath);
                MessageBox.Show(logsFolderPath + " Created!");
            }

            using (StreamWriter file = new StreamWriter(logsFolderPath + "HardwareInfoService.log"))
            {
                system.ErrorsDuringFetch.ForEach((error) => file.WriteLine(error));
            }
        }
    }
}
