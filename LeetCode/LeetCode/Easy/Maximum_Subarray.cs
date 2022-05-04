using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 53. Maximum Subarray
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
     * A subarray is a contiguous part of an array.
     * 
     * Example 1:
     * Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
     * Output: 6
     * Explanation: [4,-1,2,1] has the largest sum = 6.
     * 
     * Example 2:
     * Input: nums = [1]
     * Output: 1
     * 
     * Example 3:
     * Input: nums = [5,4,-1,7,8]
     * Output: 23
     */
    public class Maximum_Subarray
    {
        public static int MaxSubArray(int[] nums)
        {
            int size = nums.Length;
            if (size == 1)
                return nums[0];
            int sum = int.MinValue;
            int currentSum = 0;
            for (int i = 0; i < size; i++)
            {
                currentSum += nums[i];
                if (sum < currentSum)
                    sum = currentSum;

                if (currentSum < 0)
                    currentSum = 0;
            }
            return sum;
        }
    }
}
