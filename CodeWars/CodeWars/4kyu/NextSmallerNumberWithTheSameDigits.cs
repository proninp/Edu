using System;
using System.Linq;

namespace CodeWars._4kyu
{
    /*
     * Next smaller number with the same digits
     * Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.
     * For example:
     * nextSmaller(21) == 12
     * nextSmaller(531) == 513
     * nextSmaller(2071) == 2017
     * Return -1 (for Haskell: return Nothing), when there is no smaller number that contains the same digits.
     * Also return -1 when the next smaller number with the same digits would require the leading digit to be zero.
     * nextSmaller(9) == -1
     * nextSmaller(111) == -1
     * nextSmaller(135) == -1
     * nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
     * some tests will include very large numbers.
     * test data only employs positive integers.
     */
    public class NextSmallerNumberWithTheSameDigits
    {
        public static long NextSmaller(long n)
        {
            string s = n.ToString();
            int r = int.MaxValue, l = -1;
            for (int i = s.Length - 1; i >= 1; i--)
                for (int j = i - 1; j >= 0; j--)
                    if ((s[i] < s[j]) && !(s[i] == 48 && i == 1) && (i < r && j > l)) { r = i; l = j; }
            if (r == int.MaxValue || s.Where(c => c == 48).Count() == s.Length - 1) return -1;
            return Int64.Parse(s.Substring(0, l) + s[r] + string.Concat(s.Substring(r + 1).Reverse()) + s[l] + string.Concat(s.Substring(l + 1, r - l - 1).Reverse()));
        }
    }
}
