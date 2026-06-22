using Newtonsoft.Json;

using System.IO;

using WPFetch.Backend;
using WPFetch.Exceptions;
using WPFetch.Model.Json;
using WPFetch.Model.System;
using WPFetch.Utils;

namespace WPFetch.Services;

/// <summary>
/// The Setting Service. control the setting of the application
/// </summary>
public class SettingService
{
    private readonly LoggerService _logger;
    private Setting? _setting;
    private SettingManager? _settingManager;

    /// <summary>
    ///nitializes a new instance of the SettingService class.
    /// </summary>
    /// <param name="ressourcesManagerService">The ressource manager service</param>
    public SettingService(RessourcesManagerService ressourcesManagerService)
    {
        _logger = new LoggerService("SettingService", ressourcesManagerService);
        _setting = null; 
    }

    /// <summary>
    /// Applies the specified setting by initializing the SettingManager with it.
    /// </summary>
    /// <param name="appliedSetting">The setting to apply.</param>
    public void AddAppliedSettings(Setting appliedSetting)
    {
        _settingManager = new SettingManager(appliedSetting); 
    }

    /// <summary>
    /// Get the theme list
    /// </summary>
    /// <returns>The theme list</returns>
    /// <exception cref="ServiceException">Throw a exception if the setting service is not initilised yet.</exception>
    public List<string> GetThemesList()
    {
        return _settingManager == null ? throw new ServiceException("Service not initilised yet!") : [.. _settingManager.Themes];
    }

    /// <summary>
    /// Saves configuration settings to a JSON file in the application data folder.
    /// </summary>
    /// <param name="keys">A dictionary containing configuration keys and their corresponding values.</param>
    public void SaveConfig(Dictionary<string, string> keys)
    {
        var resx = new RessourcesManager();
        var config = new Setting(
            keys["LocaleSelected"] ?? "English",
            keys["DefaultWindowsVersionInputBoxValue"] ?? "Windows NT",
            Convert.ToBoolean(keys["IsFluentUIEnable"]), 
            keys["ThemeSelected"] ?? "System",
            [SystemOptions.OperatingSystem]
        );

        var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);
        using var streamWriter = new StreamWriter(Path.Combine(resx.GetAppDataFolderPath(), "config.json"));
        streamWriter.WriteLine(configJson);
    }

    /// <summary>
    /// Loads user preferences from a configuration file located in the application data folder.
    /// </summary>
    /// <remarks>If the configuration file does not exist or an error occurs during loading, default settings
    /// are applied.</remarks>
    public void ObtainPreferencesFromDisk() 
    {
        var resxTemp = new RessourcesManager();
        var appDataPath = resxTemp.GetAppDataFolderPath();
        var configFilePath = Path.Combine(appDataPath, "config.json");
        Setting settingTemp = new DefaultSetting();

        try
        { 
            if (File.Exists(configFilePath)) 
            { 
                var content = File.ReadAllText(configFilePath); 
                settingTemp = JsonConvert.DeserializeObject<Setting>(content) ?? new DefaultSetting();
            } 
            _setting = settingTemp ?? new DefaultSetting(); 
        } 
        catch (Exception ex) 
        { 
            _logger.Log($"Error in ObtainPreferencesFromDisk: {ex.Message}. StackTrace: {ex.StackTrace}"); 
            _logger.Log($"Failed to load config file at '{configFilePath}'"); 
            _setting = new DefaultSetting();
        } 
    }

    /// <summary>
    /// Get the setting
    /// </summary>
    /// <returns>A Setting object</returns>
    /// <exception cref="InvalidOperationException">Throw an exception if the setting  sevice is not initislized yet</exception>
    public Setting GetSetting() {
        return _setting ?? throw new InvalidOperationException("Setting wasn't set yet");
    }

    /// <summary>
    /// Resets the application settings by clearing the contents of the configuration file.
    /// </summary>
    public void ResetSetting()
    {
        try
        {
            var resxTemp = new RessourcesManager();
            var appDataPath = resxTemp.GetAppDataFolderPath();
            var configFilePath = Path.Combine(appDataPath, "config.json");
            File.WriteAllText(configFilePath, string.Empty);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.Message); 
        }
    }
}
