package org.geeksforgeeks.easy;
import java.util.Arrays;

/**
 * Equilibrium Point
 * <p>
 * Given an array A of n non negative numbers. The task is to find the first equilibrium point in an array.
 * Equilibrium point in an array is an index (or position)
 * such that the sum of all elements before that index is same as sum of elements after it.
 * Note: Return equilibrium point in 1-based indexing. Return -1 if no such point exists.
 */
public class EquilibriumPoint {
    public static int equilibriumPoint(long arr[], int n) {
        if (n == 1)
            return  1;
        long left = 0, right = Arrays.stream(arr).sum();
        for (int i = 0; i < n; i++) {
            right -= arr[i];
            if (left == right)
                return i + 1;
            left += arr[i];
        }
        return -1;
    }
}
