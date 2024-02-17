package org.geeksforgeeks.medium;

/**
 * Kadane's Algorithm
 * <p>
 * Given an array Arr[] of N integers.
 * Find the contiguous sub-array(containing at least one number)
 * which has the maximum sum and return its sum.
 */
public class KadanesAlgorithm {
    long maxSubarraySum(int arr[], int n){

        long localSum = 0;
        long maxSum = Integer.MIN_VALUE;
        for(int i = 0; i < arr.length; i++) {
            localSum += arr[i];
            if (maxSum < localSum)
                maxSum = localSum;
            if (localSum < 0)
                localSum = 0;
        }
        return maxSum;
    }
}
