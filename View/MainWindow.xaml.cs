using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using WPFetch.Model;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopWallpaper;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

#pragma warning disable WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        if (Application.Current.ThemeMode == ThemeMode.None || Application.Current.ThemeMode == ThemeMode.Light)
        {
            BitmapImage memoryStick = new(); 
            memoryStick.BeginInit(); memoryStick.UriSource = new Uri("../Ressources/Images/ram.png", UriKind.Relative); 
            memoryStick.EndInit(); MemorySickImage.Source = memoryStick;
        }
#pragma warning restore WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

}
