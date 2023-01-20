using System;

namespace Lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            Task19();
            Task21();
            Task23();
        }

        #region Task19
        /// <summary>
        /// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
        /// </summary>
        public static void Task19()
        {
            ColoredWrite(ConsoleColor.Yellow, "Задача 19");
            ColoredWrite(ConsoleColor.DarkBlue, "Введите пятизначное число:");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out int n) || input.Length != 5)
            {
                ColoredWrite(ConsoleColor.Red, "Некорректный формат числа");
                return;
            }
            if (CheckPolindrom(n))
                ColoredWrite(ConsoleColor.Green, $"{n} - палиндром");
            else
                ColoredWrite(ConsoleColor.Green, $"{n} не палиндром");
        }
        /// <summary>
        /// Проверка, является ли число палиндромом
        /// </summary>
        /// <param name="n">Число для проверки</param>
        /// <returns>Возвращает true, если палиндром</returns>
        public static bool CheckPolindrom(int n)
        {
            int polim = 0;
            int num = n;
            while(num > 0) 
            {
                polim = polim * 10 + (num % 10);
                num /= 10;
            }
            return (n == polim);
        }
        #endregion

        #region Task21
        /// <summary>
        /// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
        /// </summary>
        public static void Task21()
        {
            ColoredWrite(ConsoleColor.Yellow, "\nЗадача 21");
            Point p1 = CreatPoint("первой");
            Point p2 = CreatPoint("второй");
            double distance = Point.GetPointsDistance(p1, p2);
            ColoredWrite(ConsoleColor.Green, $"Расстояние между точками {p1.ToString()} и {p2.ToString()}: {distance.ToString("0.##")}");
        }
        /// <summary>
        /// Функция создания точки
        /// </summary>
        /// <param name="pointNumText">Текстовый идектификатор точки в нужном падеже</param>
        /// <returns>Экземпляр объекта Point</returns>
        public static Point CreatPoint(string pointNumText)
        {
            Point p = new Point();
            ColoredWrite(ConsoleColor.DarkBlue, $"Введите координаты {pointNumText} точки по X:");
            p.X = Convert.ToInt32(Console.ReadLine());
            ColoredWrite(ConsoleColor.DarkBlue, $"Введите координаты {pointNumText} точки по Y:");
            p.Y = Convert.ToInt32(Console.ReadLine());
            ColoredWrite(ConsoleColor.DarkBlue, $"Введите координаты {pointNumText} точки по Z:");
            p.Z = Convert.ToInt32(Console.ReadLine());
            ColoredWrite(ConsoleColor.Green, $"Создана точка {p.ToString()}");
            System.Console.WriteLine();
            return p;
        }
        #endregion

        #region Task23
        /// <summary>
        /// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
        /// </summary>
        public static void Task23()
        {
            ColoredWrite(ConsoleColor.Yellow, "\nЗадача 23");
            ColoredWrite(ConsoleColor.DarkBlue, "Введите число:");
            int n = Convert.ToInt32(Console.ReadLine());
            ProntCubes(n);
        }
        /// <summary>
        /// Функция для вывода числа и его куба
        /// </summary>
        /// <param name="n">Число, ограничивающее диапазон вывода кубов [1..N]</param>
        public static void ProntCubes(int n)
        {
            while(n > 0)
                System.Console.WriteLine($"|{n,2}| -> |{n * n * n--, 4}|");
        }
        #endregion

        #region Additional
        /// <summary>
        /// Вспомогательный метод для вывода цветного текста
        /// </summary>
        /// <param name="consoleColor">Цвет текста</param>
        /// <param name="text">Текст</param>
        public static void ColoredWrite(ConsoleColor consoleColor, string text)
        {
            ConsoleColor curr = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            System.Console.WriteLine(text);
            Console.ForegroundColor = curr;
        }
        #endregion
    }
}
            