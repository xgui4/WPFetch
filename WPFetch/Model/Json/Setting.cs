using Newtonsoft.Json;
using System.Text;
using WPFetch.Model.Enums;
using WPFetch.Model.System;

namespace WPFetch.Model.Json
{
    /// <summary>
    /// The setting model record
    /// </summary>
    [JsonObject("Setting")]
    public record Setting
    {
        /// <summary>
        /// The selected locale
        /// </summary>
        [JsonProperty(nameof(LocaleSelected))]
        public Locales LocaleSelected { get; set; }

        /// <summary>
        /// The default Windows versions
        /// </summary>
        [JsonProperty(nameof(DefaultWindowsVersions))]
        public string DefaultWindowsVersions { get; set; }

        /// <summary>
        /// Enable or Disable Fluent UI (Windows 11 only)
        /// </summary>
        [JsonProperty(nameof(IsFluentUIEnabled))]
        public bool IsFluentUIEnabled { get; set; }

        /// <summary>
        /// The seleced theme
        /// </summary>
        [JsonProperty(nameof(Theme))]
        public string Theme { get; set; }

        /// <summary>
        /// List of hardware to fetch (not functionnal yet)
        /// </summary>
        [JsonProperty(nameof(HardwaresToFetch))]
        public SystemOptions[] HardwaresToFetch { get; set; }

        /// <summary>
        /// Initiate an setting in 
        /// </summary>
        /// <param name="locale">The selected locale</param>
        /// <param name="defaultWindowsVersion"> The default Windwos Version</param>
        /// <param name="fluentUIEnable">Status of FluentUI</param>
        /// <param name="theme">The selected theme</param>
        /// <param name="hardwaresToFetch">The list of  hardware to fetchs (not functionnal yet)</param>
        public Setting(string locale, string defaultWindowsVersion, bool fluentUIEnable, string theme, SystemOptions[] hardwaresToFetch)
        {
            if (locale == Locales.FR.GetString()) LocaleSelected = Locales.FR;  
            else LocaleSelected = Locales.EN;

            DefaultWindowsVersions = defaultWindowsVersion;

            IsFluentUIEnabled = fluentUIEnable;

            Theme = theme;

            HardwaresToFetch = hardwaresToFetch;
        }

        /// <summary>
        /// Returns a string that summarizes the current settings, including locale, default Windows version, theme
        /// preferences, and hardware selection.
        /// </summary>
        /// <returns>A string representation of the object's current configuration.</returns>
        public override string ToString()
        {
            return $"Locale : {LocaleSelected.ToString()}, Default Win Version : {DefaultWindowsVersions}, Fluent Theme : {IsFluentUIEnabled}, Aero2 Theme Mode : {Theme} , List of Hardware To Fetch : {HardwaresToFetch}";
        }
    }
}