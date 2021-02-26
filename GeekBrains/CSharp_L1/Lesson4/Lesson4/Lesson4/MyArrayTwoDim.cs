using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель: 
     * Пронин Павел
     * 
     * Класс для работы с двумерным массивом
     */
    class MyArrayTwoDim
    {
        static char delimiter = '\t';
        int[,] a;

        #region Свойства
        /// <summary>
        /// Минимальный элемент массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }
        /// <summary>
        /// Максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }
        /// <summary>
        /// Кол-во положительныъ элеентов массива
        /// </summary>
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > 0) count++;
                return count;
            }
        }
        /// <summary>
        /// Значение среднего элемента массива
        /// </summary>
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum += a[i, j];
                return sum / a.GetLength(0) / a.GetLength(1);
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, задающий размер массива и значение его элементов
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="el">Значение элементов массива</param>
        public MyArrayTwoDim(int n, int el)
        {
            a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = el;
        }
        /// <summary>
        /// Конструктор, задающий размер массива и заполняющий его случайными элементами
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="min">Нижняя граница значения для диапазона случайных чисел включительно</param>
        /// <param name="max">Верхняя граница значения для диапазона случайных чисел не включительно</param>
        public MyArrayTwoDim(int n, int min, int max)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(min, max);
        }
        /// <summary>
        /// Конструктор, создающий массив на основании данных, загруженных из файла
        /// </summary>
        /// <param name="fileName"></param>
        public MyArrayTwoDim(string fileName)
        {
            string s = "";
            if (!File.Exists(fileName))
                CommonMethods.ColoredWriteLine("Файл не существует!", ConsoleColor.Red);
            else
            {
                s = File.ReadAllText(fileName);
                string[] sa = s.Split('\n');
                a = new int[sa.Length, sa[0].Split(delimiter).Length];
                for (int i = 0; i < sa.Length; i++)
                {
                    for (int j = 0; j < sa[i].Split(delimiter).Length; j++)
                        int.TryParse(sa[i].Split(delimiter)[j], out a[i, j]);
                }
            }
        }


        #endregion

        #region Методы
        /// <summary>
        /// Вывод массива в виде строки
        /// </summary>
        /// <returns>Строковое представление массива</returns>
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + delimiter.ToString();
                s += ((i != a.GetLength(0) - 1) ? "\n" : ""); //Если последняя строка, не ставим перенос
            }
            return s;
        }
        /// <summary>
        /// Сумма элементов массива
        /// </summary>
        /// <returns>Сумма</returns>
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];
            return sum;
        }
        /// <summary>
        /// Сумма всех элементов массива, больше заданного
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public int Sum(int constraint)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > constraint)
                        sum += a[i, j];
            return sum;
        }
        /// <summary>
        /// Метод, передающий индекс последнего вхождения элемента массива с максимальным значением
        /// </summary>
        /// <param name="ind">Индекс</param>
        public void IndexOfMax(out int[] ind)
        {
            ind = new int[2];
            int max = Max;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] == max)
                    {
                        ind[0] = i+1;
                        ind[1] = j+1;
                    }
        }
        /// <summary>
        /// Запись массива в файл
        /// </summary>
        /// <param name="fileName">Полное имя файла</param>
        public void WriteToFile(string fileName)
        {
            if (a.Length != 0)
            {
                if (!File.Exists(fileName))
                    File.Create(fileName).Dispose();
                StreamWriter sw = new StreamWriter(fileName, false);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        sw.Write(a[i, j] + ((j == a.GetLength(1)-1) ? "" : delimiter.ToString())); // Не добавляем разделитель, если последний элемент в строке
                    if (i != a.GetLength(0)-1) sw.Write("\n");
                }
                sw.Close();
            }
        }
        #endregion
    }
}