using System.Numerics;

namespace WPFetch.Utils;

/// <summary>
/// Managed big number of data.
/// </summary>
public class BigDataManager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly BigInteger Gigaoctect = 1073741824;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Convert Bits String to Go Int
    /// </summary>
    /// <param name="bigDataStr">The bits in string to convert to Go int</param>
    /// <returns>The convert Bits string to Go int</returns>
    public int BitStringToGoInt(string bigDataStr)
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
