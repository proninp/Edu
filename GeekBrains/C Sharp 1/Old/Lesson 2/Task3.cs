using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 3
     * Calculate all odd positive numbers sum
     */
    class Task3
    {
        public static void Go()
        {
            int sum = 0;
            int a;
            do
            {
                CommonMethods.ColoredWriteLine("Enter your number:", ConsoleColor.Yellow);
                a = CommonMethods.SetIntParametr();
                sum += (a > 0) && (a % 2 != 0) ? a : 0;
            } while (a != 0);
            CommonMethods.ColoredWriteLine($"Sum is:\n{sum}", ConsoleColor.Cyan);
        }
    }
}
