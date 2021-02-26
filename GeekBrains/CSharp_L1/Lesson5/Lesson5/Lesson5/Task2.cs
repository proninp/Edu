using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Task2
    {
        /*
         * Исполнитель:
         * Пронин Павел
         * 
         * Задание №3
         * Разработать методы для решения следующих задач. Дано сообщение:
         * а) Вывести только те слова сообщения, которые содержат не более чем n букв;
         * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
         * в) Найти самое длинное слово сообщения;
         * г) Найти все самые длинные слова сообщения.
         */
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TextConstants.TASK2_DESCR, ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_MESSAGE, ConsoleColor.Yellow);
            MyString s = new MyString(Console.ReadLine());

            #region а) Вывести только те слова сообщения, которые содержат не более чем n букв;
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_LETTERS_COUNT, ConsoleColor.Yellow);
            int n = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine(String.Format("Слова сообщения, не длиннее {0} букв (Без использования регулярных выражений):", n), ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.CheckWordsLength(n), ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine(String.Format("Слова сообщения, не длиннее {0} букв (С использованием регулярных выражений):", n), ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.CheckWordsLength(n), ConsoleColor.Cyan);
            #endregion

            #region б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
            CommonMethods.ColoredWriteLine(TextConstants.ENTER_ENDING_SYMBOL, ConsoleColor.Yellow);
            string st = Console.ReadLine();
            CommonMethods.ColoredWriteLine(String.Format("Слова сообщения, не заканчивающиеся на символ {0} (Без использования регулярных выражений):", st), ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.DeleteWords(st), ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine(String.Format("Слова сообщения, не заканчивающиеся на символ {0} (С использованием регулярных выражений):", st), ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.RegexDeleteWords(st), ConsoleColor.Cyan);
            #endregion

            #region в) Найти самое длинное слово сообщения;
            CommonMethods.ColoredWriteLine(TextConstants.LONGEST_WORD, ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.FindLongestWord(), ConsoleColor.Cyan);
            #endregion

            #region г) Найти все самые длинные слова сообщения.
            CommonMethods.ColoredWriteLine(TextConstants.LONGEST_WORDS, ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(s.FindAllLongestWords(), ConsoleColor.Cyan);
            #endregion
        }
    }
}
