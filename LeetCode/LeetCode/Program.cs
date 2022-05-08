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
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 1, 2, 3 })));
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 4, 3, 2, 1 })));
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 9 })));
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 8, 9, 9 })));
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 9, 9, 9 })));
            Console.WriteLine(PrintArray(Easy.Plus_One.PlusOne(new int[] { 1, 9, 9, 9, 9, 9 })));

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
