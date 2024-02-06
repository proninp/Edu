package week1;

import java.util.Collections;
import java.util.List;

/**
 * Mini-Max Sum
 * *
 * Given five positive integers, find the minimum and maximum values that
 * can be calculated by summing exactly four of the five integers.
 * Then print the respective minimum and maximum values as a single
 * line of two space-separated long integers.
 * *
 * Example
 * arr = [1, 3, 5, 7, 9]
 * The minimum sum is 1 + 3 + 5 + 7 = 16 and the maximum sum is
 * 3 + 5 + 7 + 9 = 24. The function prints
 * 16 24
 * *
 * Function Description
 * Complete the miniMaxSum function in the editor below.
 * miniMaxSum has the following parameter(s):
 * arr: an array of  integers
 * *
 * Print
 * Print two space-separated integers on one line:
 * the minimum sum and the maximum sum of 4 of 5 elements.
 */
public class MiniMaxSum {
    public static void miniMaxSum(List<Integer> arr) {
        Collections.sort(arr);
        long min = 0, max = 0;
        min += arr.get(0);
        for (int i = 1; i < arr.size() - 1; i++) {
            min += arr.get(i);
            max += arr.get(i);
        }
        max += arr.get(arr.size() - 1);
        System.out.printf("%d %d", min, max);
    }
}
