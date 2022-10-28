/*
 * Let us consider this example (array written in general format): ls = [0, 1, 3, 6, 10]
 * Its following parts:
 * ls = [0, 1, 3, 6, 10]
 * ls = [1, 3, 6, 10]
 * ls = [3, 6, 10]
 * ls = [6, 10]
 * ls = [10]
 * ls = []
 * The corresponding sums are (put together in a list): [20, 20, 19, 16, 10, 0]
 * The function parts_sums (or its variants in other languages) will take as parameter a list ls
 * and return a list of the sums of its parts as defined above.
 */

package com.codewars.kyu6;

public class SumOfParts {
    public static int[] sumParts(int[] ls) {
        int size = ls.length;
        int sum = 0;
        int[] res = new int[size + 1];
        while (--size >= 0) {
            sum += ls[size];
            res[size] = sum;
        }
        return res;
    }
}
