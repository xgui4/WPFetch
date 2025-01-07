using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Utils
{
    internal class JsonManager
    {
        public static string FilterJson(string jsonString, string property, string defaultOutput)
        {
            try
            {
                var tempStr = jsonString.Replace(@"\\", @"\").Replace(@"//", @"/");
                jsonString = tempStr.Replace(@"\", @"\\").Replace(@"/", @"//");
                JObject jsonObj = JObject.Parse(jsonString);
                return jsonObj[property]?.ToString() ?? defaultOutput;
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(jsonString);
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
                return "Error while fetching";
            }
        }
    }
}
