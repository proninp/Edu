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
            int discount = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, int> coffee = new Dictionary<string, int>();
            coffee.Add("Americano", 50);
            coffee.Add("Latte", 70);
            coffee.Add("Flat White", 60);
            coffee.Add("Espresso", 60);
            coffee.Add("Cappuccino", 80);
            coffee.Add("Mocha", 90);


            foreach (var k in coffee.Keys.ToArray())
            {
                int i = coffee[k];
                int a = i - (int)(((float)i / 100) * discount);
                coffee[k] = a;
                Console.WriteLine(k + ": " + coffee[k]);
            }
            Console.ReadLine();
            return;

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
