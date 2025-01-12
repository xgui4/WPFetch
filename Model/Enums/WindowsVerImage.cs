using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get the logo of the windows versions
        /// </summary>
        /// <param name="winVer"></param>
        /// <returns></returns>
        public static string GetWindowsVerPath(this WindowsVerImage winVer)
        {
            return winVer switch
            {
                WindowsVerImage.WIN_XP => "../Images/WindowsXP-white.png",
                WindowsVerImage.WIN_VISTA => "../Images/winVista-white.png",
                WindowsVerImage.WIN_7 => "../Images/win7-white.png",
                WindowsVerImage.WIN_8 => "../Images/win8.png",
                WindowsVerImage.WIN_10 => "../Images/win10.png",
                WindowsVerImage.WIN_11 => "../Images/win11.png",
                WindowsVerImage.WIN_1 => "../Images/winX-white.png",
                WindowsVerImage.WIN_2 => "../Images/winX-white.png",
                WindowsVerImage.WIN_3 => "../Images/win3X-white.png",
                WindowsVerImage.WIN_NT => "../Images/winNT-white.png",
                WindowsVerImage.WIN_95 => "../Images/win95-white.png",
                WindowsVerImage.WIN_98 => "../Images/win98-white.png",
                WindowsVerImage.WIN_NEPTUNE => "../Images/winNeptune-white.png",
                WindowsVerImage.WIN_ME => "../Images/winME-white.png",
                WindowsVerImage.WIN_2K => "../Images/win2K.png",
                WindowsVerImage.WIN_LONGHORN => "../Images/winLonghorn-white.png",
                _ => "Not Found!",
            };
        }
    }
}
