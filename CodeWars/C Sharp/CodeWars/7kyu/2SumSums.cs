using System.Collections.Generic;
using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * 2-Sum Sums
     * 
     * 2-Sum is a common task to find the pair of integers in the array such that their sum equals to the target.
     * array = [1,2,3,4,5]
     * target = 7
     * Pair is (2, 5)
     * 
     * Task
     * There is an array of unique integers.
     * The task is to find the sum of all targets in the specific range [from, to),
     * which has a pair in the array, such that sum of the pair equals to the target.
     */
    public class _2SumSums
    {
        public int SumOfTwoSumTargets(int[] numbers, int min, int max)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    var n = numbers[i] + numbers[j];
                    if (n >= min && n < max) set.Add(n);
                }
            }
            return set.Sum();
        }
    }
}
