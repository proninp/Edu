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
            Console.WriteLine(Easy.Sqrt_x.MySqrt(4));
            Console.WriteLine(Easy.Sqrt_x.MySqrt(8));
            Console.WriteLine(Easy.Sqrt_x.MySqrt(9));
            Console.WriteLine(Easy.Sqrt_x.MySqrt(4901));
            Console.WriteLine(Easy.Sqrt_x.MySqrt(2147483647));

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
