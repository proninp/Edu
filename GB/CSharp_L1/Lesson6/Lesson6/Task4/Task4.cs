using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №4
     * В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или xxx-xx-xx.
     * Вывести все номера телефонов, которые содержатся в файле.
     */
    class Task4
    {
        static void Main(string[] args)
        {
            Regex r = new Regex("\\b\\d{2,3}-\\d{2}-\\d{2}\\b|\\b\\d{3}-\\d{3}\\b");
            do
            {
                Lesson6.Support.ColoredWriteLine("Введите номер телефона или 0 для выхода из программы:", ConsoleColor.Yellow);
                string check = Console.ReadLine();
                if (check.Equals("0")) break;
                foreach (Match match in r.Matches(check))
                    Lesson6.Support.ColoredWriteLine(match.Value, ConsoleColor.Green);
                if (!r.IsMatch(check))
                    Lesson6.Support.ColoredWriteLine("Совпадений нет.", ConsoleColor.Red);
            } while (true);

        }
    }
}
