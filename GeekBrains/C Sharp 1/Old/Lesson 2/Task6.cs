using System;

namespace Lesson_2
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №6
     * Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000 000.
     * Хорошим называется число, которое делится на сумму своих цифр.
     * Реализовать подсчет времени выполнения программы, используя структуру DateTime.
     */
    class Task6
    {
        public static void Go()
        {
            DateTime start = DateTime.Now;
            const int num = 100000000;
            int count = 0;
            for (int i = 1; i <= num; i++)
            {
                if (isAGoodNumber(i))
                    count++;
            }
            TimeSpan timeSpan = DateTime.Now - start;
            CommonMethods.ColoredWriteLine($"Count of \"Good\" numbers of {1} to {num}: {count}.", ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine($"Time: " +
                $"{timeSpan.Seconds + timeSpan.Seconds * timeSpan.Minutes + timeSpan.Seconds * timeSpan.Minutes*timeSpan.Hours}.{timeSpan.Milliseconds} seconds.", ConsoleColor.Cyan);
        }
        public static bool isAGoodNumber(int num)
        {
            int sum = 0;
            string str = num.ToString();
            #region First method
            //while (num != 0)
            //{
            //    sum += num % 10;
            //    num /= 10;
            //}
            #endregion
            #region Second method
            for (int i = 0; i < str.Length; i++)
                sum += str[i] - 48; // 48 - "0"
            #endregion
            return num % sum == 0;
        }
    }
}
