using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Model
{
    /// <summary>
    /// The first gpu (that doesnt exist) to put in a list, it isnt used in other scenario than that 
    /// </summary>
    internal class SentinelGpuModel : GpuModel
    {
        private readonly int _iterator = -1;

        internal SentinelGpuModel() :  base(null)
        {

        }
    }
}
