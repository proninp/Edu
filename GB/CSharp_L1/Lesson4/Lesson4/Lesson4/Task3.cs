using System;
using System.IO;
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
     * Задание №3
     * Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
     */
    class Task3
    {
        /// <summary>
        /// Проверка аутентификации
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task3Description, ConsoleColor.Cyan);
            string fileName = "..\\..\\Data\\Task3Data.txt";
            if (File.Exists(fileName))
            {
                if (Auth(fileName))
                    CommonMethods.ColoredWriteLine("Вы успешно авторизованы!", ConsoleColor.Green);
                else
                    CommonMethods.ColoredWriteLine("Лимит попыток израсходован! Попробуйте позже.", ConsoleColor.Red);
            }
            else
                CommonMethods.ColoredWriteLine("Файл не существует!", ConsoleColor.Red);
        }
        /// <summary>
        /// Метод проверки корректности пары Логин - Пароль
        /// </summary>
        /// <param name="fileName">Полное имя файла с данными об аутентификации</param>
        /// <returns>Результат аутентификации</returns>
        static bool Auth(string fileName)
        {
            string[] s = File.ReadAllLines(fileName);
            CommonMethods.ColoredWriteLine("Выберите правильную пару Логин - Пароль, у вас 3 попытки (правильная пара №7):", ConsoleColor.Yellow);
            int trysCount = 3;
            while (trysCount > 0)
            {
                for (int i = 0; i < s.Length; i++)
                    CommonMethods.ColoredWriteLine(((i + 1) + ": " + s[i].Split(' ')[0] + "-" + s[i].Split(' ')[1]), ConsoleColor.Magenta);
                int t = CommonMethods.SetIntParametr();
                if (t == 7)
                    return true;
                else
                if (--trysCount != 0)
                    CommonMethods.ColoredWriteLine("Неправильный логин или пароль!\nКоличество попыток: " + trysCount, ConsoleColor.Red);
            }
            return false;
        }
    }
}