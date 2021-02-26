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
            const int num = 1000000000;
            int count = 0;
            for (int i = 1; i <= num; i++)
            {
                if (isAGoodNumber(i))
                    count++;
            }
            TimeSpan timeSpan = DateTime.Now - start;
            CommonMethods.ColoredWriteLine($"Кол-во \"Хороших\" чисел от {1} до {num}: {count}.", ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine($"Время выполнения программы: " +
                $"{timeSpan.Seconds + timeSpan.Seconds * timeSpan.Minutes + timeSpan.Seconds * timeSpan.Minutes*timeSpan.Hours}.{timeSpan.Milliseconds} секунд.", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Проверяет, делится ли без остатка число на сумму своих цифр
        /// </summary>
        /// <param name="num">Исходное число</param>
        /// <returns>Да/Нет</returns>
        public static bool isAGoodNumber(int num)
        {
            int sum = 0;
            string str = num.ToString();
            #region Способ номер раз
            //while (num != 0)
            //{
            //    sum += num % 10;
            //    num /= 10;
            //}
            #endregion
            #region Способ номер два (пошустрее)
            for (int i = 0; i < str.Length; i++)
                sum += str[i] - 48; // 48 - код символа "0"
            #endregion
            return num % sum == 0;
        }
    }
}
