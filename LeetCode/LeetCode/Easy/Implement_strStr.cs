using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 28. Implement strStr()
     * Implement strStr().
     * Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
     * 
     * Example 1:
     * Input: haystack = "hello", needle = "ll"
     * Output: 2
     * 
     * Example 2:
     * Input: haystack = "aaaaa", needle = "bba"
     * Output: -1
     */
    public class Implement_strStr
    {
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            int needleLen = needle.Length;
            int haystackLen = haystack.Length;
            if (needleLen > haystackLen) return -1;
            if (needleLen == haystackLen)
                return needle.Equals(haystack) ? 0 : -1;
            for (int i = 0; i <= haystackLen - needleLen; i++)
            {
                if (haystack[i] == needle[0])
                {
                    bool isMatch = true;
                    for (int j = 1; j < needleLen; j++)
                    {
                        isMatch = needle[j] == haystack[i + j];
                        if (!isMatch)
                            break;
                    }
                    if (isMatch)
                        return i;
                }
            }
            return -1;
        }
    }
}
