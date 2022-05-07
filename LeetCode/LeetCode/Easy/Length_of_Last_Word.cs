using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 58. Length of Last Word
     * Given a string s consisting of some words separated by some number of spaces, return the length of the last word in the string.
     * A word is a maximal substring consisting of non-space characters only.
     * 
     * Example 1:
     * Input: s = "Hello World"
     * Output: 5
     * Explanation: The last word is "World" with length 5.
     * 
     * Example 2:
     * Input: s = "   fly me   to   the moon  "
     * Output: 4
     * Explanation: The last word is "moon" with length 4.
     * 
     * Example 3:
     * Input: s = "luffy is still joyboy"
     * Output: 6
     * Explanation: The last word is "joyboy" with length 6.
     */
    public class Length_of_Last_Word
    {
        public static int LengthOfLastWord(string s)
        {
            int len = s.Length;
            if (len == 0) return 0;
            char space = ' ';
            if (len == 1) return (s[0] == space) ? 0 : len;
            for (int i = len - 1; i >= 0; i--)
                if (s[i] != space)
                    for (int j = i; j >= 0; j--)
                        if ((s[j] == space))
                            return (i - j);
                        else if (j == 0)
                            return(i - j + 1);

            return 0;
        }
    }
}
