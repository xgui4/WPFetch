using WPFetch.Utils;

namespace WPFetch.Model.Enums
{
    /// <summary>
    /// Collection of Windows Version logo
    /// </summary>
    public enum WindowsVerImage
    {
        /// <summary>
        /// Windows 1
        /// </summary>
        WIN_1,
        /// <summary>
        /// Windows 2
        /// </summary>
        WIN_2, 
        /// <summary>
        /// Windows 3
        /// </summary>
        WIN_3,
        /// <summary>
        /// Windows NTs 
        /// </summary>
        WIN_NT,
        /// <summary>
        /// Windows 95
        /// </summary>
        WIN_95,
        /// <summary>
        /// Windows 98
        /// </summary>
        WIN_98,
        /// <summary>
        /// Microsoft Neptune
        /// </summary>
        WIN_NEPTUNE,
        /// <summary>
        /// Windows ME
        /// </summary>
        WIN_ME,
        /// <summary>
        /// Windows 2000
        /// </summary>
        WIN_2K,
        /// <summary>
        /// Windows XP
        /// </summary>
        WIN_XP,
        /// <summary>
        /// Windows Longhorn
        /// </summary>
        WIN_LONGHORN,
        /// <summary>
        /// Windows Vista
        /// </summary>
        WIN_VISTA,
        /// <summary>
        /// Windows 7
        /// </summary>
        WIN_7,
        /// <summary>
        /// Windows 8
        /// </summary>
        WIN_8,
        /// <summary>
        /// Windows 10
        /// </summary>
        WIN_10,
        /// <summary>
        /// Windows 11
        /// </summary>
        WIN_11
    }

    /// <summary>
    /// An extensionn to get the windows images paths for light and dark mode 
    /// </summary>
    public static class WindowsVerImageExtension
    {
        private static readonly RessourcesManager Ressources = new();
        /// <summary>
        /// Get the logo of the windows versions for dark mode
        /// </summary>
        /// <param name="winVer">the windows version</param>
        /// <returns>the image path</returns>
        public static string GetWindowsVerPathForDarkMode(this WindowsVerImage winVer)
        {
            return winVer switch
            {
                WindowsVerImage.WIN_XP => Ressources.GetImagesPath("WindowsXP-white.png", "Windows"),
                WindowsVerImage.WIN_VISTA => Ressources.GetImagesPath("winVista-white.png", "Windows"),
                WindowsVerImage.WIN_7 => Ressources.GetImagesPath("win7-white.png", "Windows"),
                WindowsVerImage.WIN_8 => Ressources.GetImagesPath("win8.png", "Windows"),
                WindowsVerImage.WIN_10 => Ressources.GetImagesPath("win10.png", "Windows"),
                WindowsVerImage.WIN_11 => Ressources.GetImagesPath("win11.png", "Windows"),
                WindowsVerImage.WIN_1 => Ressources.GetImagesPath("winX-white.png", "Windows"),
                WindowsVerImage.WIN_2 => Ressources.GetImagesPath("winX-white.png", "Windows"),
                WindowsVerImage.WIN_3 => Ressources.GetImagesPath("win3X-white.png", "Windows"),
                WindowsVerImage.WIN_NT => Ressources.GetImagesPath("winNT-white.png", "Windows"),
                WindowsVerImage.WIN_95 => Ressources.GetImagesPath("win95-white.png", "Windows"),
                WindowsVerImage.WIN_98 => Ressources.GetImagesPath("win98-white.png" , "Windows"),
                WindowsVerImage.WIN_NEPTUNE => Ressources.GetImagesPath("winNeptune-white.png", "Windows"),
                WindowsVerImage.WIN_ME => Ressources.GetImagesPath("winME-white.png", "Windows"),
                WindowsVerImage.WIN_2K => Ressources.GetImagesPath("win2K.png", "Windows"),
                WindowsVerImage.WIN_LONGHORN => Ressources.GetImagesPath("winLonghorn-white.png", "Windows"),
                _ => "Not Found!",
            };
        }

        /// <summary>
        /// Get the logo of the windows versions for light mode mode
        /// </summary>
        /// <param name="winVer">the windows version</param>
        /// <returns>the image path</returns>
        public static string GetWindowsVerPathForLightMode(this WindowsVerImage winVer)
        {
            return winVer switch
            {
                WindowsVerImage.WIN_XP => Ressources.GetImagesPath("WindowsXP.png", "Windows"),
                WindowsVerImage.WIN_VISTA => Ressources.GetImagesPath("winVista.png", "Windows"),
                WindowsVerImage.WIN_7 => Ressources.GetImagesPath("win7.png", "Windows"),
                WindowsVerImage.WIN_8 => Ressources.GetImagesPath("win8.png", "Windows"),
                WindowsVerImage.WIN_10 => Ressources.GetImagesPath("win10.png", "Windows"),
                WindowsVerImage.WIN_11 => Ressources.GetImagesPath("win11.png", "Windows"),
                WindowsVerImage.WIN_1 => Ressources.GetImagesPath("winX.png", "Windows"),
                WindowsVerImage.WIN_2 => Ressources.GetImagesPath("winX.png", "Windows"),
                WindowsVerImage.WIN_3 => Ressources.GetImagesPath("win3X.png", "Windows"),
                WindowsVerImage.WIN_NT => Ressources.GetImagesPath("winNT.png", "Windows"),
                WindowsVerImage.WIN_95 => Ressources.GetImagesPath("win95.png", "Windows"),
                WindowsVerImage.WIN_98 => Ressources.GetImagesPath("win98.png", "Windows"),
                WindowsVerImage.WIN_NEPTUNE => Ressources.GetImagesPath("winNeptune.png", "Windows"),
                WindowsVerImage.WIN_ME => Ressources.GetImagesPath("winME.png", "Windows"),
                WindowsVerImage.WIN_2K => Ressources.GetImagesPath("win2K.png", "Windows"),
                WindowsVerImage.WIN_LONGHORN => Ressources.GetImagesPath("winLonghorn.png", "Windows"),
                _ => "Not Found!",
            };
        }
    }
}
