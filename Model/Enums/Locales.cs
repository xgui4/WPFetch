using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Model.Enums
{
    public enum Locales
    {
        EN,
        FR 
    }

    public static class LocalesExtention
    {
        public static string GetString(this Locales locales)
        {
            return locales switch
            {
                Locales.FR => "Français",
                Locales.EN => "English",
                _ => throw new ArgumentException("This locale is invalid!")
            };
        }
    }
}
