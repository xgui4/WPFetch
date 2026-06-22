using System.Text;
using WPFetch.Model.Enums;
using WPFetch.Model.System;

namespace WPFetch.Model.Json;


/// <summary>
/// The model of the default setting
/// </summary>
public record DefaultSetting : Setting
{
    /// <summary>
    /// Generate the default setting with no arguments
    /// </summary>
    public DefaultSetting() : base(Locales.EN.GetString(), "default", true, "system", [])
    {
    }

    /// <summary>
    /// Generate the default setting with arguments
    /// </summary>
    /// <param name="locale">The selected locale</param>
    /// <param name="defaultWindowsVersion">The default window version to override</param>
    /// <param name="fluentUIEnable">enable or disable fluent ui (Windows 11 only)</param>
    /// <param name="theme">The selected theme</param>
    /// <param name="hardwaresToFetch">the list of hardware to fetch (not functionnal yet)</param>
    public DefaultSetting(string locale, string defaultWindowsVersion, bool fluentUIEnable, string theme, SystemOptions[] hardwaresToFetch) : base(locale, defaultWindowsVersion, fluentUIEnable, theme, hardwaresToFetch)
    {
    }

    /// <summary>
    /// Generate the default setting with an already existing setting
    /// </summary>
    /// <param name="original">An already existing setting</param>
    protected DefaultSetting(Setting original) : base(original)
    {
    }
}
