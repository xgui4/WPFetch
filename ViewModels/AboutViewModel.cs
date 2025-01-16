using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFetch.Model.Enums;
using WPFetch.Model.Json;
using WPFetch.Model.System;
using WPFetch.Utils;

namespace WPFetch.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? fullTitleValue = "WPFetch Version 0.0.0.1 Developer Preview 2";

        [ObservableProperty]
        private string? descriptionValue = "A utility to fetch you system info with a OS-tan";

        [ObservableProperty]
        private string? appIconPath = "../Ressources/Images/appicon.ico";

        [ObservableProperty]
        private string? authorsLabel = "🧑‍💻 Developer : Xgui4 Studio";

        [ObservableProperty]
        private string? licenseLabel = "📜 License : MIT License"; 

        [ObservableProperty]
        private string? checkUpdateButtonLabel = "Check Update";

        [ObservableProperty]
        private string? confirmChangesButtonLabel = "Confirm Changes";

        [ObservableProperty]
        private bool isFluentUIEnable = true;

        [ObservableProperty]
        private string? defaultWindowsVersionInputBoxValue;

        [ObservableProperty]
        private ObservableCollection<string> localesAvailable = langs; 

        [ObservableProperty]
        private string? localeSelected;

        [ObservableProperty]
        private ObservableCollection<string?> themesAvailable = [ "System", "Dark", "Light" ];

        [ObservableProperty]
        private string? themeSelected;

        /// <summary>
        /// This is temporaly until i add the language service later
        /// </summary>
        private static ObservableCollection<string> langs = [Locales.FR.GetString(), Locales.EN.GetString()];

        [RelayCommand] 
        private void ConfirmChangesButton() 
        {
            RessourcesManager resx = new RessourcesManager(); 
            MessageBox.Show("This is still a work in progress", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
            Setting config = new Setting(
                LocaleSelected ?? "English", 
                DefaultWindowsVersionInputBoxValue ?? "Windows NT", 
                IsFluentUIEnable, ThemeSelected ?? "System", 
                new[] { SystemOptions.OperatingSystem }
            ); 

            string configJson = JsonConvert.SerializeObject(config, Formatting.Indented); 
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(resx.GetAppDataFolderPath(), "config.json")))
            {
                streamWriter.WriteLine(configJson); 
            }

            MessageBox.Show(configJson); 
        }

        [RelayCommand]
        private async Task SetCheckUpdateButton()
        {
            try
            {
                await Task.Run(() => { Process.Start("explorer", "https://github.com/xgui4/WPFetch/releases"); });
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Unexcepted Error");
            }
        }
    }
}
