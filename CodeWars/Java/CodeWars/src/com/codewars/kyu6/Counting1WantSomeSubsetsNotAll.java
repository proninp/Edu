/*
 * We have a set of consecutive numbers from 1 to n.
 * We want to count all the subsets that do not contain consecutive numbers. E.g.
 * If our set S1 is equal to [1,2,3,4,5] The subsets that fulfill these property are:
 * [1],[2],[3],[4],[5],[1,3],[1,4],[1,5],[2,4],[2,5],[3,5],[1,3,5]
 * A total of 12 subsets.
 * From the set S2 equals to[1,2,3], it is obvious that we have only 4 subsets and are:
 * [1],[2],[3],[1,3]
 * Make a code that may give the amount of all these subsets for any integer n >= 2.
 *
 */

package com.codewars.kyu6;

import java.math.BigInteger;

public class Counting1WantSomeSubsetsNotAll {
    public static BigInteger F(int n) {
        if (n <= 1)
            return BigInteger.valueOf(n);
        BigInteger current = BigInteger.valueOf(1);
        BigInteger prev = BigInteger.valueOf(0);
        BigInteger sub;
        for (int i = 2; i <= n + 2; i++) {
            sub = current;
            current = current.add(prev);
            prev = sub;
        }
        return current.subtract(BigInteger.valueOf(1));
    }
}
