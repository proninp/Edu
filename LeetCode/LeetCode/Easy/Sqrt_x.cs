using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 69. Sqrt(x)
     * 
     * Given a non-negative integer x, compute and return the square root of x.
     * Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
     * Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
     * 
     * Example 1:
     * Input: x = 4
     * Output: 2
     * 
     * Example 2:
     * Input: x = 8
     * Output: 2
     * Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.
     */
    public class Sqrt_x
    {
        public static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x < 4) return 1;
            if (x < 9) return 2;
            int start = 0;
            int end = x;
            while(start <= end)
            {
                int mid = (start + end) / 2;
                int divider = (int)(x / mid);
                if (divider == mid) return mid;
                else if (divider < mid)
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return end;
        }
    }
}
