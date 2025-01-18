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

namespace WPFetch.Backend
{
    public class SettingService
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
    }
}
