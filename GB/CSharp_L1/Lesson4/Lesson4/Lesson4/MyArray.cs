using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель: 
     * Пронин Павел
     * 
     * Класс для работы с одномерным массивом
     */
    public class MyArray
    {
        int[] a;

        #region Свойства
        /// <summary>
        /// Максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        /// <summary>
        /// Минимальный элемент массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        /// <summary>
        /// Количество чисел в массиве, больше ноля
        /// </summary>
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        /// <summary>
        /// Сумма элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                    sum += a[i];
                return sum;
            }
        }
        /// <summary>
        /// Количество максимальных элементов
        /// </summary>
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max)
                        count++;
                return count;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, заполняющий элементы массива указанным значением
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="el">Значение элементов массива</param>
        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }

        /// <summary>
        /// Создание массива и заполнение его случайными числами от min до max
        /// </summary>
        /// <param name="n">Кол-во элементов массива</param>
        /// <param name="min">Минимальное значение элементов</param>
        /// <param name="max">Максимальное значение элементов</param>
        //public MyArray(int n, int min, int max)
        //{
        //    a = new int[n];
        //    Random r = new Random();
        //    for (int i = 0; i < n; i++)
        //        a[i] = r.Next(min, max);
        //}

        /// <summary>
        /// Конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="start">Значение начального элемента</param>
        /// <param name="step">Шаг изменения значений</param>
        public MyArray(int n, int startEl, int step)
        {
            a = new int[n];
            if (n != 0)
                a[0] = startEl;
            for (int i = 1; i < a.Length; i++)
                a[i] = a[i - 1] + step;
        }
        /// <summary>
        /// Конструктор, создающий массив на основании данных, загруженных из файла
        /// </summary>
        /// <param name="fileName"></param>
        public MyArray(string fileName)
        {
            // Можно было бы записать в первую строку файла кол-во эл-ов массива, 
            // Или переписать содержание файла в строку и потом работать с ней,
            // Но для разнообразия воспользуемся объектом List
            List<int> list = new List<int>();
            if (!File.Exists(fileName))
                CommonMethods.ColoredWriteLine("Файл не существует!", ConsoleColor.Red);
            else
            {
                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                    if (int.TryParse(sr.ReadLine(), out int el))
                        list.Add(el);
                sr.Close();
                if (list.Count != 0)
                    a = list.ToArray();
            }
        }
        #endregion

        #region Методы
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
                for (int i = 0; i < a.Length; i++)
                    sw.WriteLine(a[i]);
                sw.Close();
            }
        }
        /// <summary>
        /// Метод, меняющий знак у всех элементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = -a[i];
        }
        /// <summary>
        /// Умножение каждого элемента массива на заданное число
        /// </summary>
        /// <param name="x"></param>
        public void Multi(int x)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= x;
        }
        /// <summary>
        /// Вывод в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s += v + " ";
            return s;
        }
        #endregion
    }
}