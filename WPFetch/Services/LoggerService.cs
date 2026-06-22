using System.IO;

using WPFetch.Services;

namespace WPFetch.Backend
{
    /// <summary>
    /// Logger Service for the application, create and control an logger
    /// </summary>
    public class LoggerService
    {
        private readonly string _folderPath;
        private readonly string _filename;

        /// <summary>
        /// LoggerService Constructor : generate an logger and create file with an specific name and an RessourceManagerService
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="ressourcesManagerService"></param>
        public LoggerService(string filename, RessourcesManagerService ressourcesManagerService)
        {
            var ressourcesManager = ressourcesManagerService;
            var appDataPath = ressourcesManager.GetAppDataPath();
            _folderPath = Path.Combine(appDataPath, "logs");
            _filename = filename;
            Log($"Starting Logging {_filename}");
        }

        /// <summary>
        /// Log an message to the log file
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            try
            {
                var path = Path.Combine(_folderPath, $"{_filename}.log");
                if (!Directory.Exists(path)) Directory.CreateDirectory(_folderPath);
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
    }
}
