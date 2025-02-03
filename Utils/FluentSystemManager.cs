using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core;

namespace WPFetch.Utils
{
    public static class FluentSystemManager
    {
        public static string GetHardwareInfo(FluentSysInfoTypes fluentSysInfoType, string outputType)
        {
            string temp = new FluentSysInfoCore().GetSystemInfo(fluentSysInfoType);
            return JsonManager.FilterJson(temp, outputType, $" Unknow {fluentSysInfoType}");
        }
    }
}
