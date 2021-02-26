using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Write a function that takes an array of numbers (integers for the tests) and a target number.
     * It should find two different items in the array that, when added together, give the target value.
     * The indices of these items should then be returned in an array like so: [index1, index2].

        For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.
        The input will always be valid (numbers will be an array of length 2 or greater, and all of the items
        will be numbers; target will always be the sum of two different items from that array).
     */
    class TwoSum
    {
        public static int[] TwoSumM(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers[i] + numbers[j] == target)
                        return new int[] { i, j };
            return new int[0];
        }
        //public static int[] TwoSum(int[] numbers, int target) => numbers.Select((x,i)=>new [] {i, Array.IndexOf(numbers,target-x,i+1)}).First(x => x[1] != -1);
    }
}
