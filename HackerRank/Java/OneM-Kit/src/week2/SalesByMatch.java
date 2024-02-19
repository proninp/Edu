package week2;

import java.util.HashMap;
import java.util.List;

/**
 * Sales by Match
 * <p>
 * There is a large pile of socks that must be paired by color. Given an array of integers representing the color of
 * each sock, determine how many pairs of socks with matching colors there are.
 * <p>
 * Function Description
 * Complete the SockMerchant function in the editor below.
 * SockMerchant has the following parameter(s):
 * int n: the number of socks in the pile
 * int ar[n]: the colors of each sock
 * Returns
 * int: the number of pairs
 */

public class SalesByMatch {
    public static int sockMerchant(int n, List<Integer> ar) {
        HashMap<Integer, Integer> map = new HashMap<>();
        int cnt = 0;
        for (int e : ar) {
            int val = map.getOrDefault(e, 0) + 1;
            map.put(e, val);
            cnt += val % 2 == 0 ? 1: 0;
        }
        return cnt;
    }
}