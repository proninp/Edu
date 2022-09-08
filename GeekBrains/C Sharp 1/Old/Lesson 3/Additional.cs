using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_3
{
    class Additional
    {
        public static double GetDoubleNumber(string message)
        {
            double d = 0;
            do
            {
                Console.WriteLine(message);
            }
            while (!double.TryParse(Console.ReadLine(), out d));
            return d;                
        }
        public static int GetIntegerNumber(string message)
        {
            int i = 0;
            do
            {
                Console.WriteLine(message);
            }
            while (!int.TryParse(Console.ReadLine(), out i));
            return i;
        }
        public static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
        public static int Gcd(int x, int y)
        {
            while (y != 0)
            {
                x %= y;
                Swap(ref x, ref y);
            }
            return x;
        }
        public static int Lcm(int x, int y)
        {
            return x * y / Gcd(x, y);
        }

    }
}
