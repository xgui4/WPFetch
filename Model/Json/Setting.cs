using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFetch.Model.Enums;
using WPFetch.Model.System;

namespace WPFetch.Model.Json
{
    [JsonObject("Setting")]
    public record Setting
    {
        [JsonProperty(nameof(LocaleSelected))]
        public required Locales LocaleSelected { get; set; }

        [JsonProperty(nameof(DefaultWindowsVersions))]
        public required string DefaultWindowsVersions { get; set; }

        [JsonProperty(nameof(IsFluentUIEnabled))]
        public required bool IsFluentUIEnabled { get; set; }

        [JsonProperty(nameof(Theme))]
        public required string Theme { get; set; }

        [JsonProperty(nameof(HardwaresToFetch))]
        public required HardwaresModels[] HardwaresToFetch { get; set; }
    }
}
