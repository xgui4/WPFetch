using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

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
