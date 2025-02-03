using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopWallpaper;
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
using WPFetch.Backend;
using WPFetch.Model.Enums;
using WPFetch.Model.Json;
using WPFetch.Model.System;
using WPFetch.Utils;

namespace WPFetch.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        private static readonly App app = (App)Application.Current;

        private static SettingService? settings;

        private static RessourcesManagerService ressourcesManagerService; 

        public AboutViewModel()
        {
            try
            {
                settings = app.SettingService ?? throw new Exception("Setting Service Not Found !");
                ressourcesManagerService = app.RessourcesManagerService ?? throw new Exception("Ressources Managers Service Not Found !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Critical Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        [ObservableProperty]
        private string? fullTitleValue = "WPFetch Version 0.0.0.1 Developer Preview 3";

        [ObservableProperty]
        private string? descriptionValue = "A utility to fetch you system info with a OS-tan";

        [ObservableProperty]
        private string? featuresLabelValue =
            """
            ## Features
            - Fetch you hardware like noefetch does but with a GUI and with customisable main image 
            - Show OS-Tan as main images and windows logo on top on of the setup info
            - Command line argurment
            - Configuration via GUI (comming soon)
            - Link for a the github release page in the check update button (might do more in the future)
            """;

        [ObservableProperty]
        private string? techUsedLabelValue =
            """
            ## Nuget Packages && Framework used :
            - Community Toolkit  Version 8.4.0
            - FluentSysInfo.Core" Version 1.0.8860
            - Newtonsoft.Json" Version 13.0.3
            - System.Drawing.Common Version 9.0.0
            - System.Management" Version= 9.0.0"
            - Windows Presentation Foundation
            - Inno Setup for the installer 
            """;

        [ObservableProperty]
        private string? appIconPath = ressourcesManagerService.GetImagesPath("appicon.ico");

        [ObservableProperty]
        private string? authorsLabel = "🧑‍💻 Developer : Xgui4 Studio";

        [ObservableProperty]
        private string? licenseLabel = "📜 License : MIT License";

        [ObservableProperty]
        private string? checkUpdateButtonLabel = "Check Update";

        [ObservableProperty]
        private string? confirmChangesButtonLabel = "Confirm Changes";

        [ObservableProperty]
        private string? configSectionLabelContent = "Config (Work in progress)"; 

        [ObservableProperty]
        private string? isFluentUIEnableLabelContent = "Activate Fluent UI";

        [ObservableProperty]
        private string? defaultWindowsInputBoxLabelContent = "Default Windows Version";

        [ObservableProperty]
        private string? chooseALanguageLabelContent = "Choose a Language";

        [ObservableProperty]
        private string? chooseAThemeLabelContent = "Choose a Theme";

        [ObservableProperty]
        private string? resetChangesButtonLabel = "Reset Setting (Require app to be restart to take effect}"; 

        [ObservableProperty]
        private bool isFluentUIEnable = true;

        [ObservableProperty]
        private string? defaultWindowsVersionInputBoxValue;

        [ObservableProperty]
        private ObservableCollection<string> localesAvailable = langs;

        [ObservableProperty]
        private string? localeSelected;

        [ObservableProperty]
        private ObservableCollection<string> themesAvailable = new(settings?.GetThemesList() ?? ["System", "Dark", "Light", "None"]); //this temporaly list isnt supposed to be there

        [ObservableProperty]
        private string? themeSelected;

        /// <summary>
        /// This is temporaly until i add the language service later
        /// </summary>
        private static ObservableCollection<string> langs = [Locales.FR.GetString(), Locales.EN.GetString()];

        [RelayCommand] 
        private void ConfirmChangesButton() 
        {
            settings?.SaveConfig(
                new Dictionary<string, string>
                {
                    { "LocaleSelected", LocaleSelected ?? "English" },
                    { "DefaultWindowsVersionInputBoxValue", DefaultWindowsVersionInputBoxValue ?? "Windows NT" },
                    { "IsFluentUIEnable", IsFluentUIEnable.ToString() },
                    { "ThemeSelected", ThemeSelected ?? "System"}
                }
                ); 
            if (settings == null)
            {
                MessageBox.Show("Error : Setting Manager Service wasn't found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task SetCheckUpdateButton()
        {
            try
            {
                await Task.Run(() => { Process.Start("explorer", "https://github.com/xgui4/WPFetch/releases"); });
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Unexcepted Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task ResetChangesButton() 
        {
            try
            {
                await Task.Run(() => { settings?.ResetSetting(); });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexcepted Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
