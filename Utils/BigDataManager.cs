using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WPFetch.Utils
{
    public class BigDataManager
    {
        public readonly BigInteger Gigaoctect = 1073741824;

        public int BitStringToGigInt(string bigDataStr)
        {
            try
            {
                BigInteger bigInteger = BigInteger.Parse(bigDataStr);
                return (int)(bigInteger / Gigaoctect);
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }

            }
        }
    }
}
