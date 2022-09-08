using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 4
     * Method to check login and password
     * Correct login: root, correct password: GeekBrains
     */
    class Task4
    {
        const string LOGIN = "root";
        const string PASSWORD = "GeekBrains";
        /// <summary>
        /// Check users credentials
        /// </summary>
        public static void Go()
        {
            int i = 0;
            bool isAuthorized;
            do
            {
                CommonMethods.ColoredWriteLine("Enter login:", ConsoleColor.Yellow);
                string login = Console.ReadLine();
                CommonMethods.ColoredWriteLine("Enter password:", ConsoleColor.Yellow);
                string password = Console.ReadLine();
                isAuthorized = CheckCredentials(login, password, i);
                i++;
            } while (i < 3 && !isAuthorized);
        }
        public static bool CheckCredentials(string login, string password, int trysCount)
        {
            if (login.Equals(LOGIN) && password.Equals(PASSWORD))
            {
                CommonMethods.ColoredWriteLine("Authorized.", ConsoleColor.Green);
                return true;
            } else
            {
                CommonMethods.ColoredWriteLine($"Your login orpassword are incorrect!\nTries count: {2-trysCount}", ConsoleColor.Red);
                return false;
            }
        }
    }
}