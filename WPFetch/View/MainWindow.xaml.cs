using System.Windows;
using System.Windows.Media.Imaging;

namespace WPFetch;

public partial class MainWindow : Window
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public MainWindow()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        InitializeComponent();

#pragma warning disable WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        if (Application.Current.ThemeMode == ThemeMode.None || Application.Current.ThemeMode == ThemeMode.Light)
        {
            BitmapImage memoryStick = new(); 
            memoryStick.BeginInit(); memoryStick.UriSource = new Uri("../Ressources/Images/icons/ram.png", UriKind.Relative); 
            memoryStick.EndInit(); MemorySickImage.Source = memoryStick;
        }
#pragma warning restore WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

}
