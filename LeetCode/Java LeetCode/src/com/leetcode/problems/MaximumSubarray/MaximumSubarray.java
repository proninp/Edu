package com.leetcode.problems.MaximumSubarray;

public class MaximumSubarray {
    public static int maxSubArray(int[] nums) {
        int subMax = nums[0];
        int subSum = 0;
        for (int i = 0; i < nums.length; i++) {
            if (subSum < 0)
                subSum = 0;
            subSum += nums[i];
            if (subSum > subMax)
                subMax = subSum;
        }
        return subMax;
    }
}
