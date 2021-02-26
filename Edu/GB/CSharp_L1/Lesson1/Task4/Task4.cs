using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите первую переменную \"x\":");
            x = SetValue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите вторую переменную \"y\":");
            y = SetValue();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Меняем местами первым способом:");
            Swap1(ref x, ref y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"x = {x}\ny = {y}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Меняем обратно вторым способом:");
            Swap1(ref x, ref y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"x = {x}\ny = {y}");

            Console.ReadLine();

        }
        static void Swap1(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        static void Swap2(int a, int b)
        {
            a = a + b;
            b = a ^ b;
            a = a ^ b;
        }
        static int SetValue()
        {
            do
            {
                int a = 0;
                Console.ForegroundColor = ConsoleColor.White;
                if (Int32.TryParse(Console.ReadLine(), out a))
                    return a;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введенное значение не является целым числом!\nПопробуйте еще раз!");
                }
            } while (true);
        }
    }
}
