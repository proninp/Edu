using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Your task is to write function findSum.
     * Upto and including n, this function will return the sum of all multiples of 3 and 5.
     * For example:
     * findSum(5) should return 8 (3 + 5)
     * findSum(10) should return 33 (3 + 5 + 6 + 9 + 10)
     */
    public class SumOfAllTheMultiplesOf3Or5
    {
        public static int FindSum(int n) => Enumerable.Range(0, n + 1).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
    }
}
