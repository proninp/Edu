using System;

namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Task10(random.Next(100, 1000));
            Task13(random.Next(100, 100000));
            Task15(random.Next(1, 8));
        }
        static void Task10(int a)
        {
            System.Console.WriteLine($"Task10:\nFind second digit in {a}");
            if ((a < 100) || (a > 999))
                System.Console.WriteLine($"The {a} number does not match the format.");
            else
                System.Console.WriteLine((a / 10) % 10);
        }
        static void Task13(int a)
        {
            System.Console.WriteLine($"Task13:\nFind third digit in {a}");
            if (a < 100)
                System.Console.WriteLine($"The {a} number does not match the format.");
            else
            {
                while(a > 999)
                    a /= 10;
                System.Console.WriteLine(a % 10);
            }
        }
        static void Task15(int d)
        {
            System.Console.WriteLine($"Task15: Day {d} is a weekend day:");
            if (d < 1 || d > 7)
                System.Console.WriteLine("Incorrect day.");
            else
                System.Console.WriteLine(d > 5);
        }
    }
}
