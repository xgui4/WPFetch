using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using WPFetch;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

using WPFetch.Model.Enums;
using WPFetch.Services;

namespace WPFetch.ViewModels;

internal partial class AboutViewModel : ObservableObject
{
    private static readonly App App = (App)Application.Current;

    private static SettingService? s_settings;

    private static RessourcesManagerService? s_ressourcesManagerService; 

    public AboutViewModel()
    {
        try
        {
            s_settings = App.SettingService ?? throw new Exception("Setting Service Not Found !");
            s_ressourcesManagerService = App.RessourcesManagerService ?? throw new Exception("Ressources Managers Service Not Found !");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Critical Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }

    [ObservableProperty]
    private string? fullTitleValue = "WPFetch Alpha Version 0.0.1.0";

    [ObservableProperty]
    private string? descriptionValue = "A utility to fetch you system info with a OS-tan.";

    [ObservableProperty]
    private string? featuresLabelValue =
        """
        Features
            - Fetch you hardware like noefetch does but with a GUI and with customisable main image 
            - Show OS-Tan as main images and windows logo on top on of the setup info
            - Command line argurment
            - Configuration via GUI
            - Link for a the github release page in the check update button (might do more in the future)
        """;

    [ObservableProperty]
    private string? techUsedLabelValue =
        """
        ## Nuget Packages && Framework used :
        - Community Toolkit
        - FluentSysInfo.Core
        - Newtonsoft.Json
        - System.Drawing.Common
        - System.Management
        - Windows Presentation Foundation
        - Inno Setup for the installer
        """;

    [ObservableProperty]
    private string? appIconPath = "../Assets/Images/icons/appicon.ico";

    [ObservableProperty]
    private string? authorsLabel = "Developer : Xgui4";

    [ObservableProperty]
    private string? licenseLabel = "License : GPLv3 License";

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
    private ObservableCollection<string> themesAvailable = new(s_settings?.GetThemesList() ?? ["System", "Dark", "Light", "None"]); //this temporaly list isnt supposed to be there

    [ObservableProperty]
    private string? themeSelected;

    /// <summary>
    /// This is temporaly until i add the language service later
    /// </summary>
    private static ObservableCollection<string> langs = [Locales.FR.GetString(), Locales.EN.GetString()];

    [RelayCommand] 
    private void ConfirmChangesButton() 
    {
        s_settings?.SaveConfig(
            new Dictionary<string, string>
            {
                { "LocaleSelected", LocaleSelected ?? "English" },
                { "DefaultWindowsVersionInputBoxValue", DefaultWindowsVersionInputBoxValue ?? "Windows NT" },
                { "IsFluentUIEnable", IsFluentUIEnable.ToString() },
                { "ThemeSelected", ThemeSelected ?? "System"}
            }
            ); 
        if (s_settings == null)
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
            await Task.Run(() => s_settings?.ResetSetting());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexcepted Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
