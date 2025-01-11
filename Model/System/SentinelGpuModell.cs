using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Model.System
{
    /// <summary>
    /// The first gpu (that doesnt exist) to put in a list, it isnt used in other scenario than that 
    /// </summary>
    internal class SentinelGpuModel : GpuModel
    {
        private const int SentinelIterator = -1;
        private const string SentienlString = "Sentinel";
        internal SentinelGpuModel() : base(SentinelIterator, SentienlString)
        {

        }
    }
}
