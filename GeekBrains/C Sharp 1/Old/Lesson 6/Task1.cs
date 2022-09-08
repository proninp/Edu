using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_6
{
    class Task1
    {
        public static void Go()
        {
            Console.WriteLine("Task 1.\n");
            Console.WriteLine("Enter \"x\" parametr (from which the function will start calculation):");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"y\" parametr (to which the function will start calculation):");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"a\" constant parametr:");
            double a = double.Parse(Console.ReadLine().Replace(".", ","));

            ObjectWithDelegate objectWD = new ObjectWithDelegate(x, y, Function1);
            objectWD.Del = Function1;
            Console.WriteLine(@"The result of the function a * x^2 is:");
            objectWD.Table(a);

            objectWD = new ObjectWithDelegate(x, y, Function2);
            Console.WriteLine(@"The result of the function a * Sin(x) is:");
            objectWD.Table(a);
        }
        public static double Function1(double a, double x) => a * x * x;
        public static double Function2(double a, double x) => a * Math.Sin(x);
    }
}
