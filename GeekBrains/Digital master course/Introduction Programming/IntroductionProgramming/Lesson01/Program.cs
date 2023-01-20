using System;

namespace Lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int min = -100, max = 100;
            int a = random.Next(min, max);
            int b = random.Next(min, max);
            int c = random.Next(min, max);

            System.Console.WriteLine($"Task 2:\nMax from: {a}, {b}");
            System.Console.WriteLine(Task2(a, b));
            System.Console.WriteLine($"\nTask 4:\nMax from: {a}, {b}, {c}");
            System.Console.WriteLine(Task4(a, b, c));
            System.Console.WriteLine($"\nTask 6:\n{a} % 2");
            System.Console.WriteLine(Task6(a));
            int d = random.Next(2, max);
            System.Console.WriteLine($"\nTask 8:\n%2 from 1 to {d}");
            Task8(d);
            System.Console.ReadLine();
        }
        static int Task2(int a, int b) => (a > b) ? a : b;
        static int Task4(int a, int b, int c) => Task2(Task2(a, b), c);
        static bool Task6(int a) => a % 2 == 0;
        static void Task8(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                if (Task6(i))
                    System.Console.Write($"[{i}] ");
            }
        }
    }
}
