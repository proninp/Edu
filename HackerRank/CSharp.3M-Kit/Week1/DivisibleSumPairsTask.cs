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
        int pairs = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if ((ar[i] + ar[j]) % k == 0)
                    pairs++;
            }
        }
        return pairs;
    }
}
