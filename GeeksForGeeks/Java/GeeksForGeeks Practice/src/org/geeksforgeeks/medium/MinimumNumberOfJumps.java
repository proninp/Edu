package org.geeksforgeeks.medium;

/**
 * Minimum number of jumps
 * <p>
 * Given an array of N integers arr[] where each element represents the maximum length
 * of the jump that can be made forward from that element. This means if arr[i] = x,
 * then we can jump any distance y such that y ≤ x.
 * Find the minimum number of jumps to reach the end of the array (starting from the first element).
 * If an element is 0, then you cannot move through that element.
 * <p>
 * Note: Return -1 if you can't reach the end of the array.
 */
public class MinimumNumberOfJumps {
    static int minJumps(int[] arr) {
        int len = arr.length;
        if(len == 1)
            return 0;
        int jumps = 0, mxInd = 0, max = 0;
        for(int i = 0; i < len; i++) {
            max = Math.max(max, arr[i] + i);
            if (i == mxInd) {
                jumps++;
                mxInd = max;

                if (mxInd >= len - 1)
                    return jumps;
            }
        }
        return -1;
    }
}
