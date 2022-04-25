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
            Console.WriteLine(PrintArray(Easy.Two_Sum.TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(PrintArray(Easy.Two_Sum.TwoSum(new int[] { 3, 2, 4 }, 6)));
            Console.WriteLine(PrintArray(Easy.Two_Sum.TwoSum(new int[] { 3, 3}, 6)));
            Console.WriteLine(PrintArray(Easy.Two_Sum.TwoSum(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11)));
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
