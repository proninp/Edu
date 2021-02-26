using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №2
     * *Модифицировать программу нахождения минимума функции так, чтобы можно было
     * передавать функцию в виде делегата. Сделать меню с различными функциями и представьте
     * пользователю выбор для какой функции и на каком отрезке находить минимум. Используйте массив делегатов.
     */
    public delegate double Func(double x);
    class Task2
    {
        public static void Main(string[] args)
        {
            Lesson6.Support.ColoredWriteLine("Введите начальное значение аргумента для функции:", ConsoleColor.Yellow);
            double x1 = Lesson6.Support.SetDoubleParametr();
            Lesson6.Support.ColoredWriteLine("Введите конечное значение аргумента для функции:", ConsoleColor.Yellow);
            double x2 = Lesson6.Support.SetDoubleParametr();
            Lesson6.Support.ColoredWriteLine("Введите шаг увеличения аргумента:", ConsoleColor.Yellow);
            double h = Lesson6.Support.SetDoubleParametr();
            Func[] arr = new Func[5] { Math.Sin, Math.Cos, delegate (double y) { return y * y; }, Math.Sqrt , delegate (double y) { return y * y / Math.Log(y); } }; // массив делегатов
            string fileName = "..\\..\\Data\\Task2.txt";
            int i = 0;
            do
            {
                Lesson6.Support.ColoredWriteLine("Выберите функцию:\n- 1: Sin(x);\n- 2: Cos(x);\n- 3: x^2;\n- 4: Sqrt(x);\n- 5: x^2/Ln(x);\n- 0: Выход.", ConsoleColor.Yellow);
                int choice = Lesson6.Support.SetIntParametr();
                switch (choice)
                {
                    case 0:
                        i = 0;
                        break;
                    case 1:
                        i = 1;
                        break;
                    case 2:
                        i = 2;
                        break;
                    case 3:
                        i = 3;
                        break;
                    case 4:
                        i = 4;
                        break;
                    case 5:
                        i = 5;
                        break;
                    default:
                        Lesson6.Support.ColoredWriteLine("Пункт не предусматривается системой!", ConsoleColor.Red);
                        break;
                }
                if (i != 0)
                {
                    SaveFunc(fileName, arr[i-1], x1, x2, h);
                    Load(fileName, out double min, out double x);
                    Table(arr[i - 1], x1, x2);
                    Lesson6.Support.ColoredWriteLine(String.Format("Минимум:\n{0,0:0.000}", min), ConsoleColor.Cyan);
                    Lesson6.Support.ColoredWriteLine("Значение x при минимуме функции:\n" + x, ConsoleColor.Cyan);
                }
            } while (i != 0);
            Console.ReadLine();

        }
        /// <summary>
        /// Сохранение результатов выполнения функции в файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="F">Делегат</param>
        /// <param name="a">Значение "от"</param>
        /// <param name="b">Значение "до"</param>
        /// <param name="h">Шаг аргумента функции</param>
        public static void SaveFunc(string fileName, Func F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                bw.Write(x); // Значение аргумента функции
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Получение значений функции из файла, нахождение минимума
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Минимум функции</returns>
        public static void Load(string fileName, out double min, out double x)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            x = 0;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i += 2)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble(); // считываем значение минимума
                if (d < min)
                {
                    min = d;
                    x = bw.ReadDouble(); // считываем значение аргумента, при котором получили минимум функции
                    fs.Seek(-sizeof(double), SeekOrigin.Current); // возвращаем позицию в потоке назад
                }
                if (i != fs.Length / sizeof(double) - 1)
                    fs.Seek(sizeof(double), SeekOrigin.Current); // Переходим к следующему значению минимума
            }
            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Функция табулирования
        /// </summary>
        /// <param name="F">Функция</param>
        /// <param name="a">Занчение x "от"</param>
        /// <param name="b">Значение x "до"</param>
        static void Table(Func F, double a, double b)
        {
            Console.WriteLine("----X----Y--------");
            while (a <= b)
                Lesson6.Support.ColoredWriteLine(String.Format("|{0,8:0.000}|{1,8:0.000}", a, F(a++)), ConsoleColor.Cyan);
            Console.WriteLine("-------------------");
        }
    }
}
