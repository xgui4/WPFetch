using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Utils;

namespace WPFetch.Backend
{
    public class LoggerService
    {
        private readonly string FolderPath;
        private readonly string Filename;

        public LoggerService(string filename, RessourcesManagerService ressourcesManagerService)
        {
            var ressourcesManager = ressourcesManagerService;
            var appDataPath = ressourcesManager.GetAppDataPath();
            FolderPath = Path.Combine(appDataPath, "logs");
            Filename = filename;
            Log($"Starting Logging {Filename}");
        }

        public void Log(string message)
        {
            try
            {
                var path = Path.Combine(FolderPath, $"{Filename}.log");
                if (!Directory.Exists(path)) Directory.CreateDirectory(FolderPath);
                using var outputFile = new StreamWriter(path, true);
                outputFile.WriteLine($"{DateTime.Now}: {message}");
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Logging to file failed: {ex.Message}");
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        ~LoggerService()
        {
            Log($"Ending Loggin {Filename}"); 
        }
    }
}
