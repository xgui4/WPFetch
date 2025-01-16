using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public static class WindowsVerImageExtension
    {
        private static readonly RessourcesManager ressources = new();
        /// <summary>
        /// Get the logo of the windows versions
        /// </summary>
        /// <param name="winVer"></param>
        /// <returns></returns>
        public static string GetWindowsVerPath(this WindowsVerImage winVer)
        {
            return winVer switch
            {
                WindowsVerImage.WIN_XP => ressources.GetImagesPath("WindowsXP-white.png"),
                WindowsVerImage.WIN_VISTA => ressources.GetImagesPath("winVista-white.png"),
                WindowsVerImage.WIN_7 => ressources.GetImagesPath("win7-white.png"),
                WindowsVerImage.WIN_8 => ressources.GetImagesPath("win8.png"),
                WindowsVerImage.WIN_10 => ressources.GetImagesPath("win10.png"),
                WindowsVerImage.WIN_11 => ressources.GetImagesPath("win11.png"),
                WindowsVerImage.WIN_1 => ressources.GetImagesPath("winX-white.png"),
                WindowsVerImage.WIN_2 => ressources.GetImagesPath("winX-white.png"),
                WindowsVerImage.WIN_3 => ressources.GetImagesPath("win3X-white.png"),
                WindowsVerImage.WIN_NT => ressources.GetImagesPath("winNT-white.png"),
                WindowsVerImage.WIN_95 => ressources.GetImagesPath("win95-white.png"),
                WindowsVerImage.WIN_98 => ressources.GetImagesPath("win98-white.png"),
                WindowsVerImage.WIN_NEPTUNE => ressources.GetImagesPath("winNeptune-white.png"),
                WindowsVerImage.WIN_ME => ressources.GetImagesPath("winME-white.png"),
                WindowsVerImage.WIN_2K => ressources.GetImagesPath("win2K.png"),
                WindowsVerImage.WIN_LONGHORN => ressources.GetImagesPath("winLonghorn-white.png"),
                _ => "Not Found!",
            };
        }
    }
}
