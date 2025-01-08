using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WPFetch.Model
{
    public class CommandLineArguments
    {
        public List<string> Arguments { get; private set; }
        public CommandLineArguments(string [] args)
        {
            Arguments = args.ToList();
        }
    }
}
