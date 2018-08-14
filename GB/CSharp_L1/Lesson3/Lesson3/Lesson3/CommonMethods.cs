using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Класс предназначен для дополнительных методов,
     * которые используются в работе, как вспомогательные инструменты.
     */
    class CommonMethods
    {
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
        /// Метод для получения целого числа, неравного нулю, введённого пользователем в консоли
        /// </summary>
        /// <returns>Целое число</returns>
        public static int SetIntParametrExeptZero()
        {
            do
            {
                String str = Console.ReadLine();
                if (Int32.TryParse(str,out int a) && str.Length != 0 && a != 0)
                    return a;
                else

                    ColoredWriteLine(((a != 0) ? "Введенное значение не является целым числом!\nПопробуйте еще раз!" : "Введенное значение не может быть равным нулю!"), ConsoleColor.Red);
            } while (true);
        }
        /// <summary>
        /// Метод для получения целого числа, введённого пользователем в консоли,
        /// с использованием try{ } catch{ } конструкции
        /// </summary>
        /// <returns>Целое число</returns>
        public static int SetIntParametrExProcessing()
        {
            int a = 0;
            bool isRepeat;
            do
            {
                try
                {
                    isRepeat = false;
                    a = Int32.Parse(Console.ReadLine());
                } catch (Exception ex)
                {
                    ColoredWriteLine(ex.Message, ConsoleColor.Red);
                    isRepeat = true;
                }
            } while (isRepeat);
            return a;
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
        /// <summary>
        /// Приветсвие - вывод в центре экрана с паузой
        /// </summary>
        public static void CenterOutput()
        {
            string[] a = new string[] {
                $"Вэлкам, {(Environment.UserName.Equals(String.Empty) ? "Username" : Environment.UserName)}!",
                "Это третье ДЗ Павла Пронина!",
                "Нажми любую клавишу!",
            };
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2); // Чтобы ниже получить позицию курсора по вертикали из буфера
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - a[i].Length / 2, Console.CursorTop);
                for (int j = 0; j < a[i].Length; j++)
                {
                    ColoredWrite(a[i][j].ToString(), ConsoleColor.Magenta);
                    System.Threading.Thread.Sleep(30);
                }
                Console.Write("\n");
            }
            Console.ReadLine();
            Console.Clear();
        }
        /// <summary>
        /// Функция смены значений местами в случае некорректного ввода
        /// </summary>
        /// <param name="a">Первый аргумент</param>
        /// <param name="b">Второй аргумент</param>
        public static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
    }
}