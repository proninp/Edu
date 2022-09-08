using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 1
     * Write method, that will return minimum of three numbers.
     */
    class Task1
    {
        /// <summary>
        /// Minimum of three numbers
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Enter first number:", ConsoleColor.Yellow);
            int a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Enter second number:", ConsoleColor.Yellow);
            int b = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Enter third number:", ConsoleColor.Yellow);
            int c = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine($"Minimum of {a}, {b} and {c} is:\n{GetMin(a, b, c)}", ConsoleColor.Cyan);
        }

        static int GetMin(int a, int b, int c) => GetMin(GetMin(a, b), c);
        static int GetMin(int a, int b) => a < b ? a : b;

    }
}
