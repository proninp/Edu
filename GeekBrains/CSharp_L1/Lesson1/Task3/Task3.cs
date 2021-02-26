using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        static void Main(string[] args)
        {
            int x1, x2, y1, y2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку x1:");
            x1 = SetValue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку y1:");
            y1 = SetValue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку x2:");
            x2 = SetValue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку y2:");
            y2 = SetValue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Расстояние между точками = {PointsDistance(x1, y1, x2, y2):F}");
            Console.ReadLine();
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
        static double PointsDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
