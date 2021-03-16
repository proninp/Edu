using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 7
     * a) Recursive method that will write numbers from a to b (a<b);
     * b) *Recursive method, that will calc numbers from a to b.
     */
    class Task7
    {
        public static void Go()
        {
            CommonMethods.ColoredWriteLine("Enter first number:", ConsoleColor.Yellow);
            int a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Enter second number:", ConsoleColor.Yellow);
            int b = CommonMethods.SetIntParametr();
            Swap(ref a, ref b);
            RecursivePrint(a, b);
            CommonMethods.ColoredWriteLine($"Calc sum from {a} to {b} is {RecursiveSum(a, b)}.", ConsoleColor.Cyan);
        }
        public static void RecursivePrint(int a, int b)
        {
            CommonMethods.ColoredWrite($"{a}{((a != b) ? ", " : "\n")}", ConsoleColor.Cyan);
            if (a == b)
                return;
            RecursivePrint(++a, b);
            
        }
        public static int RecursiveSum(int a, int b) => (b == a) ? a : b + RecursiveSum(a, --b);
        public static void Swap(ref int a, ref int b)
        {
            if (a > b)
            {
                a += b;
                b = a - b;
                a -= b;
            }
        }
    }
}
