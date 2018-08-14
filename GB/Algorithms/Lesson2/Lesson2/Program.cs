using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        /*
         * Dev. by Pronin P.S.
         */
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }

        #region Task 1
        static void Task1()
        {
            Console.WriteLine("Введите число:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(BinaryConverter(n));
            Console.ReadLine();
        }
        static string BinaryConverter(int n) => (n / 2 != 0) ? BinaryConverter(n / 2) + (n % 2).ToString() : (n % 2).ToString();
        #endregion

        #region Task 2
        /// <summary>
        /// 2. Реализовать функцию возведения числа a в степень b:
        /// a.без рекурсии;
        /// b.рекурсивно;
        /// c. * рекурсивно, используя свойство чётности степени.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Введите число:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите степень:");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine(IterationExp(n, d));
            Console.WriteLine(RecursionExp(n, d));
            Console.WriteLine(RecursionExp2(n, d));
            Console.ReadLine();
        }
        /// <summary>
        /// a. без рекурсии;
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double IterationExp(int n, int d)
        {
            int r = 1;
            for (int i = 0; i < Math.Abs(d); i++)
                r *= n;
            return (d < 0) ? 1.0 / r : r;
        }
        /// <summary>
        /// b. рекурсивно;
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double RecursionExp(int n, int d) => (d == 0) ? 1 : (d > 0) ? RecursionExp(n, Math.Abs(d - 1)) * n : 1 / RecursionExp(n, Math.Abs(d - 1)) * n;
        /// <summary>
        /// c. *рекурсивно, используя свойство чётности степени.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double RecursionExp2(int n, int d) => (d == 0) ? 1 :
            (d < 0) ? 1 / (
            (Math.Abs(d) == 2) ? n * n : (Math.Abs(d) % 2 == 1) ? RecursionExp2(n, Math.Abs(d) - 1) * n : RecursionExp2((int)RecursionExp2(n, Math.Abs(d) / 2), 2)) :
            ((Math.Abs(d) == 2) ? n * n : (Math.Abs(d) % 2 == 1) ? RecursionExp2(n, Math.Abs(d) - 1) * n : RecursionExp2((int)RecursionExp2(n, Math.Abs(d) / 2), 2));
        #endregion

        #region Task 3
        /// <summary>
        /// Исполнитель Калькулятор преобразует целое число, записанное на экране.
        /// У исполнителя две команды, каждой команде присвоен номер:
        /// Прибавь 1 2.Умножь на 2 Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.
        /// Сколько существует программ, которые число 3 преобразуют в число 20? а) с использованием массива; б) с использованием рекурсии.
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("Введите число (до):");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число (от):");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(GetProgramsCountI(n, x - 1));
            Console.WriteLine(GetProgramsCountR(n/2, x, x));
            Console.ReadLine();
        }
        /// <summary>
        /// 3: 1st
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        static int GetProgramsCountI(int n, int x)
        {
            int[] a = new int[n];
            for (int i = n - 1; i >= x && n > 0; i--)
                a[i] = (i >= n / 2) ? 1 : (i == (n / 2 - 1)) ? 2 : a[i] = a[i + 1] + a[i * 2 + 1];
            return n - 1 > x ? a[x] : 0;
        }
        /// <summary>
        /// 3: 2nd
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int GetProgramsCountR(int n, int x, int y) => (n == x) ? 0 : (y == n) ? 2 : (y > n) ? 1 : GetProgramsCountR(n, x, y + 1) + GetProgramsCountR(n, x, y * 2);
#endregion
    }
}
