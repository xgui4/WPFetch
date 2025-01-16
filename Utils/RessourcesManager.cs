using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Utils
{
    internal class RessourcesManager
    {
        private readonly string RessourcesFolderPath; 
        private readonly string ImagesFolderPath;
        private readonly string AppDataFolderPath; 

        public RessourcesManager()
        {
            RessourcesFolderPath = Path.Combine(AppContext.BaseDirectory, "Ressources");
            ImagesFolderPath = Path.Combine(RessourcesFolderPath, "Images");
            AppDataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Xgui4 Studio", "WPFetch");

            if (Directory.Exists(AppDataFolderPath) == false)
            {
                Directory.CreateDirectory(AppDataFolderPath); 
            }
        }

        public string GetImagesPath(string filename)
        {
            return Path.Combine(ImagesFolderPath, filename);
        }

        public string GetAppDataFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
        }
    }
}
