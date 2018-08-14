using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    class SumOfTheFirstNthTermOfSeries
    {
        /*
         * Your task is to write a function which returns the sum of following series upto nth term(parameter).
         * Series: 1 + 1/4 + 1/7 + 1/10 + 1/13 + 1/16 +...
         * Rules:
         * You need to round the answer to 2 decimal places and return it as String.
         * If the given value is 0 then it should return 0.00
         * You will only be given Natural Numbers as arguments.
         * Examples:
         * SeriesSum(1) => 1 = "1.00"
         * SeriesSum(2) => 1 + 1/4 = "1.25"
         * SeriesSum(5) => 1 + 1/4 + 1/7 + 1/10 + 1/13 = "1.57"
         * NOTE: In PHP the function is called series_sum().
         */
        public static string SeriesSum(int n)
        {
            return (n == 0) ? "0.00" : String.Format("{0:0.00}", Math.Round((1 + Enumerable.Range(1, n - 1).Sum(e => (decimal)1 / (e * 3 + 1))), 2));
        }
    }
}
