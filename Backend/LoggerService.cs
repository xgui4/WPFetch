using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Utils;

namespace WPFetch.Backend
{
    public class LoggerService : IService
    {
        private readonly string LogsFolderPath;
        private readonly string LogFile; 

        public LoggerService(string logFile)
        { 
            RessourcesManager ressourcesManager = new RessourcesManager();
            string appDataPath = ressourcesManager.GetAppDataFolderPath();
            LogsFolderPath = Path.Combine(appDataPath, "logs");

            if (!Directory.Exists(LogsFolderPath))
            {
                Directory.CreateDirectory(LogsFolderPath);
            }
            LogFile = logFile; 
        }

        public void Log(string message) 
        {
            try
            {
                string path = Path.Combine(LogsFolderPath, $"{LogFile}.log");
                Debug.WriteLine(path);
                using StreamWriter file = new(path, true);
                file.WriteLine($"{DateTime.Now}. message");
            }
            catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(message);
            }
        }
    }
}
