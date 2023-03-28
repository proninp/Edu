using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    internal static class _1Introduction
    {
        /// <summary>
        /// Expr1. Как поменять местами значения двух переменных? Можно ли это сделать без ещё одной временной переменной. Стоит ли так делать?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Expr1(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        /// <summary>
        /// Expr2. Задается натуральное трехзначное число (гарантируется, что трехзначное).
        /// Развернуть его, т.е. получить трехзначное число, записанное теми же цифрами в обратном порядке.
        /// </summary>
        public static void Expr2(int a)
        {
            int len = GetNumberLength(a);
            int k = 1;
            int[] arr = new int[len];
            int num = a;
            for (int i = 0; i < len; i++)
            {
                num /= 10;
                arr[i] = a - (num * 10);
                a = num;
            }
            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }
        static int GetNumberLength(int a)
        {
            int len = 0;
            while(a > 0)
            {
                a /= 10;
                len++;
            }
            return len;
        }
        /// <summary>
        /// Expr3. Задано время Н часов (ровно). Вычислить угол в градусах между часовой и минутной стрелками.
        /// Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static int Expr3(int h)
        {
            if ((h == 0) || (h == 12) || (h == 24))
                return 0;
            h %= 12;
            return (h <= 6) ? h * 30 : (180 - (h - 6) * 30);
        }
        /// <summary>
        /// Expr4. Найти количество чисел меньших N, которые имеют простые делители X или Y.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Expr4(int n, int x, int y)
        {
            int c = 0;
            for (int i = (n - 1); i > 1; i++)
            {
                int a = n / x;
                int b = n / y;
                if ((a * x == n) && (b * y == n))
                    c++;
            }
            return c;
        }
    }

}
