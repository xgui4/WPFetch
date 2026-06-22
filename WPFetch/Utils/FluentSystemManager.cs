using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core;

namespace WPFetch.Utils;

/// <summary>
/// The Fluent System Info Manager (FluentSysInfo Nuget Package) manager
/// </summary>
public static class FluentSystemManager
{
    /// <summary>
    /// Get the hardware info.
    /// </summary>
    /// <param name="fluentSysInfoType">the flunt sys info type</param>
    /// <param name="outputType">the output type</param>
    /// <returns></returns>
    public static string GetHardwareInfo(FluentSysInfoTypes fluentSysInfoType, string outputType)
    {
        string temp = new FluentSysInfoCore().GetSystemInfo(fluentSysInfoType);
        return JsonManager.FilterJson(temp, outputType, $" Unknow {fluentSysInfoType}");
    }
}
