using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._8kyu
{
    /*
     * You get an array of numbers, return the sum of all of the positives ones.
     * Example [1,-4,7,12] => 1 + 7 + 12 = 20
     * Note: if there is nothing to sum, the sum is default to 0.
     */
    class SumOfPositive
    {
        public static int PositiveSum(int[] arr) => arr.Where(a => a > 0).Sum();
    }
}
