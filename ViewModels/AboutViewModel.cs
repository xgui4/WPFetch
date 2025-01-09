using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        [RelayCommand]
        private void SetCheckUpdateButton()
        {
            Process.Start("explorer", "https://github.com/xgui4/WPFetch/releases"); 
        }
    }
}
