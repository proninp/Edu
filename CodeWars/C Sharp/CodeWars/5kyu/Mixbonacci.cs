using System;
using System.Collections.Generic;
using System.Numerics;

namespace CodeWars._5kyu
{
    /*
     * This is the first of my "-nacci" series. If you like this kata, check out the zozonacci sequence too.
     * Task
     * Mix -nacci sequences using a given pattern p.
     * Return the first n elements of the mixed sequence.
     * Rules
     * The pattern p is given as a list of strings (or array of symbols in Ruby) using the pattern mapping below
     * (e. g. ['fib', 'pad', 'pel'] means take the next fibonacci, then the next padovan, then the next pell number and so on).
     * When n is 0 or p is empty return an empty list.
     * If the length of p is more than n repeat the pattern.
     * Examples
                   0  1  2  3  4  
        ----------+------------------
        fibonacci:| 0, 1, 1, 2, 3 ...
        padovan:  | 1, 0, 0, 1, 0 ...
        pell:     | 0, 1, 2, 5, 12 ...
     * pattern = ['fib', 'pad', 'pel']
     * n = 6
     * #          ['fib',        'pad',      'pel',   'fib',        'pad',      'pel']
     * # result = [fibonacci(0), padovan(0), pell(0), fibonacci(1), padovan(1), pell(1)]
     * result = [0, 1, 0, 1, 0, 1]
     * pattern = ['fib', 'fib', 'pel']
     * n = 6
     * #          ['fib', 'fib', 'pel', 'fib', 'fib', 'pel']
     * # result = [fibonacci(0), fibonacci(1), pell(0), fibonacci(2), fibonacci(3), pell(1)]
     * result = [0, 1, 0, 1, 2, 1]
     * 
     * Sequences
     * fibonacci : 0, 1, 1, 2, 3 ...
     * padovan: 1, 0, 0, 1, 0 ...
     * jacobsthal: 0, 1, 1, 3, 5 ...
     * pell: 0, 1, 2, 5, 12 ...
     * tribonacci: 0, 0, 1, 1, 2 ...
     * tetranacci: 0, 0, 0, 1, 1 ...
     * Pattern mapping
     * 'fib' -> fibonacci
     * 'pad' -> padovan
     * 'jac' -> jacobstahl
     * 'pel' -> pell
     * 'tri' -> tribonacci
     * 'tet' -> tetranacci
     */
    public class MixbonacciCW
    {
        public static BigInteger[] Mixbonacci(string[] pattern, int length)
        {
            if (length == 0 || pattern.Length == 0) return new BigInteger[] { };
            Dictionary<string, int> seq = new Dictionary<string, int> { { "fib", 0 }, { "pad", 0 }, { "jac", 0 }, { "pel", 0 }, { "tri", 0 }, { "tet", 0 } };
            int len = pattern.Length > length ? pattern.Length * 2 : length;
            BigInteger[] a = new BigInteger[len];
            int i = 0;
            int j = 0;
            while (len-- > 0)
            {
                if (i >= pattern.Length) i = 0;
                switch (pattern[i])
                {
                    case "fib":
                        a[j] = Fibonacci(seq[pattern[i]]++);
                        break;
                    case "pad":
                        a[j] = Padovan(seq[pattern[i]]++);
                        break;
                    case "jac":
                        a[j] = Jacobsthal(seq[pattern[i]]++);
                        break;
                    case "pel":
                        a[j] = Pell(seq[pattern[i]]++);
                        break;
                    case "tri":
                        a[j] = Tribonacci(seq[pattern[i]]++);
                        break;
                    case "tet":
                        a[j] = Tetranacci(seq[pattern[i]]++);
                        break;
                }
                Console.WriteLine(a[j]);
                i++;
                j++;
            }
            return a;
        }
        public static BigInteger Fibonacci(BigInteger n)
        {
            BigInteger a = 0, result = 1;
            for (BigInteger i = 2; i <= n; i++)
            {
                result += a;
                a = result - a;
            }
            return n != 0 ? result : a;
        }
        public static BigInteger Padovan(BigInteger n)
        {
            BigInteger a = 1, b = 0, c = 0, result = 0;
            for (BigInteger i = 3; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = c;
                c = result;
            }
            return n != 0 ? result : a;
        }
        public static BigInteger Jacobsthal(BigInteger n)
        {
            BigInteger a = 0, b = 1, result = 1;
            for (BigInteger i = 2; i <= n; i++)
            {
                result = b + 2 * a;
                a = b;
                b = result;
            }
            return n != 0 ? result : a;
        }
        public static BigInteger Pell(BigInteger n)
        {
            BigInteger a = 0, b = 1, result = 1;
            for (BigInteger i = 2; i <= n; i++)
            {
                result = 2 * b + a;
                a = b;
                b = result;
            }
            return n != 0 ? result : a;
        }
        public static BigInteger Tribonacci(BigInteger n)
        {
            BigInteger a = 0, b = 0, c = 1, result = 1;
            for (BigInteger i = 3; i <= n; i++)
            {
                result = c + b + a;
                a = b;
                b = c;
                c = result;
            }
            return n > 1 ? result : a;
        }
        public static BigInteger Tetranacci(BigInteger n)
        {
            BigInteger a = 0, b = 0, c = 0, d = 1, result = 1;
            for (BigInteger i = 4; i <= n; i++)
            {
                result = d + c + b + a;
                a = b;
                b = c;
                c = d;
                d = result;
            }
            return n > 2 ? result : a;
        }

    }
}
