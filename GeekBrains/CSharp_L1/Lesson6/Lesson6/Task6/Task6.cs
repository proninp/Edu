using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Task6
    {
        /*
         * Исполнитель:
         * Пронин Павел
         * 
         * Задача №6
         * В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок. Использовать регулярные выражения.
         */
        static void Main(string[] args)
        {
            Regex r = new Regex("<img.+?src=[\\\"'](.+?)[\\\"'].*?", RegexOptions.IgnoreCase);
            string[] files = Directory.GetFiles("..\\..\\Data", "*.html", SearchOption.AllDirectories);
            foreach (string item in files)
            {
                string content = File.ReadAllText(item);
                if (r.IsMatch(content))
                    Lesson6.Support.ColoredWriteLine($"Файл:\n{Path.GetFullPath(item)}", ConsoleColor.Yellow);
                foreach (Match match in r.Matches(content))
                    Lesson6.Support.ColoredWriteLine(match.Groups[1].Value, ConsoleColor.Cyan);
            }
            Console.ReadLine();
        }
    }
}
