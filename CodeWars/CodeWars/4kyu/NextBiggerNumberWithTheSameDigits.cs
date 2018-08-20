using System;
using System.Linq;

namespace CodeWars._4kyu
{
    /*
     * You have to create a function that takes a positive integer number and returns the next bigger number formed by the same digits:
     * Kata.NextBiggerNumber(12)==21
     * Kata.NextBiggerNumber(513)==531
     * Kata.NextBiggerNumber(2017)==2071
     * If no bigger number can be composed using those digits, return -1:
     * 
     * Kata.NextBiggerNumber(9)==-1
     * Kata.NextBiggerNumber(111)==-1
     * Kata.NextBiggerNumber(531)==-1
     */
    class NextBiggerNumberWithTheSameDigits
    {
        public static long NextBiggerNumber(long n)
        {
            int[] a = n.ToString().ToList().Select(c => c - 48).ToArray();
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");

            bool exit = true;
            for (int i = 0; i < a.Length - 1; i++)
                if (a[i] < a[i + 1]) { exit = false; break; }
            if (exit) return -1;
            while (true)
            {
                n++;
                Array.Copy(a, b, a.Length);
                string sn = n.ToString();
                int i = sn.Length - 1;
                for (; i >= 0; i--)
                {
                    if (!b.Contains(sn[i] - 48)) break;
                    b[Array.IndexOf(a, sn[i] - 48)] = -1;
                }
                if (i < 0) break;
            }
            return n;
        }
    }
}
