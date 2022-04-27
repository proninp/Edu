using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 9.
     * Given an integer x, return true if x is palindrome integer.
     * An integer is a palindrome when it reads the same backward as forward.
     * For example, 121 is a palindrome while 123 is not.
     */
    public class Palindrome_Number
    {
        public static bool IsPalindrome(int x)
        {
            return SecondSolution(x);
        }
        static bool SecondSolution(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;
            int reverted = 0;
            while (x > reverted)
            {
                reverted = reverted * 10 + x % 10;
                x /= 10;
            }
            return x == reverted || x == reverted / 10;
        }
        static bool FirstSolution(int x)
        {
            if (x < 0)
                return false;
            string leftToRight = x.ToString();
            string rightToLeft = string.Join("", leftToRight.Reverse().ToArray());
            return leftToRight.Equals(rightToLeft);
        }
    }
}
