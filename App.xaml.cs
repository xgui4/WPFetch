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
            try
            {
                HardwareInfoService.Update();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error while fetching system info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
