package org.geeksforgeeks.easy;

import java.util.ArrayList;

/**
 * Find duplicates in an array
 * <p>
 * Given an array a of size N which contains elements from 0 to N-1,
 * you need to find all the elements occurring more than once in the given array.
 * Return the answer in ascending order. If no such element is found, return list containing [-1].
 * Note: The extra space is only for the array to be returned.
 * Try and perform all operations within the provided array.
 */
public class FindDuplicatesInAnArray {
    public static ArrayList<Integer> duplicates(int arr[], int n) {
        ArrayList<Integer> list = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            int index = arr[i] % n;
            arr[index] += n;
        }
        for (int i = 0; i < n; i++) {
            arr[i] /= n;
            if (arr[i] > 1)
                list.add(i);
        }
        if (list.isEmpty())
            list.add(-1);
        return list;
    }
    public static ArrayList<Integer> duplicates2(int arr[], int n) {
        int[] freqArr = new int[n];
        ArrayList<Integer> list = new ArrayList<>();
        for(int i = 0; i < n; i++) {
            freqArr[arr[i]]++;
        }
        for(int i = 0; i < n; i++)
            if (freqArr[i] > 1)
                list.add(i);
        if (list.isEmpty())
            list.add(-1);
        return list;
    }
}
