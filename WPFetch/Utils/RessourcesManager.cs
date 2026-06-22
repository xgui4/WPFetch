using System.IO;

namespace WPFetch.Utils;

internal class RessourcesManager
{
    private readonly string _ressourcesFolderPath; 
    private readonly string _imagesFolderPath;
    private readonly string _appDataFolderPath; 

    public RessourcesManager()
    {
        _ressourcesFolderPath = Path.Combine(AppContext.BaseDirectory, "Assets");
        _imagesFolderPath = Path.Combine(_ressourcesFolderPath, "Images");
        _appDataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Xgui4", "WPFetch");
    }

    public void CreateAppDataFolder()
    {
        if (Directory.Exists(_appDataFolderPath) == false)
        {
            Directory.CreateDirectory(_appDataFolderPath);
        }
    }

    public string GetImagesPath(string filename, string type)
    {
        return Path.Combine(_imagesFolderPath, type, filename);
    }

    public string GetAppDataFolderPath()
    {
        return _appDataFolderPath; 
    }
}
