using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Task1
    {
        public static void Go()
        {
            // name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите своё имя:");

            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine();
            // surname
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свою фамилию:");

            Console.ForegroundColor = ConsoleColor.White;
            string surname = Console.ReadLine();
            // age
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой возраст:");

            Console.ForegroundColor = ConsoleColor.White;
            int age = Additional.SetIntParametr();
            // height
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой рост (см):");

            Console.ForegroundColor = ConsoleColor.White;
            int height = Additional.SetIntParametr();
            // weight
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите свой вес (кг):");

            Console.ForegroundColor = ConsoleColor.White;
            int weight = Additional.SetIntParametr();

            // output
            Console.WriteLine("\nВывод Склеиванием:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Приветствую, " + surname + " " + name + "!\nЭто программа \"Анкета\"!\nВаш возраст:\t" + age + "\nВаш рост:\t" + height + "\nВаш вес:\t" + weight);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nФорматированный вывод:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Приветствую, {0} {1}!\nЭто программа \"Анкета\"!\nВаш возраст:\t{2}\nВаш рост:\t{3} \nВаш вес:\t{4}", surname, name, age, height, weight);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nВывод со знаком $:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Приветствую, {surname} {name}!\nЭто программа \"Анкета\"!\nВаш возраст:\t{age}\nВаш рост:\t{height} \nВаш вес:\t{weight}");

            Console.ReadLine();
        }
    }
}