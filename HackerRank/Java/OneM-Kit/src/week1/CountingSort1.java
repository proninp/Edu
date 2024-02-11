package week1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

/**
 * Comparison Sorting
 * Quicksort usually has a running time of n x log(n), but is there an algorithm that
 * can sort even faster? In general, this is not possible. Most sorting algorithms are
 * comparison sorts, i.e. they sort a list just by comparing the elements to one
 * another. A comparison sort algorithm cannot beat n x log(n) (worst-case)
 * running time, since n x log(n) represents the minimum number of comparisons
 * needed to know where to place each element.
 *
 * Alternative Sorting
 * Another sorting method, the counting sort, does not require comparison. Instead,
 * you create an integer array whose index range covers the entire range of values in
 * your array to sort. Each time a value occurs in the original array, you increment the
 * counter at that index. At the end, run through your counting array, printing the
 * value of each non-zero valued index that number of times.
 *
 * Challenge
 * Given a list of integers, count and return the number of times each value appears
 * as an array of integers.
 *
 * Function Description
 * Complete the CountingSort function in the editor below.
 * CountingSort has the following parameter(s):
 *  arr[n]: an array of integers
 *
 * Returns
 *  int[100]: a frequency array
 */

public class CountingSort1 {
    public static List<Integer> countingSort(List<Integer> arr) {
        ArrayList<Integer> result = new ArrayList<>(Arrays.asList(new Integer[100]));
        Collections.fill(result, 0);
        for (int e : arr)
            result.set(e, result.get(e) + 1);
        return result;

    }
}
