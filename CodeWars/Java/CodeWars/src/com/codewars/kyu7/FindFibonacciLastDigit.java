/*
 * As you probably know, Fibonacci sequence are the numbers in the following integer sequence:
 * 1, 1, 2, 3, 5, 8, 13... Write a method that takes the index as an argument and
 * returns last digit from fibonacci number. Example: getLastDigit(15) - 610.
 * Your method must return 0 because the last digit of 610 is 0.
 * Fibonacci sequence grows very fast and value can take very big numbers
 * (bigger than integer type can contain), so, please, be careful with overflow.
 */

package com.codewars.kyu7;

public class FindFibonacciLastDigit {
    public static int getFibNumb(int n) {
        if (n <= 1)
            return n;
        int prev = 0;
        int curr = 1;
        int sub;
        for (int i = 2; i <= n; i++) {
            sub = curr;
            curr = (curr + prev) % 10;
            prev = sub;
        }
        return curr;
    }
}
