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
     * Задание №3
     * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
     */
    class Task3
    {
        /// <summary>
        /// Метод выводит в кнсоль сумму всех нечетных положительных чисел, введенных пользователем с клавиатуры.
        /// </summary>
        public static void Go()
        {
            int sum = 0;
            do
            {
                CommonMethods.ColoredWriteLine("Введите число:", ConsoleColor.Yellow);
                int a = CommonMethods.SetIntParametr();
                if (a == 0)
                    break;
                if (a % 2 != 0 && a > 0)
                    sum += a;

            } while (true);
            CommonMethods.ColoredWriteLine($"Сумма всех нечетных положительных чисел:\n{sum}", ConsoleColor.Cyan);
        }
    }
}
