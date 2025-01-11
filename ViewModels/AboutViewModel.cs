using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFetch.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? fullTitleValue = "WPFetch Version 0.0.0.1 Developer Preview 2";

        [ObservableProperty]
        private string? descriptionValue = "A utility to fetch you system info with a OS-tan";

        [ObservableProperty]
        private string? appIconPath = "../Images/appicon.ico";

        [ObservableProperty]
        private string? checkUpdateButtonLabel = "Check Update";

        [ObservableProperty]
        private string? configureAppButtonLabel = "Configure App Setting";

        [RelayCommand]
        private void SetConfigureAppButton()
        {
            MessageBox.Show("This is still a work in progress", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation); 

        }

        [RelayCommand]
        private async Task SetCheckUpdateButton()
        {
            await Task.Run(() => { Process.Start("explorer", "https://github.com/xgui4/WPFetch/releases"); }); 
        }
    }
}
