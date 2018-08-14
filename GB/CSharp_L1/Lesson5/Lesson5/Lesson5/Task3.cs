using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №3
     * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
     * а) с использованием методов C#
     * б) *разработав собственный алгоритм
     */
    class Task3
    {
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TextConstants.TASK3_DESCR, ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_LINE1, ConsoleColor.Yellow);
            string s1 = Console.ReadLine();
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_LINE2, ConsoleColor.Yellow);
            string s2 = Console.ReadLine();
            if (IsPermutation(s1, s2))
            //if (MyIsPermutation(s1, s2))
                CommonMethods.ColoredWriteLine(TextConstants.STR_IS_PERM, ConsoleColor.Cyan);
            else
                CommonMethods.ColoredWriteLine(TextConstants.STR_IS_NOT_PERM, ConsoleColor.Cyan);
        }
        /// <summary>
        /// Метод опеределяет, является ли одна строка перестановкой другой
        /// С использованием встроенных методов C#
        /// </summary>
        /// <param name="s1">Строка 1</param>
        /// <param name="s2">Строка 2</param>
        /// <returns>Результат сравнения</returns>
        static bool IsPermutation(string s1, string s2)
        {
            return String.Concat(s1.ToLower().OrderBy(ch => ch)).Equals(String.Concat(s2.ToLower().OrderBy(ch => ch)));
        }
        /// <summary>
        /// Метод определяет, является ли одна строка перестановкой другой
        /// Про помощи собственного алгоритма
        /// </summary>
        /// <param name="s1">Строка 1</param>
        /// <param name="s2">Строка 2</param>
        /// <returns>Результат</returns>
        static bool MyIsPermutation(string s1, string s2)
        {
            return ((s1.Length == s2.Length) && (BubbleSort(s1).Equals(BubbleSort(s2))));
        }
        /// <summary>
        /// Сортировка строк методом Пузырька
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Отсортированная в порядке возрастания строка</returns>
        static string BubbleSort(string s)
        {
            bool swapped;
            char[] a = s.ToCharArray();
            do
            {
                swapped = false;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i - 1].CompareTo(a[i]) > 0)
                    {
                        char temp = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            return new string(a);
        }
    }
}
