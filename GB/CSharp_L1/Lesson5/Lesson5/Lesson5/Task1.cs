using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №1
     * Создать программу, которая будет проверять корректность ввода логина. Корректным
     * логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при
     * этом цифра не может быть первой.
     * а) без использования регулярных выражений;     * б) **с использованием регулярных выражений.
     */
    class Task1
    {
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TextConstants.TASK1_DESCR, ConsoleColor.Cyan);
            Authorization();
            Console.ReadLine();
        }
        /// <summary>
        /// Метод проверки логина без использования регулярных выражений. но с использованием Linq
        /// (что не запрещено, то разрешено)
        /// </summary>
        /// <param name="s">Строковое представление логина</param>
        /// <returns>Результат</returns>
         static bool Check(string s)
        {
            return !(s.Length == 0 || char.IsDigit(s[0]) || (s.Length < 2 || s.Length > 10)) && s.All(c => char.IsLetterOrDigit(c));
        }
        /// <summary>
        /// Метод проверки логина с использованием регулярных выражений
        /// </summary>
        /// <param name="s">Строковое представление логина</param>
        /// <returns>Результат</returns>
        static bool RegexCheck(string s)
        {
            return new Regex("^[A-Za-z][A-Za-z0-9]{1,9}$").IsMatch(s);
        }
        /// <summary>
        /// Метод для повторных попыток ввода логина. Работа программы завершается, если 3 раза ввели некорректный логин.
        /// </summary>
        /// <returns>Результат</returns>
        static bool Authorization()
        {
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_LOGIN, ConsoleColor.Yellow);
            int i = 0;
            while (i < 3)
            {
                if (Check(Console.ReadLine())) // без использования регулярных выражений
                //if (RegexCheck(Console.ReadLine())) // с использованием регулярных выражений
                {
                    CommonMethods.ColoredWriteLine(TextConstants.LOGIN_CORRECT, ConsoleColor.Green);
                    return true;
                } else
                {
                    CommonMethods.ColoredWriteLine(TextConstants.LOGIN_NOT_CORRECT, ConsoleColor.Red);
                    if (++i < 3) CommonMethods.ColoredWriteLine(TextConstants.TRYS_COUNT + (3 - i), ConsoleColor.Red); // Зачем предупреждать, если больше нет попыток?
                    else CommonMethods.ColoredWriteLine(TextConstants.TRYS_COUNT_END, ConsoleColor.Red);
                }
            }
            return false;

        }

    }
}
