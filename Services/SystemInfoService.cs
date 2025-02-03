using WPFetch.Model.System;

namespace WPFetch.Backend
{
    public class SystemInfoService
    {
        private const string Unknown = "N/A";

        private readonly LoggerService logger;

        private readonly SystemInformationModel system; 
        
        public SystemInfoService(RessourcesManagerService ressourcesManagerService)
        {
            system = new SystemInformationModel();
            logger = new LoggerService("SystemInfoService", ressourcesManagerService);
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

        public void LogInformation(string message)
        {
            logger.Log(message); 
        }

        public void GenerateLog()
        {
            foreach (var error in system.ErrorsDuringFetch) { 
                logger.Log(error); 
            }
        }
    }
}
