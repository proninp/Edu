using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Task4
    {
        public static void Go()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите первую переменную \"x\":");
            int x = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите вторую переменную \"y\":");
            int y = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Меняем местами первым способом:");
            Additional.Swap1(ref x, ref y);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"x = {x}\ny = {y}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Меняем обратно вторым способом:");
            Additional.Swap1(ref x, ref y);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"x = {x}\ny = {y}");

            Console.ReadLine();

        }
    }
}