using WPFetch.Utils;

namespace WPFetch.Model.Enums
{
    /// <summary>
    /// Enum of the supported OS-Tan WPFetch can show
    /// </summary>
    public enum Os_Tan
    {
#pragma warning disable CS1591
        Windows1,
        Windows2,
        Windows3Dot1,
        NT,
        Windows95,
        Windows97,
        Windows98,
        Windows8SE,
        WindowsNeptune,
        WindowsOdyssey,
        WindowsME,
        Windows2000,
        WindowsXP,
        WindowsLonghorn,
        WindowsVista,
        WindowsServer2003,
        WindowsServer2008,
        Windows7,
        Windows8,
        Windows10,
        Windows11,
        Windows11Alt
#pragma warning restore CS1591
    }

    /// <summary>
    /// The function extention for the Os_Tan Enum Extension
    /// </summary>
    public static class Os_TanExtension
    {
        private static readonly RessourcesManager Ressources = new(); 

        /// <summary>
        /// Get the OS-Tan image location
        /// </summary>
        /// <param name="tan">The OS-Tan to get it's image selection</param>
        /// <returns></returns>
        public static string GetOsTanPathImgPath(this Os_Tan tan)
        {
            return tan switch
            {
                Os_Tan.Windows1 => "https://www.ostan-collections.net/wiki/index.php/File:Windows1avi.png",
                Os_Tan.Windows2 => "https://www.ostan-collections.net/wiki/images/2/2f/Windows2avi.png",
                Os_Tan.Windows3Dot1 => "https://www.ostan-collections.net/wiki/images/c/c5/Win3-1.jpg",
                Os_Tan.NT => "https://www.ostan-collections.net/wiki/images/d/d6/WinNTtan.jpg",
                Os_Tan.Windows95 => "https://www.ostan-collections.net/wiki/images/d/d3/95-tan2.jpg?20120630044724",
                Os_Tan.Windows97 => "https://www.ostan-collections.net/wiki/images/4/4f/Win97tan.jpg?20110501013251",
                Os_Tan.Windows8SE => "https://www.ostan-collections.net/wiki/images/8/8f/98SEtan.jpg",
                Os_Tan.Windows98 => "https://www.ostan-collections.net/wiki/images/thumb/6/6b/Win98tan.jpg/120px-Win98tan.jpg?20110403225234",
                Os_Tan.WindowsNeptune => "https://www.ostan-collections.net/wiki/images/6/6d/Neptune.gif?20070125034107",
                Os_Tan.WindowsOdyssey => "https://www.ostan-collections.net/wiki/images/8/8c/Odyssey.gif?20070125034833",
                Os_Tan.WindowsME => "https://www.ostan-collections.net/wiki/images/0/0c/Winme.jpg",
                Os_Tan.Windows2000 => "https://www.ostan-collections.net/wiki/images/0/0d/Win2K.jpg",
                Os_Tan.WindowsXP => "https://gallery.ostan-collections.net/data/original/45/b3/45b3340b11cdab9a013d4ea986bc1194.jpg",
                Os_Tan.WindowsLonghorn => "https://camo.githubusercontent.com/82c4fa6e099ca3ef9fc703904f29865692577c38483743f0b3429b488145e908/68747470733a2f2f6e6575726f2e6e79612e7075622f66756e2f6f7374616e2f6c6f6e67686f726e2e6a7067",
                Os_Tan.WindowsVista => "https://www.ostan-collections.net/wiki/images/thumb/d/da/Schoolgirlvistan.jpg/450px-Schoolgirlvistan.jpg",
                Os_Tan.WindowsServer2003 => "https://www.ostan-collections.net/wiki/images/2/2f/WinServer2003tan.jpg",
                Os_Tan.WindowsServer2008 => "https://www.ostan-collections.net/wiki/images/thumb/1/1a/Saba-fish.jpg/300px-Saba-fish.jpg",
                Os_Tan.Windows7 => Ressources.GetImagesPath("os-tan7.png", "OS-Tan"),
                Os_Tan.Windows8 => "https://www.ostan-collections.net/wiki/images/7/77/Yuai.png",
                Os_Tan.Windows10 => "https://www.ostan-collections.net/wiki/images/thumb/0/04/10-full_promo.png/414px-10-full_promo.png?20150609062724",
                Os_Tan.Windows11 => Ressources.GetImagesPath("win11-os-tan-temp.png", "OS-Tan"),
                Os_Tan.Windows11Alt => Ressources.GetImagesPath("fanart-ichika-madobe-mascot-windows-11-v0-1n9jlmb54poa1.webp", "OS-Tan"),
                _ => "Not found!"
            };
        }
    }
}
