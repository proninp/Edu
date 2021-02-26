using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №1
     * Написать метод, возвращающий минимальное из трех чисел.
     */
    class Task1
    {
        /// <summary>
        /// Метод, запрашивающий три числа и выводящий в консоль минимальное из этих чисел.
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Введите первое целое число:", ConsoleColor.Yellow);
            int a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите второе целое число:", ConsoleColor.Yellow);
            int b = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите третье целое число:", ConsoleColor.Yellow);
            int c = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine($"Минимум из чисел {a}, {b} и {c}:\n{CompareThreeNum(a, b, c)}", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Метод поиска минимума из трех целых чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns>Минимальное число</returns>
        public static int CompareThreeNum(int a, int b, int c)
        {
            return ((a > b) ? ((b > c) ? c : b) : ((a > c) ? c : a));
        }
    }
}
