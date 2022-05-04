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
            Console.WriteLine(Easy.Maximum_Subarray.MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
            Console.WriteLine(Easy.Maximum_Subarray.MaxSubArray(new int[] { 1 }));
            Console.WriteLine(Easy.Maximum_Subarray.MaxSubArray(new int[] { 5, 4, -1, 7, 8 }));
            Console.WriteLine(Easy.Maximum_Subarray.MaxSubArray(new int[] { 5, 0, 1, -5, 9 }));

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
