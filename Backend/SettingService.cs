using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Exceptions;
using WPFetch.Model.Json;
using WPFetch.Model.System;
using WPFetch.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPFetch.Backend
{
    public class SettingService : IService
    {
        private SettingManager? settingManager;

        public SettingService()
        {
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
            RessourcesManager resx = new RessourcesManager();
            MessageBox.Show("This is still a work in progress", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Setting config = new Setting(
                keys["LocaleSelected"] ?? "English",
                keys["DefaultWindowsVersionInputBoxValue"] ?? "Windows NT",
                Convert.ToBoolean(keys["IsFluentUIEnable"]), 
                keys["ThemeSelected"] ?? "System",
                [SystemOptions.OperatingSystem]
            );

            string configJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(resx.GetAppDataFolderPath(), "config.json")))
            {
                streamWriter.WriteLine(configJson);
            }

            MessageBox.Show(configJson);
        }

        public Setting GetSettings()
        {
            try
            {
                var resxTemp = new RessourcesManager();
                var appDataPath = resxTemp.GetAppDataFolderPath();
                var configFilePath = Path.Combine(appDataPath, "config.json");
                var content = File.ReadAllText(configFilePath);
                var setting = JsonConvert.DeserializeObject<Setting>(content);
                MessageBox.Show($"Setting applied : {setting?.ToString()}");
                return setting ?? new DefaultSetting(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while getting setting from storage", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return new DefaultSetting();
        }

        public void ResetSetting()
        {
            try
            {
                var resxTemp = new RessourcesManager();
                var appDataPath = resxTemp.GetAppDataFolderPath();
                var configFilePath = Path.Combine(appDataPath, "config.json");
                File.Delete(configFilePath);
                File.Create(configFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while trying to reset setting", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }
    }
}
