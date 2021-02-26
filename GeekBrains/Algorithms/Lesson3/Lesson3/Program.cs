using System;

namespace Lesson3
{
    /*
     * Dev. by Pronin P.S.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Console.ReadLine();
        }

        #region Task1
        /// <summary>
        /// 1. Попробовать оптимизировать пузырьковую сортировку.
        /// Сравнить количество операций сравнения оптимизированной и не оптимизированной программы.
        /// Написать функции сортировки, которые возвращают количество операций.
        /// </summary>
        static void Task1()
        {
            #region Task Description
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Попробовать оптимизировать пузырьковую сортировку.\n" +
                "Сравнить количество операций сравнения оптимизированной и не оптимизированной программы.\n" +
                "Написать функции сортировки, которые возвращают количество операций.");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            int[] a = FillArr(200, 0, 1001);
            int[] b = CopyArr(a);
            //PrintArr(a);
            Console.WriteLine("Операций сравнения для обычной сортировки Пузырьком массива с количеством элементтов {0}:\n{1}", a.Length, SimpleBubbleSort(a));
            //PrintArr(a);
            Console.WriteLine("Операций сравнения для обычной сортировки Пузырьком массива с количеством элементтов {0}:\n{1}", b.Length, OptimizedBubbleSort(b));
            //PrintArr(b);
            Console.WriteLine();
        }
        /// <summary>
        /// Неоптимизированный Пузырёк
        /// </summary>
        /// <param name="a"></param>
        static long SimpleBubbleSort(int[] a)
        {
            long c = 0;
            for (int i = 0; i < a.Length; i++)
                for (int j = 1; j < a.Length; j++)
                {
                    c++; // Символично
                    if (a[j] < a[j - 1]) Swap(ref a[j], ref a[j - 1]);
                }
            return c;
        }
        /// <summary>
        /// Оптимизированный Пузырёк
        /// </summary>
        /// <param name="a"></param>
        static long OptimizedBubbleSort(int[] a)
        {
            long c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                bool isSort = true;
                for (int j = 1; j < a.Length - i; j++) { c++; if (a[j] < a[j - 1]) Swap(ref a[j], ref a[j - 1], ref isSort); }
                if (isSort) return c;
            }
            return c;
        }
        #endregion

        #region Task2
        /// <summary>
        /// 2. *Реализовать шейкерную сортировку.
        /// </summary>
        static void Task2()
        {
            #region Task Description
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Реализовать шейкерную сортировку.");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            int[] a = FillArr(200, 0, 1001);
            //PrintArr(a);
            Console.WriteLine("Операций сравнения для Шейкерной сортировки массива с количеством элементтов {0}:\n{1}", a.Length, ShakerSort(a));
            //PrintArr(a);
            Console.WriteLine();
        }
        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="a"></param>
        static long ShakerSort(int[] a)
        {
            bool isSort = true;
            long c = 0;
            int fe = 0; // первый
            int le = 0; // последний
            do
            {
                isSort = true;
                for (int i = 1 + fe; i < a.Length - le; i++)
                {
                    c++;
                    if (a[i] < a[i - 1]) Swap(ref a[i], ref a[i - 1], ref isSort);
                }
                le++;
                for (int i = a.Length - 1 - le; i > 0 + fe; i--)
                {
                    c++;
                    if (a[i] < a[i - 1]) Swap(ref a[i], ref a[i - 1], ref isSort);
                }
                fe++;
            } while (!isSort);
            return c;
        }
        #endregion

        #region Task3
        /// <summary>
        /// 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.
        /// Функция возвращает индекс найденного элемента или -1, если элемент не найден.
        /// </summary>
        static void Task3()
        {
            #region Task Description
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.\n" +
                "Функция возвращает индекс найденного элемента или -1, если элемент не найден.");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            int[] a = FillArr(20, 0, 101);
            ShakerSort(a);
            Console.WriteLine("Отсортированный массив:");
            PrintArr(a);
            Console.WriteLine("Введите число для поиска:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Индекс:\n{0}", BinarySearch(a, n));
            Console.WriteLine();
        }
        /// <summary>
        /// Бинарный поиск
        /// </summary>
        /// <param name="a">Массив</param>
        /// <param name="n">Искомое число</param>
        /// <returns></returns>
        static int BinarySearch(int[] a, int n)
        {
            int l = 0;
            int r = a.Length - 1;
            int m = l + (r - l) / 2;
            while (a[m] != n && l <= r)
            {
                if (a[m] > n) r = m - 1;
                if (a[m] < n) l = m + 1;
                m = l + (r - l) / 2;
            }
            return (a[m] == n) ? m : -1;
        }
        #endregion

        #region Task4
        /// <summary>
        /// 4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
        /// </summary>
        static void Task4()
        {
            #region Task Description
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.");
            #endregion

            int[] a = new int[50];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Кол-во эл-ов:\t");
            Console.Write("Пузырьком\t");
            Console.Write("Пузырьком Уск.\t");
            Console.Write("Выбором\t\t");
            Console.Write("Шейкерная\t");
            Console.Write("Ввставками\t");
            Console.Write("O(n^2)\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 2; i < a.Length; i++)
            {
                int n = 100 * i;
                int[] b = FillArr(n, 0, n);
                int[] c = CopyArr(b);
                int[] d = CopyArr(b);
                int[] e = CopyArr(b);
                int[] f = CopyArr(b);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(n + "\t\t");
                Console.ForegroundColor = ConsoleColor.White;

                #region Simple Bubble Sort
                long count = SimpleBubbleSort(b);
                int dig = NumberSimplify(ref count);
                Console.Write(count + " * 10^" + dig + "\t");
                #endregion

                #region Optimized Bubble Sort
                count = OptimizedBubbleSort(c);
                dig = NumberSimplify(ref count);
                Console.Write(count + " * 10^" + dig + "\t");
                #endregion

                #region Selection Sort
                count = SelectionSort(e);
                dig = NumberSimplify(ref count);
                Console.Write(count + " * 10^" + dig + "\t");
                #endregion

                #region Shaker Sort
                count = ShakerSort(d);
                dig = NumberSimplify(ref count);
                Console.Write(count + " * 10^" + dig + "\t");
                #endregion

                #region Insertion Sort
                count = InsertionSort(f);
                dig = NumberSimplify(ref count);
                Console.Write(count + " * 10^" + dig + "\t");
                #endregion

                #region Asymptotic Analysis
                long oCount = n * n;
                int oDig = NumberSimplify(ref oCount);
                Console.Write(oCount + " * 10^" + oDig);
                #endregion
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long InsertionSort(int[] a)
        {
            long c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int t = a[i];
                int j = i;
                while (j > 0 && a[j - 1] > t) { c++; Swap(ref a[j], ref a[j - 1]); j--; }
            }
            return c;
        }
        /// <summary>
        /// Сортировка выбором
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long SelectionSort(int[] a)
        {
            long c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    c++;
                    if (a[j] < a[min]) min = j;
                }
                Swap(ref a[i], ref a[min]);
            }
            return c;
        }
        /// <summary>
        /// Приведение числа к упрощенному виду
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static int NumberSimplify(ref long num)
        {
            int d = 0;
            while (num > 999)
            {
                num /= 10;
                d++;
            }
            return d;

        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Обмен значениями
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(ref int a, ref int b)
        {
            int t = 0;
            t = b;
            b = a;
            a = t;
        }
        /// <summary>
        /// Обмен значениями с флагом
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(ref int a, ref int b, ref bool flag)
        {
            int t = 0;
            t = b;
            b = a;
            a = t;
            flag = false;
        }
        /// <summary>
        /// Заполнение массива рандомными числами
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="min">Минимальный элемент</param>
        /// <param name="max">Максимальный элемент</param>
        /// <returns>Заполненный массив</returns>
        static int[] FillArr(int n, int min, int max)
        {
            int[] a = new int[n];
            Random r = new Random();
            int i = 0;
            while(i < n)
            {
                a[i] = r.Next(min, max);
                i++;
            }
            return a;
        }
        /// <summary>
        /// Копирует массив без ссылки
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static int[] CopyArr(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                b[i] = a[i];
            return b;
        }
        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="a"></param>
        static void PrintArr(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write("[" + a[i] + "]; ");
            Console.WriteLine("\n");
        }
        #endregion
    }
}
