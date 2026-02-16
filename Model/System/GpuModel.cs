using WPFetch.Utils;

namespace WPFetch.Model.System
{
    public class GpuModel
    {
        private readonly int _iterator = 0;

        public GpuModel(GpuModel prevGpu, string name, string? imagePath = null)
        {
            _iterator = prevGpu._iterator + 1;
            Name = name;
            Label = $"GPU {_iterator}";
            Image = new RessourcesManager().GetImagesPath("gpu.png");
        }

        public GpuModel(string name)
        {
            _iterator = 0;
            Name = name;
            Label = $"GPU {_iterator}";
            Image = new RessourcesManager().GetImagesPath("gpu.png");
        }

        /// <summary>
        /// Seulement pour les classes abstraites
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="label"></param>
        internal protected GpuModel(int iterator, string label, string? imagePath = null)
        {
            _iterator = iterator;
            Label = label;
            Image = new RessourcesManager().GetImagesPath("gpu.png");
        }

        public string? Label { get; set; } = "GPU";
        public string? Image { get; set; } = new RessourcesManager().GetImagesPath("gpu.png"); 
        public string? Name { get; set; } = "Unknown GPU";
    }
}
