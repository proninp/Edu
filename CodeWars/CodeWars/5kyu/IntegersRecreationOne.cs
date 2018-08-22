using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    /*
     * Integers: Recreation One
     * Divisors of 42 are : 1, 2, 3, 6, 7, 14, 21, 42. These divisors squared are: 1, 4, 9, 36, 49, 196, 441, 1764.
     * The sum of the squared divisors is 2500 which is 50 * 50, a square!
     * Given two integers m, n (1 <= m <= n) we want to find all integers between m and n whose sum of squared divisors is itself a square. 42 is such a number.
     * The result will be an array of arrays or of tuples (in C an array of Pair) or a string, each subarray having two elements,
     * first the number whose squared divisors is a square and then the sum of the squared divisors.
     * #Examples:
     * list_squared(1, 250) --> [[1, 1], [42, 2500], [246, 84100]]
     * list_squared(42, 250) --> [[42, 2500], [246, 84100]]
     * The form of the examples may change according to the language, see Example Tests: for more details.
     */
    public class IntegersRecreationOne
    {
        public static string ListSquared(long m, long n)
        {
            StringBuilder sb = new StringBuilder("[");
            for (long i = m; i <= n; i++)
            {
                long len = (long) Math.Sqrt(i) + 1;
                long sqrSum = 0;
                for (long j = 1; j < len; j++)
                    if (i % j == 0) sqrSum += j * j + (j * j == i ? 0 : (i / j) * (i / j));
                long k = 1;
                while (true)
                {
                    long sqr = k * k;
                    if (sqr > sqrSum) break;
                    else if (sqr < sqrSum) k++;
                    else { sb.Append(string.Format("[{0}, {1}], ", i, sqr)); break; }
                }
            }
            if (sb.Length > 1 &&  sb.ToString().Substring(sb.Length - 2).Equals(", ")) sb.Remove(sb.Length - 2, 2);
            return sb.Append("]").ToString();
        }
    }
}
