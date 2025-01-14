using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Model.Enums;
using WPFetch.Model.Json;
using WPFetch.Model.System;

namespace WPFetch.Utils
{
    public class SettingManager
    {
        private readonly Setting setting; 

        public SettingManager(Setting setting)
        {
            this.setting = setting;
        }

        public Locales GetLocale() { return setting.LocaleSelected; }

        public void UpdateLocale(Locales locale)
        {
            if (setting.LocaleSelected != locale) 
                setting.LocaleSelected = locale; 
        }

        public string GetDefaultWindowsVersion()
        {
            return setting.DefaultWindowsVersions; 
        }

        public void UpdateDefaultWindowsVersions(string windowsVersion)
        {
            if (setting.DefaultWindowsVersions != windowsVersion) 
                setting.DefaultWindowsVersions = windowsVersion; 
        }

        public bool IsFluentUIEnabled()  
        { 
            return setting.IsFluentUIEnabled; 
        }

        public void ToggleFluentUI() 
        { 
            if (IsFluentUIEnabled()) setting.IsFluentUIEnabled = false;
            else setting.IsFluentUIEnabled = true;
        }

        public string GetTheme()
        {
            return setting.Theme;
        }

        public void UpdateTheme(string theme)
        {
            if (setting.Theme != theme) 
                setting.Theme = theme; 
        }

        public List<SystemOptions> GetHardwaresToFetch()
        {
            return setting.HardwaresToFetch.ToList(); 
        }

        public void UpdateHardwaresToFetch(List<SystemOptions> hardwaresToFetch)
        {
            setting.HardwaresToFetch = hardwaresToFetch.ToArray(); 
        }
    }
}
