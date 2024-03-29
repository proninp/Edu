package org.geeksforgeeks.easy;

/**
 * Missing number in array
 *<p>
 * Given an array of size N-1 such that it only contains distinct integers
 * in the range of 1 to N. Find the missing element.
 * <p>
 * Example 1:
 * <p>
 * Input:
 * N = 5
 * A[] = {1,2,3,5}
 * Output: 4
 */

public class MissingNumberInArray {
    int missingNumber(int array[], int n) {
        int triangleSum = (n * (n + 1)) / 2;
        for (int i = 0; i < n - 1; i++) {
            triangleSum -= array[i];
        }
        return triangleSum;
    }
}
