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
     * Задание №7
     * a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b);
     * б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
     */
    class Task7
    {
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Введите первое число:", ConsoleColor.Yellow);
            int a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите второе число:", ConsoleColor.Yellow);
            int b = CommonMethods.SetIntParametr();
            Swap(ref a, ref b); // На всякий случай (защита от "дурака")
            RecursivePrint(a, b);
            CommonMethods.ColoredWriteLine($"Сумма чисел от {a} до {b} = {RecursiveSum(a, b)}.", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Рекурсивный метод, который выводит на экран числа от a до b(a<b)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        public static void RecursivePrint(int a, int b)
        {
            CommonMethods.ColoredWrite($"{a}{((a != b) ? ", " : "\n")}", ConsoleColor.Cyan);
            if (a == b)
                return;
            RecursivePrint(++a, b);
            
        }
        /// <summary>
        /// Рекурсивный метод, который считает сумму чисел от a до b
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns></returns>
        public static int RecursiveSum(int a, int b)
        {
            if (b == a)
                return a;
            return b + RecursiveSum(a, --b);
        }
        /// <summary>
        /// Функция смены значений местами в случае некорректного ввода
        /// </summary>
        /// <param name="a">Первый аргумент</param>
        /// <param name="b">Второй аргумент</param>
        public static void Swap(ref int a, ref int b)
        {
            if (a > b)
            {
                a += b;
                b = a - b;
                a -= b;
            }
        }
    }
}
