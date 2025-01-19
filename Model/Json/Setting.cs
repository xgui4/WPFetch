using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Model.Enums;
using WPFetch.Model.System;

namespace WPFetch.Model.Json
{
    [JsonObject("Setting")]
    public record Setting
    {
        [JsonProperty(nameof(LocaleSelected))]
        public Locales LocaleSelected { get; set; }

        [JsonProperty(nameof(DefaultWindowsVersions))]
        public string DefaultWindowsVersions { get; set; }

        [JsonProperty(nameof(IsFluentUIEnabled))]
        public bool IsFluentUIEnabled { get; set; }

        [JsonProperty(nameof(Theme))]
        public string Theme { get; set; }

        [JsonProperty(nameof(HardwaresToFetch))]
        public SystemOptions[] HardwaresToFetch { get; set; }

        public Setting(string locale, string defaultWindowsVersion, bool fluentUIEnable, string theme, SystemOptions[] hardwaresToFetch)
        {
            if (locale == Locales.FR.GetString()) LocaleSelected = Locales.FR;  
            else LocaleSelected = Locales.EN;

            DefaultWindowsVersions = defaultWindowsVersion;

            IsFluentUIEnabled = fluentUIEnable;

            Theme = theme;

            HardwaresToFetch = hardwaresToFetch;
        }

        public override string ToString()
        {
            return $"Locale : {LocaleSelected.ToString()}, Default Win Version : {DefaultWindowsVersions}, Fluent Theme : {IsFluentUIEnabled}, Aero2 Theme Mode : {Theme} , List of Hardware To Fetch : {HardwaresToFetch}";
        }
    }
}