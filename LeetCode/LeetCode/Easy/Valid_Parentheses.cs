using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 20.
     * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
     * An input string is valid if:
     * Open brackets must be closed by the same type of brackets.
     * Open brackets must be closed in the correct order.
     * 
     * Example 1:
     * Input: s = "()"
     * Output: true
     * 
     * Example 2:
     * Input: s = "()[]{}"
     * Output: true
     * 
     * Example 3:
     * Input: s = "(]"
     * Output: false
     */
    public class Valid_Parentheses
    {
        public static bool IsValid(string s)
        {
            int len = s.Length;
            if ((len < 2) || (len % 2 != 0))
                return false;
            Dictionary<char, char> map = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            Stack<char> box = new Stack<char>();
            for (int i = 0; i < len; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if ((box.Count == 0) || (map[s[i]] != box.Pop()))
                        return false;
                }
                else
                    box.Push(s[i]);
            }
            return (box.Count == 0);
        }
    }
}
