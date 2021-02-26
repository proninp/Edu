using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №1
     * Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
     * Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
     * В данной задаче под парой подразумевается два подряд идущих элемента массива.
     * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
     */
    class Task1
    {
        /// <summary>
        /// Вывод пар элементов массива, в которых хотя бы одно число делится на 3
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task1Description, ConsoleColor.Cyan);
            int[] a = new int[20];
            int min = -10000;
            int max = 10001;
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
                a[i] = rnd.Next(min, max);
            CommonMethods.ColoredWriteLine("В массиве:", ConsoleColor.Yellow);
            CommonMethods.PrintArray(a, ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine("Пар элементов, кратных 3:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(PairsSearch(a).ToString(), ConsoleColor.Cyan);
        }
        /// <summary>
        /// Поиск пар чисел
        /// </summary>
        /// <param name="a">Целочисленный массив</param>
        /// <returns>Количество пар</returns>
        static int PairsSearch(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length-1; i++)
                if (a[i] % 3 == 0 || a[i+1] % 3 == 0)
                    count++;
            return count;
        }
    }
}