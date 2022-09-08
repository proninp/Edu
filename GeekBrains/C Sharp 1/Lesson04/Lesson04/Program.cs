using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson04
{
    class Program
    {
        private enum Seasons
        {
            Winter = 3,
            Spring = 6,
            Summer = 9,
            Autumn = 12
        };

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.ReadLine();
        }
        /// <summary>
        /// Написать метод GetFullName(string firstName, string lastName, string
        /// patronymic), принимающий на вход ФИО в разных аргументах и возвращающий
        /// объединённую строку с ФИО.Используя метод, написать программу, выводящую в консоль
        /// 3–4 разных ФИО.

        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine(GetFullName(firstName:"Александр", patronymic:"Абрамович", lastName: "Друзь"));
            Console.WriteLine(GetFullName(lastName:"Левин", firstName:"Борис", patronymic:"Ефимович"));
            Console.WriteLine(GetFullName(lastName: "Сиднев", firstName: "Виктор", patronymic: "Владимирович"));
        }
        static string GetFullName(string firstName, string lastName, string patronymic) => string.Format($"{lastName} {firstName} {patronymic}");

        /// <summary>
        /// Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и
        /// возвращающую число — сумму всех чисел в строке.Ввести данные с клавиатуры и вывести
        /// езультат на экран.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("\nTask 2\nВведите набор чисел:\n");
            Console.WriteLine(Console.ReadLine().Where(c => char.IsDigit(c)).ToArray().Sum(c => c - 48));
        }

        /// <summary>
        /// Написать метод по определению времени года. На вход подаётся число – порядковый номер
        /// месяца.На выходе — значение из перечисления(enum) — Winter, Spring, Summer,
        /// Autumn.Написать метод, принимающий на вход значение из этого перечисления и
        /// возвращающий название времени года(зима, весна, лето, осень). Используя эти методы,
        /// ввести с клавиатуры номер месяца и вывести название времени года.Если введено
        /// некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("\nTask 3");
            Console.WriteLine("Введите номер месяца:");
            bool isDigit = int.TryParse(Console.ReadLine(), out int m);
            if (!isDigit || m < 1 || m > 12)
                Console.WriteLine("Ошибка: введите число от 1 до 12");
            else if (m == 12)
                Console.WriteLine(Seasons.Winter.ToString());
            else
                for (int i = 3; i <= (int)Seasons.Autumn; i += 3)
                    if (m < i)
                    {
                        Seasons season = (Seasons)i;
                        Console.WriteLine(season.ToString());
                        return;
                    }
        }
        /// <summary>
        /// Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
        /// </summary>
        static void Task4()
        {
            Console.WriteLine("\nTask 4\nВведите номер числа Фибоначчи:");
            string number = Console.ReadLine();
            if (!int.TryParse(number, out int fib))
                Console.WriteLine($"\"{number}\" не является числом");
            else
                Console.WriteLine((fib != 0) ? GetFib(fib) : 0);
        }
        static int GetFib(int i)
        {
            if (i == 0)
                return 0;
            int sign = (i >= 0 || Math.Abs(i) % 2 == 1) ? 1 : -1;
            return FibRecursion(Math.Abs(i)) * sign;
            
        }
        static int FibRecursion(int i) => (i < 3) ? 1 : (GetFib(i - 1) + GetFib(i - 2));
    }
}
