using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Easy.Longest_Common_Prefix.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.WriteLine(Easy.Longest_Common_Prefix.LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
            Console.WriteLine(Easy.Longest_Common_Prefix.LongestCommonPrefix(new string[] { "a" }));
            Console.WriteLine(Easy.Longest_Common_Prefix.LongestCommonPrefix(new string[] { "ab", "a"}));
            Console.WriteLine(Easy.Longest_Common_Prefix.LongestCommonPrefix(new string[] { "geeksforgeeks", "geeks", "geek", "geezer" }));
            Console.ReadLine();
        }
        static string PrintArray(int[] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            foreach (var e in a)
            {
                if (stringBuilder.Length > 1)
                    stringBuilder.Append(", ");
                stringBuilder.Append(string.Format($"{e}", e.ToString()));
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
    }
}
