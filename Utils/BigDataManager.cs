using System.Numerics;

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
