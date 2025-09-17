/*
 * Create function fib that returns n'th element of Fibonacci sequence (classic programming task).
 */

package main.java.com.codewars.kyu7;

public class Fibonacci {
    public static long Fib(int n)
    {
        long a = 0, b = 1;
        if (n == 0)
            return a;
        if (n < 3)
            return b;
        for (int i = 2; i <= n; i++) {
            b = a + b;
            a = b - a;
        }
        return b;
    }
    public static long FibRecursion(int n) {
        if (n <= 1)
            return n;
        return (FibRecursion(n - 1) + FibRecursion(n - 2));
    }
}
