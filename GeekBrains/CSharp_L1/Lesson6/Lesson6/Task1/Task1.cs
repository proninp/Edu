using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №1
     * Изменить программу вывода функции так, чтобы можно было передавать функции типа
     * double(double,double). Продемонстрировать работу на функции с функцией a*x^2 и функцией
     * a*sin(x).
     */
    public delegate double Fun(double a, double b);
    class Task1
    {
        public static void Main(string[] args)
        {
            Lesson6.Support.ColoredWriteLine("Введите значение x1:", ConsoleColor.Yellow);
            double a = Support.SetDoubleParametr();
            Support.ColoredWriteLine("Введите значение x2:", ConsoleColor.Yellow);
            double b = Support.SetDoubleParametr();
            Support.ColoredWriteLine("Введите значение аргумента a:", ConsoleColor.Yellow);
            double c = Support.SetDoubleParametr();
            Support.ColoredWriteLine("Функция a*x^2", ConsoleColor.Yellow);
            Table(delegate (double x, double y) { return y * x * x; }, a, b, c);
            Support.ColoredWriteLine("Функция a*(sin(x))", ConsoleColor.Yellow);
            Table(delegate (double x, double y) { return y * Math.Sin(x); }, a, b, c);
            Console.ReadLine();
        }
        /// <summary>
        /// Функция табулирования
        /// </summary>
        /// <param name="F">Функция</param>
        /// <param name="a">Занчение x "от"</param>
        /// <param name="b">Значение x "до"</param>
        /// <param name="c">Аргумент</param>
        static void Table(Fun F, double a, double b, double c)
        {
            Console.WriteLine("----X----Y--------");
            while(a <= b)
                Support.ColoredWriteLine(String.Format("|{0,8:0.000}|{1,8:0.000}", a, F(a++, c)), ConsoleColor.Cyan);
            Console.WriteLine("-------------------");
        }
    }
}
