using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    /*
     * You know what divisors of a number are. The divisors of a positive integer n are said to be proper when you consider
     * only the divisors other than n itself. In the following description, divisors will mean proper divisors.
     * For 100 they are 1, 2, 4, 5, 10, 20, 25, and 50.
     * Let s(n) be the sum of these proper divisors of n.
     * Call buddy two positive integers such that the sum of the proper divisors of each number is one more than the other number.
     * (n m) are a pair of buddy if s(m) = n + 1 and s(n) = m + 1.
     * Example
     * (48 75) is such a pair.  
     * Divisors of 48 are 1 2 3 4 6 8 12 16 24 -> sum = 76 ie 75 + 1  
     * Divisors of 75 are 1 3 5 15 25  -> sum = 49 ie 48 + 1
     * Task
     * given two positive integers start and limit the function buddy(start, limit) finds the first pair (n m)
     * of buddy pairs such that n (positive integer) is between start (inclusive) and limit (inclusive);
     * m can be greater than limit and has to be greater than n.
     * buddy(10, 50) returns "(48 75)"
     * buddy(48, 50) returns "(48 75)"
     * or
     * buddy(10, 50) returns [48, 75] 
     * buddy(48, 50) returns [48, 75]
     */
    class BuddyPairs
    {
        public static string Buddy(long start, long limit)
        {
            for (long i = start; i <= limit; i++)
            {
                int m = FindFactorsSum(i);
                if (m > i && FindFactorsSum(m) == i) return "("+ i + " " + m + ")" ;
            }
            return "Nothing";
        }
        public static int FindFactorsSum(long n)
        {
            int sum = 0;
            for (int i = 2; i <= Math.Pow(n, 0.5); i++)
                if (n % i == 0)
                {
                    sum += i;
                    if (i != n / i) sum += (int)(n / i);
                }
            return sum;
        }
    }
}
