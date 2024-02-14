package org.geeksforgeeks.medium;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Subarray with given sum
 * <p>
 * Given an unsorted array A of size N that contains only non-negative integers,
 * find a continuous sub-array that adds to a given number S and
 * return the left and right index(1-based indexing) of that subarray.
 * <p>
 * In case of multiple subarrays, return the subarray indexes which
 * come first on moving from left to right.
 * <p>
 * Note:- You have to return an ArrayList consisting of two elements left and right.
 * In case no such subarray exists return an array consisting of element -1.
 */

public class SubarrayWithGivenSum {
    static ArrayList<Integer> subarraySum(int[] arr, int n, int s) {
        int sum = 0, start = 0, end = 0;
        for (int i = 0; i < n; i++) {
            sum += arr[i];
            if (sum >= s) {
                end = i;

                while (sum > s && start < end) {
                    sum -= arr[start];
                    start++;
                }

                if (sum == s) {
                    return new ArrayList<>(Arrays.asList(start + 1, end + 1));
                }
            }
        }
        return new ArrayList<>(List.of(-1));
    }
}
