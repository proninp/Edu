using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            // weight
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой вес в килограммах:");
            
            int weight = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (Int32.TryParse(Console.ReadLine(), out weight))
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введенное значение не является целым числом!\n Попробуйте еще раз!");
                }
            } while (true);

            // height
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой рост в метрах (разделитель - запятая):");
            float height = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (Single.TryParse(Console.ReadLine(), out height))
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введенное значение не является дробным числом!\nПопробуйте еще раз!");
                }
            } while (true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nИндекс массы тела = {weight/(height*height)}");

            Console.ReadLine();


        }
    }
}
