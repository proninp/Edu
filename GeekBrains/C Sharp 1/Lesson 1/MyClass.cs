using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    /// <summary>
    /// Task 6 class
    /// </summary>
    class MyClass
    {
        #region Get numbers from console
        /// <summary>
        /// Check for integer numbers entering
        /// </summary>
        /// <returns></returns>
        public static int SetIntParametr()
        {
            do
            {
                int a = 0;
                Console.ForegroundColor = ConsoleColor.White;
                String str = Console.ReadLine();
                if (Int32.TryParse(str, out a) && str.Length != 0)
                    return a;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Entered number is not integer\nTry again.");
                }
            } while (true);
        }
        /// <summary>
        /// Check for float numbers entering
        /// </summary>
        /// <returns></returns>
        public static float SetFloatParametr()
        {
            float a = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                String str = Console.ReadLine();
                if (Single.TryParse(str, out a) && str.Length != 0)
                    return a;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enered number is not float!\nTry again.");
                }
            } while (true);
        }
        #endregion

        #region Calculate Distance between points
        /// <summary>
        /// Special method to calculate distance between points
        /// </summary>
        /// <param name="x1">X-coordinate for first point</param>
        /// <param name="y1">Y-coordinate for first point</param>
        /// <param name="x2">X-coordinate for second point</param>
        /// <param name="y2">Y-coordinate for second point</param>
        /// <returns></returns>
        public static double CalculateDistanceBetweenPoints(int x1, int y1, int x2, int y2) => 
            Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        #endregion

        #region Swap two integer variables
        /// <summary>
        /// With third var
        /// </summary>
        /// <param name="a">First var</param>
        /// <param name="b">Second var</param>
        public static void Swap1(ref int a, ref int b)
        {
            int c = b;
            b = a;
            a = c;
        }
        /// <summary>
        /// Without third var
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap2(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        #endregion

        #region Console print
        /// <summary>
        /// Colored print method
        /// </summary>
        /// <param name="text">Text to print</param>
        public static void MyPrint(string text)
        {
            if (text.Length == 0)
                return;
                
            Console.ForegroundColor = ConsoleColor.Yellow;            
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}
