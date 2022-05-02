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
            Console.WriteLine(Easy.Remove_Duplicates_From_Sorted_Array.RemoveDuplicates(new int[] { 1, 1, 2 }));
            Console.WriteLine(Easy.Remove_Duplicates_From_Sorted_Array.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
            Console.WriteLine(Easy.Remove_Duplicates_From_Sorted_Array.RemoveDuplicates(new int[] { 2 }));
            Console.WriteLine(Easy.Remove_Duplicates_From_Sorted_Array.RemoveDuplicates(new int[] { 2, 2, 2, 2, 2, 2 }));

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
