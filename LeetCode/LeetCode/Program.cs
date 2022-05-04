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
            Console.WriteLine(Easy.Implement_strStr.StrStr("hello", "ll"));
            Console.WriteLine(Easy.Implement_strStr.StrStr("aaaaa", "bba"));
            Console.WriteLine(Easy.Implement_strStr.StrStr("hello", "h"));
            Console.WriteLine(Easy.Implement_strStr.StrStr("bigstrstr", "str"));
            Console.WriteLine(Easy.Implement_strStr.StrStr("b", "s"));
            Console.WriteLine(Easy.Implement_strStr.StrStr("mississippi", "issip"));


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
