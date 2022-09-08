using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Additional methods to use with main hw
     */

    class CommonMethods
    {
         /// <summary>
         /// Check and get integer number
         /// </summary>
         /// <returns>integer number</returns>
        public static int SetIntParametr()
        {
            int a = 0;
            do
            {
                String str = Console.ReadLine();
                if (Int32.TryParse(str, out a) && str.Length != 0)
                    return a;
                else
                    ColoredWriteLine("Entered number is not integer!\nTry again!", ConsoleColor.Yellow);
            } while (true);
        }
        /// <summary>
        /// Check and get decimal number
        /// </summary>
        /// <returns>Decimal</returns>
        public static double SetDoubleParametr()
        {
            double a = 0;
            do
            {
                String str = Console.ReadLine();
                if (Double.TryParse(str, out a) && str.Length != 0)
                    return a;
                else
                    ColoredWriteLine("Entered number is not decimal!\nTry again!", ConsoleColor.Yellow);
            } while (true);
        }
        public static void ColoredWriteLine(string str, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ColoredWrite(string str, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CenterOutput()
        {
            string[] a = new string[] {
                $"Wellcome, {(Environment.UserName.Equals(String.Empty) ? "Username" : Environment.UserName)}!",
                "Press any key.",
            };
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2); // To get vertical cusrsor position
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - a[i].Length / 2, Console.CursorTop);
                for (int j = 0; j < a[i].Length; j++)
                {
                    ColoredWrite(a[i][j].ToString(), ConsoleColor.Magenta);
                    System.Threading.Thread.Sleep(50);
                }
                Console.Write("\n");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
