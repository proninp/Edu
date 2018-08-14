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
     * Задание №4
     * Реализовать метод проверки логина и пароля. На вход подается логин и пароль.
     * На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин:root, Password:GeekBrains).
     * Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
     * программа пропускает его дальше или не пропускает. 
     * С помощью цикла do while ограничить ввод пароля тремя попытками.
     */
    class Task4
    {
        const string LOGIN = "root";
        const string PASSWORD = "GeekBrains";
        /// <summary>
        /// Метод проверки корректности учетных данных пользователя.
        /// </summary>
        public static void Go()
        {
            int i = 0;
            bool isAuthorized;
            do
            {
                CommonMethods.ColoredWriteLine("Введите логин:", ConsoleColor.Yellow);
                string login = Console.ReadLine();
                CommonMethods.ColoredWriteLine("Введите пароль:", ConsoleColor.Yellow);
                string password = Console.ReadLine();
                isAuthorized = CheckCredentials(login, password, i);
                i++;
            } while (i < 3 && !isAuthorized);
        }
        /// <summary>
        /// Метод проверки логина и пароля.
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>bool - значение Авторизации</returns>
        public static bool CheckCredentials(string login, string password, int trysCount)
        {
            if (login.Equals(LOGIN) && password.Equals(PASSWORD))
            {
                CommonMethods.ColoredWriteLine("Авторизация выполнена успешно!", ConsoleColor.Green);
                return true;
            } else
            {
                CommonMethods.ColoredWriteLine($"Неверные логин или пароль!\nОсталось попыток: {2-trysCount}", ConsoleColor.Red);
                return false;
            }
        }
    }
}