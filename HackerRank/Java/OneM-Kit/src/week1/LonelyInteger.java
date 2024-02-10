package week1;

import java.util.List;

/**
 * Lonely Integer
 *
 * Given an array of integers, where all elements but one occur twice, find the unique element.
 *
 * Example
 * a = [1, 2, 3, 4, 3, 2, 1]
 * The unique element is 4.
 *
 * Function Description
 * Complete the Lonelyinteger function in the editor below.
 * Lonelyinteger has the following parameter(s):
 *  int a[n]: an array of integers
 * Returns
 *  int: the element that occurs only once
 */

public class LonelyInteger {
    public static int lonelyinteger(List<Integer> a) {
        int result = 0;
        for(int e : a)
            result ^= e;
        return result;
    }
}
