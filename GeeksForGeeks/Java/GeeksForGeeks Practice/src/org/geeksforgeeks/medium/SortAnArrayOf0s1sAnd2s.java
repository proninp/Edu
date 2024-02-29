package org.geeksforgeeks.medium;

/**
 * Sort an array of 0s, 1s and 2s
 * <p>
 * Given an array of size N containing only 0s, 1s, and 2s; sort the array in ascending order.
 */
public class SortAnArrayOf0s1sAnd2s {
    public static void sort012(int a[], int n)
    {
        int[] arr = new int[3];
        for(int i = 0; i < a.length; i++) {
            arr[a[i]]++;
        }
        int val = 0;
        for(int i = 0; i < a.length; i++) {
            while(arr[val] == 0)
                val++;
            arr[val]--;
            a[i] = val;
        }
    }
}
