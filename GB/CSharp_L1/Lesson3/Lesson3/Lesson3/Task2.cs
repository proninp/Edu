using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №2
     * а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
     * Требуется подсчитать сумму всех нечетных положительных чисел.
     * Сами числа и сумму вывести на экран; Используя tryParse;
     * б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
     * При возникновении ошибки вывести сообщение.
     */
    class Task2
    {
        /// <summary>
        /// Метод выводит в кнсоль сумму всех нечетных положительных чисел, введенных пользователем с клавиатуры.
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task2Text, ConsoleColor.Cyan);
            int sum = 0;
            do
            {
                CommonMethods.ColoredWriteLine("Введите число:", ConsoleColor.Yellow);
                int a = CommonMethods.SetIntParametr();
                //int a = SetIntParametrExProcessing(); // Реализация того же метода с использованием try{ } catch{ }
                if (a == 0)
                    break;
                if (a % 2 != 0 && a > 0)
                    sum += a;

            } while (true);
            CommonMethods.ColoredWriteLine($"Сумма всех нечетных положительных чисел:\n{sum}", ConsoleColor.Cyan);
        }
    }
}