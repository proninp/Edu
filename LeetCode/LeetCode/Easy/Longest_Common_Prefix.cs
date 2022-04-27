using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 14.
     * Write a function to find the longest common prefix string amongst an array of strings.
     * If there is no common prefix, return an empty string "".
     * 
     * Example 1:
     * Input: strs = ["flower","flow","flight"]
     * Output: "fl"
     * 
     * Example 2:
     * Input: strs = ["dog","racecar","car"]
     * Output: ""
     * Explanation: There is no common prefix among the input strings.
     */
    public class Longest_Common_Prefix
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            return FirstSolution(strs);
        }
        static string SecondSolution(string[] strs)
        {
            int size = strs.Length;
            if (size == 0)
                return "";
            if (size == 1)
                return strs[0];
            Array.Sort(strs);
            int minLen = Math.Min(strs[0].Length, strs[size - 1].Length);
            int i = 0;
            while (i < minLen && strs[0][i] == strs[size - 1][i])
                i++;
            return strs[0].Substring(0, i);
        }
        static string FirstSolution(string[] strs)
        {
            int size = strs.Length;
            if (size == 0)
                return "";
            if (size == 1)
                return strs[0];
            int minWordSize = int.MaxValue;
            int minWordIndex = 0;
            int prefixLen = minWordSize;
            for (int i = 0; i < size; i++)
                if (strs[i].Length < minWordSize)
                {
                    minWordSize = strs[i].Length;
                    minWordIndex = i;
                }
            for (int i = 0; i < size; i++)
                if (i != minWordIndex)
                {
                    int j = 0;
                    while (j < minWordSize && strs[i][j] == strs[minWordIndex][j])
                        j++;
                    if (j == 0)
                        return "";
                    if (j < prefixLen)
                        prefixLen = j;
                }
            return strs[minWordIndex].Substring(0, prefixLen);
        }
    }
}
