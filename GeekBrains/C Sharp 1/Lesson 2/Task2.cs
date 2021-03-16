using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 2
     * Write method to count number digits
     */
    class Task2
    {
        /// <summary>
        /// Method will request any number and returns number digits count
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Enter your number:", ConsoleColor.Yellow);
            double a = CommonMethods.SetDoubleParametr();
            CommonMethods.ColoredWriteLine($"Digits count in number {a}:\n{a.ToString().Replace(",", "").Length}", ConsoleColor.Cyan);
        }
    }
}
