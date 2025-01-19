using Microsoft.Win32;
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
        public string? Theme { get; private set; } = "Dark";

        /// <summary>
        /// Source du code : https://wpf-tutorial.com/wpf-application/command-line-parameters/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CmdArgs = new CommandLineArguments(e.Args);
            HardwareInfoService = new HardwareInfoService();
            MainImageService = new MainImageService((App)Application.Current);
            AppLoggerService = new LoggerService("App");
            SettingService = new SettingService();
            RessourcesManagerService = new RessourcesManagerService();

            try
            {
                Setting setting = SettingService.GetSettings();
                SettingService.AddAppliedSettings(setting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while applying setting from confile file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                HardwareInfoService.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while fetching system info", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                if (IsMicaSupported())
                {
                    Resources.MergedDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri("pack://application:,,,/PresentationFramework.Fluent;component/Themes/Fluent.xaml")
                    });
                    int? appLightMode = (int?)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1) ?? -1;
                    Theme = appLightMode == 0 ? "Dark" : "White";
                }
                else
                {
                    MessageBox.Show("Mica (Fluent UI with transparency) is not supported in your Windows version: Mica requires Windows 11 and later. Fallback to default WPF theme.");
                    Theme = "White";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while applying theme", MessageBoxButton.OK, MessageBoxImage.Error);
                Theme = "White"; 
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
