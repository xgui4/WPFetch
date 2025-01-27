using Microsoft.Win32;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using WPFetch.Backend;
using WPFetch.Model;
using WPFetch.Model.Json;

namespace DesktopWallpaper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CommandLineArguments? CmdArgs { get; private set; }
        public HardwareInfoService? HardwareInfoService { get; private set; }
        public MainImageService? MainImageService { get; private set; }
        private LoggerService? AppLoggerService { get; set; }
        public SettingService? SettingService { get; private set; }
        public RessourcesManagerService? RessourcesManagerService { get; private set; }
        public string? Theme { get; private set; }

        /// <summary>
        /// Source du code : https://wpf-tutorial.com/wpf-application/command-line-parameters/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                CmdArgs = new CommandLineArguments(e.Args);
                HardwareInfoService = new HardwareInfoService();
                MainImageService = new MainImageService((App)Application.Current);
                AppLoggerService = new LoggerService("App");
                SettingService = new SettingService();
                RessourcesManagerService = new RessourcesManagerService();

                try
                {
                    SettingService.ObtainPreferencesFromDisk();
                    Setting setting = SettingService.GetSetting();
                    SettingService.AddAppliedSettings(setting);
                }
                catch (Exception ex)
                {
                    AppLoggerService.Log($"Critical Error when applying theme : {ex.Message}");
                }

                try
                {
                    HardwareInfoService.Update();
                }
                catch (Exception ex)
                {
                    AppLoggerService.Log($"Critical Error while fetching system info : {ex.Message}");
                }

                try
                {
                    if (IsMicaSupported())
                    {
                        SetUpMicaTheme();
                    }
                    else
                    {
                        AppLoggerService.Log($"Mica (Fluent UI with transparency) is not supported in your Windows version: Mica requires Windows 11 and later. Fallback to default WPF theme.");
                        Theme = "White";
                    }
                }
                catch (Exception ex)
                {
                    AppLoggerService.Log($"Critical error while applying theme : {ex.Message}");
                    Theme = "White";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some error occured while loading services, this app might not work as attended. \n Excepion Occured : ,\n {ex.Message}", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetUpMicaTheme()
        {
            try
            {
                Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/PresentationFramework.Fluent;component/Themes/Fluent.xaml")
                });

                int? appLightMode = (int?)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1) ?? -1;
                Theme = appLightMode == 0 ? "Dark" : "White";

                var settingTemp = SettingService?.GetSetting();


                if (settingTemp != null)
                {
                    if (settingTemp.Theme == "Dark")
                    {
                        Current.ThemeMode = ThemeMode.Dark;
                        Theme = "Dark";
                    }
                    if (settingTemp.Theme == "White")
                    {
                        Current.ThemeMode = ThemeMode.Light;
                        Theme = "Light";
                    }
                    if (settingTemp.Theme == "System")
                    {
                        Current.ThemeMode = ThemeMode.System;
                        Theme = "System";
                    }
                    if (settingTemp.Theme == "None")
                    {
                        Current.ThemeMode = ThemeMode.None;
                        Theme = "None";
                    }
                }
                
            }
            catch (Exception ex)
            {
                AppLoggerService?.Log(ex.Message);
            }
        }

        /// <summary>
        /// Return true if the current windows version support Mica 
        /// </summary>
        /// <returns> true if the os is windows 11 else false </returns>
        private static bool IsMicaSupported()
        {
            if (OperatingSystem.IsWindows())
            {
                if (Environment.OSVersion.Version.Major >= 10)
                {
                    if (Environment.OSVersion.Version.Build >= 22000)
                    {
                        return true;
                    }
                }
            } 
            return false;
        }
    }
}
