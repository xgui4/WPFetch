using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using WPFetch.Model;

namespace DesktopWallpaper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CommandLineArguments? CmdArgs { get; private set; }

        /// <summary>
        /// Source du code : https://wpf-tutorial.com/wpf-application/command-line-parameters/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CmdArgs = new CommandLineArguments(e.Args);

            /*
            int answer = (int)MessageBox.Show("Do you want to add the program to your start menu ?", "Add shortcut to start menu?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == 6)
            {
                try
                {
                    string pathvar = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                    Environment.SetEnvironmentVariable("PATH", pathvar + ";" + Environment.ProcessPath + "\\", EnvironmentVariableTarget.Machine);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            */
        }
    }
}
