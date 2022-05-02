using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 26. Remove Duplicates from Sorted Array
     * 
     * Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once.
     * The relative order of the elements should be kept the same.
     * Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.
     * More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.
     * It does not matter what you leave beyond the first k elements.
     * Return k after placing the final result in the first k slots of nums.
     * Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
     */
    public class Remove_Duplicates_From_Sorted_Array
    {
        public static int RemoveDuplicates(int[] nums)
        {

            return RemoveDuplicatesFirstSolution(nums);
        }
        // Iterative solution
        public static int RemoveDuplicatesFirstSolution(int[] nums)
        {

            int size = nums.Length;
            int i = 0;
            int j = 0;
            while (++j < size)
            {
                if (nums[i] != nums[j])
                    nums[++i] = nums[j];
            }
            return ++i;
        }
        // Recoursive solution
        public static int RemoveDuplicatesSecondSolution(int[] nums)
        {

            int size = nums.Length;
            if (size == 1) return 1;
            int i = 0;
            return(RemoveDuplicatesHelper(ref i, 1, nums, size));
        }
        static int RemoveDuplicatesHelper(ref int i, int j, int[] a, int size)
        {
            if (j == size)
                return ++i;
            if (a[i] != a[j])
                a[++i] = a[j];
            return RemoveDuplicatesHelper(ref i, ++j, a, size);
        }
    }
}
