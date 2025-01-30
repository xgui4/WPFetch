using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WPFetch.Utils;

namespace WPFetch.Model.Enums
{
    public enum Os_Tan
    {
        WINDOWS_1,
        WINDOWS_2,
        WINDOWS_3dot1,
        NT,
        WINDOWS_95,
        WINDOWS_97,
        WINDOWS_98,
        WINDOWS_98SE,
        WINDOWS_NEPTUNE,
        WINDOWS_ODYSSEY,
        WINDOWS_ME,
        WINDOWS_2000,
        WINDOWS_XP,
        WINDOWS_LONGHORN,
        WINDOWS_VISTA,
        WINDOWS_SERVER_2003,
        WINDOWS_SERVER_2008,
        WINDOWS_7,
        WINDOWS_8,
        WINDOWS_10,
        WINDOWS_11,
        WINDOWS_11_ALT
    }

    public static class Os_TanExtension
    {
        private static readonly RessourcesManager ressources = new(); 
        public static string GetOsTanPathImgPath(this Os_Tan tan)
        {
            return tan switch
            {
                Os_Tan.WINDOWS_1 => "https://www.ostan-collections.net/wiki/index.php/File:Windows1avi.png",
                Os_Tan.WINDOWS_2 => "https://www.ostan-collections.net/wiki/images/2/2f/Windows2avi.png",
                Os_Tan.WINDOWS_3dot1 => "https://www.ostan-collections.net/wiki/images/c/c5/Win3-1.jpg",
                Os_Tan.NT => "https://www.ostan-collections.net/wiki/images/d/d6/WinNTtan.jpg",
                Os_Tan.WINDOWS_95 => "https://www.ostan-collections.net/wiki/images/d/d3/95-tan2.jpg?20120630044724",
                Os_Tan.WINDOWS_97 => "https://www.ostan-collections.net/wiki/images/4/4f/Win97tan.jpg?20110501013251",
                Os_Tan.WINDOWS_98SE => "https://www.ostan-collections.net/wiki/images/8/8f/98SEtan.jpg",
                Os_Tan.WINDOWS_98 => "https://www.ostan-collections.net/wiki/images/thumb/6/6b/Win98tan.jpg/120px-Win98tan.jpg?20110403225234",
                Os_Tan.WINDOWS_NEPTUNE => "https://www.ostan-collections.net/wiki/images/6/6d/Neptune.gif?20070125034107",
                Os_Tan.WINDOWS_ODYSSEY => "https://www.ostan-collections.net/wiki/images/8/8c/Odyssey.gif?20070125034833",
                Os_Tan.WINDOWS_ME => "https://www.ostan-collections.net/wiki/images/0/0c/Winme.jpg",
                Os_Tan.WINDOWS_2000 => "https://www.ostan-collections.net/wiki/images/0/0d/Win2K.jpg",
                Os_Tan.WINDOWS_XP => "https://gallery.ostan-collections.net/data/original/45/b3/45b3340b11cdab9a013d4ea986bc1194.jpg",
                Os_Tan.WINDOWS_LONGHORN => "https://camo.githubusercontent.com/82c4fa6e099ca3ef9fc703904f29865692577c38483743f0b3429b488145e908/68747470733a2f2f6e6575726f2e6e79612e7075622f66756e2f6f7374616e2f6c6f6e67686f726e2e6a7067",
                Os_Tan.WINDOWS_VISTA => "https://www.ostan-collections.net/wiki/images/thumb/d/da/Schoolgirlvistan.jpg/450px-Schoolgirlvistan.jpg",
                Os_Tan.WINDOWS_SERVER_2003 => "https://www.ostan-collections.net/wiki/images/2/2f/WinServer2003tan.jpg",
                Os_Tan.WINDOWS_SERVER_2008 => "https://www.ostan-collections.net/wiki/images/thumb/1/1a/Saba-fish.jpg/300px-Saba-fish.jpg",
                Os_Tan.WINDOWS_7 => ressources.GetImagesPath("os-tan7.png"),
                Os_Tan.WINDOWS_8 => "https://www.ostan-collections.net/wiki/images/7/77/Yuai.png",
                Os_Tan.WINDOWS_10 => "https://www.ostan-collections.net/wiki/images/thumb/0/04/10-full_promo.png/414px-10-full_promo.png?20150609062724",
                Os_Tan.WINDOWS_11 => ressources.GetImagesPath("win11-os-tan-temp.png"),
                Os_Tan.WINDOWS_11_ALT => ressources.GetImagesPath("fanart-ichika-madobe-mascot-windows-11-v0-1n9jlmb54poa1.webp"),
                _ => "Not found!"
            };
        }
    }
}
