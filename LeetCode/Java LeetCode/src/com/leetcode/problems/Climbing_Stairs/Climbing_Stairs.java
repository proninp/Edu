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
        if (n == 2)
            return 2; // 2 / 1 + 1 steps
        if (n == 1)
            return 1;
        int res = climbStairs(n - 1) + climbStairs(n - 2);
        resultHash.put(n, res);
        return res;
    }
}
