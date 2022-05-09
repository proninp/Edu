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
            Console.WriteLine(Easy.Add_Binary.AddBinary("11", "1"));
            Console.WriteLine(Easy.Add_Binary.AddBinary("1010", "1011"));
            Console.WriteLine(Easy.Add_Binary.AddBinary("1111", "1111"));
            Console.WriteLine(Easy.Add_Binary.AddBinary("100", "110010"));


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
