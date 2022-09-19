package com.leetcode.problems.Climbing_Stairs;

import java.util.HashMap;

/** You are climbing a staircase. It takes n steps to reach the top.
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
 */
public class Climbing_Stairs {
    static HashMap<Integer, Integer> resultHash = new HashMap<>();
    public static int climbStairs(int n) {
        if (resultHash.containsKey(n))
            return resultHash.get(n);
        if( (n == 2) || (n == 1))
            return n; // 2 / 1 + 1 steps
        int res = climbStairs(n - 1) + climbStairs(n - 2);
        resultHash.put(n, res);
        return res;
    }
    public static int climbStairs2(int n) {
        if( (n == 2) || (n == 1))
            return n;
        int[] a = new int[n];
        a[0] = 1;
        a[1] = 2;
        for (int i = 2; i < n; i++) {
            a[i] = a[i - 2] + a[i - 1];
        }
        return a[n-1];
    }
}
