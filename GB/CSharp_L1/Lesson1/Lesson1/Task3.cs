using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Task3
    {
        public static void Go()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку x1:");
            int x1 = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку y1:");
            int y1 = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку x2:");
            int x2 = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите точку y2:");
            int y2 = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Расстояние между точками = {Additional.PointsDistance(x1, y1, x2, y2):F}");
            Console.ReadLine();
        }
    }
}