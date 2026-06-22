using WPFetch.Utils;

namespace WPFetch.Model.System;

/// <summary>
/// This model Represent an GPU
/// </summary>
public class GpuModel
{
    private readonly int _iterator = 0;

    /// <summary>
    /// Initisiale a GPU Model
    /// </summary>
    /// <param name="prevGpu">The previous gpu</param>
    /// <param name="name">the gpu name</param>
    /// <param name="imagePath">the image path</param>
    public GpuModel(GpuModel prevGpu, string name, string? imagePath = null)
    {
        _iterator = prevGpu._iterator + 1;
        Name = name;
        Label = $"GPU {_iterator}";
        Image = new RessourcesManager().GetImagesPath("gpu.png", "icons");
    }

    /// <summary>
    /// Initisiale a GPU Model
    /// </summary>
    /// <param name="name">The GPU name</param>
    public GpuModel(string name)
    {
        _iterator = 0;
        Name = name;
        Label = $"GPU {_iterator}";
        Image = new RessourcesManager().GetImagesPath("gpu.png", "icons");
    }

    /// <summary>
    /// Seulement pour les classes abstraites
    /// </summary>
    /// <param name="iterator"></param>
    /// <param name="label"></param>
    /// <param name="imagePath"></param>
    protected internal GpuModel(int iterator, string label, string? imagePath = null)
    {
        _iterator = iterator;
        Label = label;
        Image = new RessourcesManager().GetImagesPath("gpu.png", "icons");
    }

    /// <summary>
    /// The GPU Model label
    /// </summary>
    public string? Label { get; set; } = "GPU";

    /// <summary>
    /// The image path
    /// </summary>
    public string? Image { get; set; } = new RessourcesManager().GetImagesPath("gpu.png", "icons"); 
    
    /// <summary>
    /// The GPU Name
    /// </summary>
    public string? Name { get; set; } = "Unknown GPU";
}
