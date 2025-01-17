using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using WPFetch.Backend;
using WPFetch.Model;

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
        public LoggerServiceService? LoggerService { get; private set; }
        public SettingService? SettingService { get; private set; }
        public ThemeService? ThemeService { get; private set; }
        public RessourcesManagerService? RessourcesManagerService { get; private set; }

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
            LoggerService = new LoggerServiceService();
            SettingService = new SettingService();
            ThemeService = new ThemeService();
            RessourcesManagerService = new RessourcesManagerService();

            try
            {
                HardwareInfoService.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while fetching system info", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Check Windows version and apply appropriate theme
            if (IsFluentThemeSupported())
            {
                Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/PresentationFramework.Fluent;component/Themes/Fluent.xaml")
                });
            }
            else
            {
                MessageBox.Show("Fluent UI is not supported in your Windows Versions. Fallback to Defaut WPF theme.");
                /* To be find the good .XAML file
                Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/PresentationFramework.AeroLite;component/Themes/AeroLite.xaml")
                });
                */
            }
        }

        /// <summary>
        /// Return true if the current windows version 
        /// support fluent (right now win10 require a workaround
        /// that will also affect win11 so I temporaly disabled it 
        /// until a better solution is discover)
        /// </summary>
        /// <returns> true if the os is windows 11 else false </returns>
        private bool IsFluentThemeSupported()
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
