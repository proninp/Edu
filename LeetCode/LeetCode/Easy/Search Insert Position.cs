using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 35. Search Insert Position
     * Given a sorted array of distinct integers and a target value, return the index if the target is found.
     * If not, return the index where it would be if it were inserted in order.
     * You must write an algorithm with O(log n) runtime complexity.
     * 
     * Example 1:
     * Input: nums = [1,3,5,6], target = 5
     * Output: 2
     * 
     * Example 2:
     * Input: nums = [1,3,5,6], target = 2
     * Output: 1
     */
    public class Search_Insert_Position
    {
        public static int SearchInsert(int[] nums, int target)
        {
            int size = nums.Length;
            if (size == 0)
                return 0;
            if (size == 1)
                return (nums[0] >= target ? 0 : 1);
            if (target < nums[0])
                return 0;
            if (target > nums[size - 1])
                return size;
            int left = -1;
            int right = size - 1;
            while(right > left + 1)
            {
                int middle = (left + right) / 2;
                if (nums[middle] >= target)
                    right = middle;
                else
                    left = middle; 
            }
            return (nums[right] >= target ? right : right + 1);
        }
    }
}
