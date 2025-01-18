using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WPFetch.Model.Enums;
using WPFetch.Model.Json;
using WPFetch.Model.System;

namespace WPFetch.Backend
{
    public record DefaultSetting : Setting
    {
        public DefaultSetting() : base(Locales.EN.GetString(), "default", true, "system", [])
        {
        }
        public DefaultSetting(string locale, string defaultWindowsVersion, bool fluentUIEnable, string theme, SystemOptions[] hardwaresToFetch) : base(locale, defaultWindowsVersion, fluentUIEnable, theme, hardwaresToFetch)
        {
        }

        protected DefaultSetting(Setting original) : base(original)
        {
        }
    }
}
