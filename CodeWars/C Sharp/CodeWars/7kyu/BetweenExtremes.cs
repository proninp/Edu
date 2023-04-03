using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Between Extremes
     * 
     * Given an array of numbers, return the difference between the largest and smallest values.
     * For example:
     * [23, 3, 19, 21, 16] should return 20 (i.e., 23 - 3).
     * [1, 434, 555, 34, 112] should return 554 (i.e., 555 - 1).
     * The array will contain a minimum of two elements. Input data range guarantees that max-min will cause no integer overflow.
     * 
     */
    internal class BetweenExtremes
    {
        public static int BetweenExtremesFunc(int[] numbers) => (numbers.Max() - numbers.Min());
    }
}
