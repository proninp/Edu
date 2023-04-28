using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 88. Merge Sorted Array
     * You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n,
     * representing the number of elements in nums1 and nums2 respectively.
     * 
     * Merge nums1 and nums2 into a single array sorted in non-decreasing order.
     * The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
     * To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged,
     * and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
     */
    public class MergeSortedArray
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] n1 = new int[m];
            Array.Copy(nums1, n1, m);
            int p1 = 0;
            int p2 = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (p1 >= m)
                    nums1[i] = nums2[p2++];
                else if (p2 >= n)
                    nums1[i] = n1[p1++];
                else
                    nums1[i] = (n1[p1] <= nums2[p2]) ? n1[p1++] : nums2[p2++];
            }
        }
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = m; i < (m + n); i++)
                nums1[i] = nums2[i - m];
            Array.Sort(nums1);
        }
    }
}
