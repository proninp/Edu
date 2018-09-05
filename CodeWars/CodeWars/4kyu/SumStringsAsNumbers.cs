using System.Numerics;

namespace CodeWars._4kyu
{
    /*
     * Sum Strings as Numbers
     * Given the string representations of two integers, return the string representation of the sum of those integers.
     * For example:
     * sumStrings('1','2') // => '3'
     * A string representation of an integer will contain no characters besides the ten numerals "0" to "9".
     */
    public class SumStringsAsNumbers
    {
        public static string SumStrings(string a, string b) => 
            (BigInteger.Parse(a.Length != 0 ? a : "0") + BigInteger.Parse(b.Length != 0 ? b : "0")).ToString();
    }
}
