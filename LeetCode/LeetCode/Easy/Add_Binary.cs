using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 67. Add Binary
     * Given two binary strings a and b, return their sum as a binary string.
     * 
     * Example 1:
     * Input: a = "11", b = "1"
     * Output: "100"
     * 
     * Example 2:
     * Input: a = "1010", b = "1011"
     * Output: "10101"
     */
    public class Add_Binary
    {
        public static string AddBinary(string a, string b)
        {
            int sizeA = a.Length;
            int sizeB = b.Length;
            if (sizeB > sizeA)
            {
                string swap = a;
                a = b;
                b = swap;
                sizeA += sizeB;
                sizeB = sizeA - sizeB;
                sizeA -= sizeB;
            }
            int nextDigit = 0;
            char[] chars = a.ToCharArray();
            int i = sizeA;
            int j = sizeB;
            while (--i >= 0 && --j >= 0)
            {
                int res = a[i] + b[j] - 96 + nextDigit;
                if (res < 2)
                {
                    chars[i] = (char)(res + 48);
                    nextDigit = 0;
                }
                else
                {
                    nextDigit = 1;
                    chars[i] = (res > 2) ? '1' : '0';
                }
            }
            if (nextDigit == 0)
                return new string(chars);
            if (sizeA == sizeB)
                return "1" + new string(chars);
            for (i = sizeA - sizeB - 1; i >= 0; i--)
            {
                int res = a[i] - 48 + nextDigit;
                if (res < 2)
                {
                    chars[i] = (char)(res + 48);
                    return new String(chars);
                }
                else
                {
                    nextDigit = 1;
                    chars[i] = '0';
                }
            }
            return ((nextDigit == 1) ? "1" : "") + new string(chars);

        }
    }
}
