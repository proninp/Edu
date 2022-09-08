using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.ReadLine();
        }
        /// <summary>
        /// Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и
        /// позволяет завершить указанный процесс.Предусмотреть возможность завершения процессов с
        /// помощью указания его ID или имени процесса.В качестве примера можно использовать консольные
        /// утилиты Windows tasklist и taskkill.
        /// </summary>
        static void Task1()
        {
            Process[] processes = Process.GetProcesses();
            List<string> processNames = new List<string>();
            
            Console.WriteLine("Список процессов:\n");
            foreach(Process p in processes)
            {
                if (!processNames.Contains(p.ProcessName))
                    processNames.Add(p.ProcessName);
                Console.WriteLine($"Id: {p.Id};\t\tName: \"{p.ProcessName}\";");
            }

            WriteToConsole("Выберите пункт меню:", ConsoleColor.Yellow, true);
            WriteToConsole(" * 1. Закрыть процесс по ID;", ConsoleColor.Yellow, true);
            WriteToConsole(" * 2. Закрыть процесс по имени;", ConsoleColor.Yellow, true);
            WriteToConsole(" * Закрыть приложение - любой другой символ.", ConsoleColor.Yellow, true);
            
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int selection))
            {
                WriteToConsole("Команда не распознана. Завершение работы программы.", ConsoleColor.Red, true);
                return;
            }   
            
            try
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Введите ID процесса для завершения:");
                        CloseProcessById(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Введите наименование процесса для завершения:");
                        CloseProcessByName(Console.ReadLine(), processNames);
                        break;
                    default:
                        WriteToConsole("Завершение работы программы.", ConsoleColor.Yellow, true);
                        return;
                }
            }
            catch (Exception e)
            {
                WriteToConsole($"Процесс завершился с ошибкой: {e.Message}", ConsoleColor.Red, true);
            }

        }
        /// <summary>
        /// Функция завершения процесса по его ID
        /// </summary>
        /// <param name="input">Строка ввода из консоли</param>
        static void CloseProcessById(string input)
        {
            if (!CheckInputTextValid(input))
                return;
            int processId = 0;
            if (!int.TryParse(input, out processId))
            {
                WriteToConsole("Введенный id процесса не соответствует числовому формату.", ConsoleColor.Red, true);
                return;
            }
            Process process = Process.GetProcessById(processId);
            string output = $"Процесс с именем \"{process.ProcessName}\" и id \"{process.Id}\" завершен.";
            process.Kill();
            WriteToConsole(output, ConsoleColor.Green, true);
        }

        /// <summary>
        /// Функция завершения процесса по имени
        /// </summary>
        /// <param name="input">Строка ввода из консоли</param>
        /// <param name="processNames">Список существующих процессов</param>
        static void CloseProcessByName(string input, List<string> processNames)
        {
            if (!CheckInputTextValid(input))
                return;

            if (!processNames.Contains(input))
            {
                WriteToConsole($"Процесса с именем \"{input}\" не существует.\n", ConsoleColor.Red, true);
                return;
            }

            Process[] process = Process.GetProcessesByName(input);
            for (int i = 0; i < process.Length; i++)
                process[i].Kill();

            WriteToConsole($"Процесс с именем \"{input}\" завершен.", ConsoleColor.Green, true);
        }
        /// <summary>
        /// Функция для вывода в кончоль цветного текста
        /// </summary>
        /// <param name="text">Строка для вывода в консоль</param>
        /// <param name="consoleColor">Новый цвет текста</param>
        /// <param name="isNewLine">Флаг указателя для переноса на новую строку</param>
        static void WriteToConsole(string text, ConsoleColor consoleColor, bool isNewLine)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            string newLine = (isNewLine) ? "\n" : "";
            Console.Write(text + newLine);
            Console.ForegroundColor = currentColor;
        }
        /// <summary>
        /// Функиця для проверки валидного текста, переданного в функции поиска идентификатора или имени процесса
        /// </summary>
        /// <param name="input">Строка ввода из консоли</param>
        /// <returns></returns>
        static bool CheckInputTextValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                WriteToConsole($"Не задан идентификатор процесса, завершение работы программы.", ConsoleColor.Red, true);
                return(false);
            }
            return true;
        }

    }
}
