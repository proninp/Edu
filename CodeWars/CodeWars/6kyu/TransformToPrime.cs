using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Task :
     * Given a List [] of n integers , find minimum mumber to be inserted in a list, so that sum of all elements of list should equal the closest prime number .
     * Notes
     * List size is at least 2 .
     * List's numbers will only positives (n > 0) .
     * Repeatition of numbers in the list could occur .
     * The newer list's sum should equal the closest prime number .
     * Input >> Output Examples
     * 1- minimumNumber ({3,1,2}) ==> return (1)
     * Explanation:
     * Since , the sum of the list's elements equal to (6) , the minimum number to be inserted to transform the sum to prime number is (1) ,
     * which will make the sum of the List equal the closest prime number (7).
     * 2-  minimumNumber ({2,12,8,4,6}) ==> return (5)
     * Explanation:
     * Since , the sum of the list's elements equal to (32) , the minimum number to be inserted to transform the sum to prime number is (5) ,
     * which will make the sum of the List equal the closest prime number (37).
     * 3- minimumNumber ({50,39,49,6,17,28}) ==> return (2)
     * Explanation:
     * Since , the sum of the list's elements equal to (189) , the minimum number to be inserted to transform the sum to prime number is (2) ,
     * which will make the sum of the List equal the closest prime number (191).
     */
    class TransformToPrime
    {
        public static int MinimumNumber(int[] numbers)
        {
            return NextPrime(numbers.Sum()) - numbers.Sum();
        }
        public static int NextPrime(int sum)
        {
            if (sum == 2 || sum == 3) return sum;
            while (true)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(sum); i++)
                    if (sum % i == 0) { isPrime = false; break; }
                if (isPrime) return sum;
                sum++;
            }
        }
    }
}
