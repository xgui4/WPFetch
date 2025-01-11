using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Model.System
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

        /// <summary>
        /// Seulement pour les classes abstraites
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="label"></param>
        protected GpuModel(int iterator, string label)
        {
            _iterator = iterator;
            Label = label;
        }

        public string? Label { get; set; } = "GPU";

        public string? Name { get; set; } = "Unknow GPU";
    }
}
