using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Middle
{
    /*
     * Given a string s, find the length of the longest substring without repeating characters.
     * 
     * Example 1:
     * Input: s = "abcabcbb"
     * Output: 3
     * Explanation: The answer is "abc", with the length of 3.
     * 
     * Example 2:
     * Input: s = "bbbbb"
     * Output: 1
     * Explanation: The answer is "b", with the length of 1.
     * 
     * Example 3:
     * Input: s = "pwwkew"
     * Output: 3
     * Explanation: The answer is "wke", with the length of 3.
     * Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
     */

    public class Longest_Substring_Without_Repeating_Characters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1)
                return s.Length;
            int maxSubstringLen = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = s.Length - i; j >= 0; j--)
                {
                    string sub = s.Substring(i, j);
                    if (sub.Length == sub.Distinct().Count())
                        if (sub.Length > maxSubstringLen)
                        {
                            maxSubstringLen = sub.Length;
                            if (j < maxSubstringLen)
                                break;
                        }
                }
                if (maxSubstringLen > (s.Length - i))
                    return maxSubstringLen;
            }
            return maxSubstringLen;
        }
    }
}
