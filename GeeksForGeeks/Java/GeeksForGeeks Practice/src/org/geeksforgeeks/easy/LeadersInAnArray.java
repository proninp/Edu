package org.geeksforgeeks.easy;
import java.util.ArrayList;

/**
 * Leaders in an array
 * <p>
 * Given an array A of positive integers. Your task is to find the leaders in the array. An
 * element of array is a leader if it is greater than or equal to all the elements to its right side.
 * The rightmost element is always a leader.
 */
public class LeadersInAnArray {
    static ArrayList<Integer> leaders(int arr[], int n) {
        ArrayList<Integer> list = new ArrayList<>();
        list.add(arr[arr.length - 1]);
        int max = arr[arr.length - 1];
        for(int i = arr.length - 2; i >= 0; i--) {
            if (arr[i] >= max) {
                list.add(0, arr[i]);
                max = arr[i];
            }
        }
        return list;
    }
}
