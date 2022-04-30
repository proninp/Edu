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
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3 }, 1));
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3, 5, 6 }, 5));
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3, 5, 6, 8, 9, 11 }, 7));
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3, 5, 6, 7 }, 9));
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3, 5, 6, 7, 12 }, 2));
            Console.WriteLine(Easy.Search_Insert_Position.SearchInsert(new int[] { 1, 3, 5, 6, 7, 12 }, 9));

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
