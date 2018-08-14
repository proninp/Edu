using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Task2
    {
        public static void Go()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой вес в килограммах:");

            int w = Additional.SetIntParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой рост в метрах (разделитель - запятая):");
            float h = Additional.SetFloatParametr();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nИндекс массы тела = {w / (h * h):F}");

            Console.ReadLine();
        }
    }
}