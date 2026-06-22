using WPFetch.Utils;

namespace WPFetch.Services;

/// <summary>
/// The Ressources Managers Service that know and give locations to needed ressources
/// </summary>
public class RessourcesManagerService
{
    private readonly RessourcesManager _resx; 

    /// <summary>
    /// Initializes a new instance of the RessourcesManagerService class.
    /// </summary>
    public RessourcesManagerService()
    {
        _resx = new RessourcesManager();
    }

    /// <summary>
    ///  Start the services by creating the app data foleder
    /// </summary>
    public void Start()
    {
        _resx.CreateAppDataFolder();
    }

    /// <summary>
    /// Get the asset path of the desired assets names
    /// </summary>
    /// <param name="assetName">The asset file name</param>
    /// <param name="assetType">The assets type</param>
    /// <returns></returns>
    public string GeAssetsFilePath(string assetName, string assetType)
    {
        return _resx.GetImagesPath(assetName, assetType);
    }

    /// <summary>
    /// Get the app data path
    /// </summary>
    /// <returns></returns>
    public string GetAppDataPath()
    {
        return _resx.GetAppDataFolderPath();
    }
}
