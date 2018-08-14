using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Support
    {
        static void Main(string[] args)
        {

        }
        /// <summary>
        /// Метод для получения целого числа, введённого пользователем в консоли
        /// </summary>
        /// <returns>Целое число</returns>
        public static int SetIntParametr()
        {
            do
            {
                String str = Console.ReadLine();
                if (Int32.TryParse(str, out int a) && str.Length != 0)
                    return a;
                else
                    ColoredWriteLine("Введенное значение не является целым числом!\nПопробуйте еще раз!", ConsoleColor.Red);
            } while (true);
        }
        /// <summary>
        /// Метод для получения дробного числа, введённого пользователем в консоли
        /// </summary>
        /// <returns>Дробное число</returns>
        public static double SetDoubleParametr()
        {
            do
            {
                String str = Console.ReadLine();
                if (Double.TryParse(str, out double a) && str.Length != 0)
                    return a;
                else
                    ColoredWriteLine("Введенное значение не является дробным числом!\nПопробуйте еще раз!", ConsoleColor.Red);
            } while (true);
        }
        /// <summary>
        /// Метод для вывода цветного текста в консоль с последующим переводом каретки на новую строку
        /// </summary>
        /// <param name="str">Текст, который необходимо вывести на экран</param>
        /// <param name="consoleColor">Цвет, который будет использоваться при выводе</param>
        public static void ColoredWriteLine(string str, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Метод для вывода цветного текста в консоль без перевода каретки на новую строку
        /// </summary>
        /// <param name="str">Текст, который необходимо вывести на экран</param>
        /// <param name="consoleColor">Цвет, который будет использоваться при выводе</param>
        public static void ColoredWrite(string str, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
