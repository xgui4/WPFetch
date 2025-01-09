using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Model
{
    public class GpuModel
    {
        private readonly int _iterator = 0;

        public GpuModel(GpuModel prevGpu, string name)
        {
            _iterator = prevGpu._iterator + 1;
            Name = name;
            Label = $"GPU {_iterator}";
        }

        public GpuModel(string name) 
        {
            _iterator = 0;
            Name = name;
            Label = $"GPU {_iterator}"; 
        }

        public string Label { get; set; }

        public string Name { get; set; }
    }
}
