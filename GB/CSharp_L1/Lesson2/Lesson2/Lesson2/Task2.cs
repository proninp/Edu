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
     * Задание №2
     * Написать метод подсчета количества цифр числа.
     */
    class Task2
    {
        /// <summary>
        /// Метод запрашивает любое число и выводит в консоль количество цифр, содержащихся в нем
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Введите число:", ConsoleColor.Yellow);
            double a = CommonMethods.SetDoubleParametr();
            CommonMethods.ColoredWriteLine($"Кол-во цифр в числе {a}:\n{a.ToString().Replace(",", "").Length}", ConsoleColor.Cyan);
        }
    }
}
