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
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord("Hello World"));
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord("   fly me   to   the moon  "));
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord("luffy is still joyboy"));
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord(" "));
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord("as "));
            Console.WriteLine(Easy.Length_of_Last_Word.LengthOfLastWord(""));

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
