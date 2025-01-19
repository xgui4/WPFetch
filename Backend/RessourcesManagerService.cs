using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Utils;

namespace WPFetch.Backend
{
    public class RessourcesManagerService : IService
    {
        private readonly RessourcesManager resx; 

        public RessourcesManagerService()
        {
            resx = new RessourcesManager();
        }

        public void Start()
        {
            resx.CreateAppDataFolder();
        }

        public string GetImagesPath(string imageName)
        {
            return resx.GetImagesPath(imageName);
        }

        public string GetAppDataPath()
        {
            return resx.GetAppDataFolderPath();
        }
    }
}
