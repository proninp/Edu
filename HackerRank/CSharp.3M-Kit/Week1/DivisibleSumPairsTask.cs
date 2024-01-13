using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1;

/*
 * Divisible Sum Pairs
 * 
 * Given an array of integers and a positive integer k, determine the number of
 * (i, j) pairs where i < j and ar[i] + ar[j] is divisible by l.
 * 
 * Example
 * ar = [1, 2, 3, 4, 5, 6]
 * k = 5
 * Three pairs meet the criteria: [1, 4], [2, 3] and [4, 6].
 * 
 * Function Description
 * Complete the divisibleSumPairs function in the editor below.
 * divisibleSumPairs has the following parameter(s):
 * int n: the length of array 
 * int ar[n]: an array of integers
 * int k: the integer divisor
 * 
 * Returns
 * - int: the number of pairs
 */

internal class DivisibleSumPairsTask
{
    public static int DivisibleSumPairs(int n, int k, List<int> ar)
    {
        int count = 0;
        var remainderCounts = new Dictionary<int, int>();
        foreach (var num in ar)
        {
            int remainder = num % k;
            int complement = (k - remainder) % k;
            count += remainderCounts.GetValueOrDefault(complement, 0);
            remainderCounts[remainder] = remainderCounts.GetValueOrDefault(remainder, 0) + 1;
        }
        return count;
    }
}
