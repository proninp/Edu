using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeWars._6kyu
{
    /*
     * Consider the following operation:
     * We take a positive integer n and replace it with the sum of its prime factors
     * (if a prime number is presented multiple times in the factorization of n,
     * then it's counted the same number of times in the sum).
     * This operation is applied sequentially first to the given number, then to the first result,
     * then to the second result and so on.., until the result remains the same.
     * Given number n, find the final result of the operation.
     * Example
     * For n = 24, the output should be 5.
     * 24 -> (2 + 2 + 2 + 3) = 9 -> (3 + 3) = 6 -> (2 + 3) = 5 -> 5. So the answer for n = 24 is 5.
     */
    internal class SimpleFun_115_FacrotSum
    {
        static List<int> primes = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
        public static int FactorSum(int n)
        {
            return primes[n];
        }
        public static int FindPrimeFactor(int n)
        {
            for (int i = 0; i < primes.Count; i++)
            {
                if (n % primes[i] == 0)
                    return n;
            }
            return n;
        }

        public static int FindNextPrime(int from)
        {
            while (true)
            {
                from++;
                bool IsPrime = true;
                for (int i = 2; i < Math.Sqrt(from); i++)
                {
                    if (from % i == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }
                if (IsPrime)
                    return from;
            }
        }

    }
}
