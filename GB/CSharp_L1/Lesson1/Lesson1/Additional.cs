using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Additional
    {
        #region Текстовые констакты (это не точно)
        public static String task1Text = "Написать программу “Анкета”.\n" +
            "Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).\n" +
            "В результате вся информация выводится в одну строчку.";
        public static String task2Text = "Ввести вес и рост человека.\n" +
            "Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.";
        public static String task3Text = "Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2\n" +
            "по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).\n" +
            "Вывести результат используя спецификатор формата .2f (с двумя знаками после запятой);";
        public static String task4Text = "Написать программу обмена значениями двух переменных.";
        public static String task5Text = "Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.";
        #endregion

        #region Методы для получения значений из консоли
        // целые
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
                    Console.WriteLine("Введенное значение не является целым числом!\nПопробуйте еще раз!");
                }
            } while (true);
        }
        // вещественные
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
                    Console.WriteLine("Введенное значение не является дробным числом!\nПопробуйте еще раз!");
                }
            } while (true);
        }
        #endregion

        #region Расстояние между точками
        public static double PointsDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        #endregion

        #region Методы для смены значений двух переменных
        public static void Swap1(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        public static void Swap2(int a, int b)
        {
            a = a + b;
            b = a ^ b;
            a = a ^ b;
        }
        #endregion

        #region Вывод в центре экрана с паузой
        public static void CenterOutput()
        {
            string[] a = new string[] { "Приветствую!" , "Меня зовут #username!", "Я проживаю в городе #city." };

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - a[i].Length / 2, Console.CursorTop);
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write(a[i][j]);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write("\n");
            }

            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }
}