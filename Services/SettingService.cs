using Newtonsoft.Json;
using System.IO;
using WPFetch.Exceptions;
using WPFetch.Model.Json;
using WPFetch.Model.System;
using WPFetch.Utils;

namespace WPFetch.Backend
{
    public class SettingService
    {
        private readonly LoggerService logger;
        private Setting? setting;
        private SettingManager? settingManager;

        public SettingService(RessourcesManagerService ressourcesManagerService)
        {
            logger = new LoggerService("SettingService", ressourcesManagerService);
            setting = null; 
        }

        public void AddAppliedSettings(Setting appliedSetting)
        {
            settingManager = new SettingManager(appliedSetting); 
        }

        public List<string> GetThemesList()
        {
            if (settingManager == null) throw new ServiceException("Service not initilised yet!");
            return settingManager.Themes.ToList();
        }

        public void SaveConfig(Dictionary<string, string> keys)
        {
            var resx = new RessourcesManager();
            var config = new Setting(
                keys["LocaleSelected"] ?? "English",
                keys["DefaultWindowsVersionInputBoxValue"] ?? "Windows NT",
                Convert.ToBoolean(keys["IsFluentUIEnable"]), 
                keys["ThemeSelected"] ?? "System",
                [SystemOptions.OperatingSystem]
            );

            var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            using var streamWriter = new StreamWriter(Path.Combine(resx.GetAppDataFolderPath(), "config.json"));
            streamWriter.WriteLine(configJson);
        }

        public void ObtainPreferencesFromDisk() 
        {
            var resxTemp = new RessourcesManager();
            var appDataPath = resxTemp.GetAppDataFolderPath();
            var configFilePath = Path.Combine(appDataPath, "config.json");
            Setting settingTemp = new DefaultSetting();

            try
            { 
                if (File.Exists(configFilePath)) 
                { 
                    var content = File.ReadAllText(configFilePath); 
                    settingTemp = JsonConvert.DeserializeObject<Setting>(content) ?? new DefaultSetting();
                } 
                setting = settingTemp ?? new DefaultSetting(); 
            } 
            catch (Exception ex) 
            { 
                logger.Log($"Error in ObtainPreferencesFromDisk: {ex.Message}. StackTrace: {ex.StackTrace}"); 
                logger.Log($"Failed to load config file at '{configFilePath}'"); 
                setting = new DefaultSetting();
            } 
        }
        public Setting GetSetting() { if (setting == null) throw new InvalidOperationException("Setting wasn't set yet"); return setting; }

        public void ResetSetting()
        {
            try
            {
                var resxTemp = new RessourcesManager();
                var appDataPath = resxTemp.GetAppDataFolderPath();
                var configFilePath = Path.Combine(appDataPath, "config.json");
                File.WriteAllText(configFilePath, string.Empty);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message); 
            }
        }
    }
}
