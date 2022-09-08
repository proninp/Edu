using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Console.ReadLine();
        }
        
        #region Task 1
        /// <summary>
        /// Enter yor name, surnmae, age, height and weight
        /// </summary>
        static void Task1()
        {
            MyClass.MyPrint("Task 1.");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter your height:");
            string height = Console.ReadLine();
            Console.WriteLine("Enter your weight:");
            string weight = Console.ReadLine();

            Console.WriteLine(name + " " + surname + ", " + age + " y.o., h: " + height + ", w: " + weight);
            Console.WriteLine("{0} {1}, {2} y.o., h: {3}, w: {4}", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname}, {age} y.o., h: {height}, w: {weight}");
        }
        #endregion
        
        #region Task 2
        /// <summary>
        /// Calculate your Body Weight Index
        /// </summary>
        static void Task2()
        {
            MyClass.MyPrint("\nTask 2.");
            Console.WriteLine("Enter your height in meters:");
            string height = Console.ReadLine();
            height = height.Contains(".") ? height.Replace('.', ',') : height;
            double h = Convert.ToDouble(height);
            Console.WriteLine("Enter your weight in kilos:");
            string weight = Console.ReadLine();
            weight = weight.Contains(".") ? weight.Replace('.', ',') : weight;
            double w = Convert.ToDouble(weight);
            Console.WriteLine("Your body weight index is: {0:0.00}", w / (h * h));
        }
        #endregion
        
        #region Task 3
        /// <summary>
        /// Calculate Distance
        /// </summary>
        static void Task3()
        {
            MyClass.MyPrint("\nTask 3.");
            Console.WriteLine("Enter first point of X coordinate in integer format:");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter first point of Y coordinate in integer format:");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second point of X coordinate in integer format:");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second point of Y coordinate in integer format:");
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Distance between points is: {0:F2}", MyClass.CalculateDistanceBetweenPoints(x1, y1, x2, y2));
        }
        #endregion
        
        #region Task 4
        /// <summary>
        /// Swap 2 variables
        /// </summary>
        static void Task4()
        {
            MyClass.MyPrint("\nTask 4.");
            Console.WriteLine("Enter first integer variable:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second integer variable:");
            int b = Convert.ToInt32(Console.ReadLine());
            // First swap method - with third variable
            //MyClass.Swap1(a, b);

            // Second swap method - without third variable
            MyClass.Swap2(ref a, ref b);
            Console.WriteLine("a: {0}, b: {1}.", a, b);
        }
        #endregion

        #region Task 5
        static void Task5()
        {
            Console.WriteLine("\nTo start Task 5 press any key");
            Console.ReadLine();
            string[] text = new string[] { "Hello!", "My name is #username!", "I live in #city." };

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < text.GetLength(0); i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - text[i].Length / 2, Console.CursorTop);
                for (int j = 0; j < text[i].Length; j++)
                {
                    Console.Write(text[i][j]);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write("\n");
            }
        }
        #endregion
    }
}
