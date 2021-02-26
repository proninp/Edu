using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    /*
     * Dev. by Pronin P.S.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[20];

            FillArray(a);

            Task1(CopyArr(a));

            Task2(CopyArr(a));

            Task3(CopyArr(a));

            Task5();

            Console.ReadLine();
        }

        #region Task1
        /// <summary>
        /// Counting Sort
        /// </summary>
        /// <param name="a"></param>
        static void Task1(int[] a)
        {
            Console.WriteLine("##################################");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 1. Counting Sort Realization\n");
            long steps = CountingSort(a);
            Console.WriteLine("Steps Count: {0}", steps);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("##################################");
        }
        static long CountingSort(int[] a)
        {
            long steps = 0;
            int[] c = new int[a.Length];
            for (int i = 0; i < c.Length; i++) { c[a[i]]++; steps++; }
            int n = 0;
            for (int i = 0; i < c.Length; i++)
                for (int j = 0; j < c[i]; j++)
                    a[n++] = i;
            return steps;
        }
        #endregion

        #region Task2
        /// <summary>
        /// Quick Sort Realization
        /// </summary>
        /// <param name="a"></param>
        static void Task2(int[] a)
        {
            Console.WriteLine("\n\n##################################");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 2. Quick Sort Realization\n");
            long steps = QuickS(0, a.Length - 1, a, 0);
            Console.WriteLine("Steps Count: {0}", steps);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("##################################");
        }
        static long QuickS(int start, int end, int[] a, long steps)
        {
            int l = start;
            int r = end;
            int opp = (l + r) / 2;
            while(l <= r)
            {
                while (a[l] < a[opp]) { l++; steps++; }
                while (a[r] > a[opp]) { r--; steps++; }
                if (l <= r)
                {
                    steps++;
                    Swap(ref a[l++], ref a[r--]);
                }
            }
            if (start < r) QuickS(start, r, a, steps);
            if (end > l) QuickS(l, end, a, steps);
            return steps;
        }
        #endregion

        #region Task3
        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="a"></param>
        static void Task3(int[] a)
        {
            Console.WriteLine("\n\n##################################");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 3. Merge Sort Realization\n");
            Console.WriteLine("Steps Count: {0}", MergeSort(a, 0, a.Length - 1, 0));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("##################################");
        }
        static long MergeSort(int[] a, int l, int r, long steps)
        {
            if (l < r)
            {
                steps++;
                int m = (l + r) / 2;
                steps = MergeSort(a, l, m, steps);
                steps = MergeSort(a, m + 1, r, steps);
                steps = Merge(a, l, m, r, steps);
            }
            return steps;
        }
        static long Merge(int[] a, int l, int m, int r, long steps)
        {
            steps++;
            int[] aL = new int[m - l + 1];
            int[] aR = new int[r - m];
            for (int i = 0; i < aL.Length; i++) aL[i] = a[l + i];
            for (int i = 0; i < aR.Length; i++) aR[i] = a[m + 1 + i];
            int j = 0, k = 0, n = l;
            while (j < aL.Length && k < aR.Length)
            {
                if (aL[j] <= aR[k]) a[n++] = aL[j++];
                else a[n++] = aR[k++];
            }
            while (j < aL.Length) a[n++] = aL[j++];
            while (k < aR.Length) a[n++] = aR[k++];
            return steps;
        }
        #endregion

        #region Task5
        static void Task5()
        {
            Console.WriteLine("\n\n##################################");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 5. Sortings Analytics\n");
            Console.WriteLine("**********************************");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Pronin P.S.");
            Console.WriteLine("Intel Core i5 2400 CPU 3.1 Ghz");
            Console.WriteLine("Win 10");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************\n");
            Console.WriteLine("Sort Type\t\tArr Len\t\tOperations Count\t\tTime");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 10; i < 30; i++)
            {
                int n = (int) Math.Pow(2, i);
                int[] a = new int[n];
                FillArray(a);

                DateTime st = DateTime.Now;
                Console.Write("QSort Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(QuickS(0, a.Length - 1, CopyArr(a), 0) + "\t\t\t\t");
                Console.WriteLine(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                st = DateTime.Now;
                Console.Write("Merge Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(MergeSort(CopyArr(a), 0, a.Length - 1, 0) + "\t\t\t\t");
                Console.WriteLine(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                st = DateTime.Now;
                Console.Write("Shake Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(ShakerSort(CopyArr(a)) + "\t\t\t\t");
                Console.WriteLine(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                st = DateTime.Now;
                Console.Write("Shell Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(ShellSort(CopyArr(a)) + "\t\t\t\t");
                Console.WriteLine(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                st = DateTime.Now;
                Console.Write("Insertion Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(InsertionSort(CopyArr(a)) + "\t\t\t\t");
                Console.WriteLine(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                st = DateTime.Now;
                Console.Write("Bubble Sort\t\t");
                Console.Write(n + "\t\t");
                Console.Write(OptimizedBubbleSort(CopyArr(a)) + "\t\t\t\t");
                Console.Write(Math.Round((DateTime.Now - st).TotalSeconds, 3));

                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("##################################");
        }

        /// <summary>
        /// Buble Sort
        /// </summary>
        /// <param name="a"></param>
        static long OptimizedBubbleSort(int[] a)
        {
            long steps = 0;
            for (int i = 0; i < a.Length; i++)
            {
                bool isSort = true;
                for (int j = 1; j < a.Length - i; j++)
                {
                    steps++;
                    if (a[j] < a[j - 1]) Swap(ref a[j], ref a[j - 1], ref isSort);
                }
                if (isSort) return steps;
            }
            return steps;
        }

        /// <summary>
        /// Shake Sort
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long ShakerSort(int[] a)
        {
            bool isSort = true;
            long steps = 0;
            int fe = 0, le = 0;
            do
            {
                isSort = true;
                for (int i = 1 + fe; i < a.Length - le; i++)
                {
                    steps++;
                    if (a[i] < a[i - 1]) Swap(ref a[i], ref a[i - 1], ref isSort);
                }
                le++;
                for (int i = a.Length - 1 - le; i > 0 + fe; i--)
                {
                    steps++;
                    if (a[i] < a[i - 1]) Swap(ref a[i], ref a[i - 1], ref isSort);
                }
                fe++;
            } while (!isSort);
            return steps;
        }

        /// <summary>
        /// Shell Sort
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long ShellSort(int[] a)
        {
            long steps = 0;
            int d = a.Length / 2;
            while (d > 0)
            {
                for (int i = d; i < a.Length; i++)
                {
                    int j = i;
                    int t = a[i];
                    while (j >= d)
                    {
                        steps++;
                        if (t < a[j - d])
                        {
                            Swap(ref a[j], ref a[j - d]);
                            j -= d;
                        }
                        else break;
                    }
                }
                d /= 2;
            }
            return steps;
        }

        /// <summary>
        /// Insertion Sort
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long InsertionSort(int[] a)
        {
            long steps = a.Length;
            for (int i = 1; i < a.Length; i++)
            {
                int j = i;
                while (j > 0 && a[j] < a[j - 1]) { Swap(ref a[j - 1], ref a[j--]); steps++; }
            }
            return steps;
        }
        #endregion

        #region Additional methods
        static void PrintArr(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
        }
        static void FillArray(int[] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
                a[i] = r.Next(0, a.Length);
        }
        static int[] CopyArr(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                b[i] = a[i];
            return b;
        }
        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        static void Swap(ref int a, ref int b, ref bool flag)
        {
            int t = 0;
            t = b;
            b = a;
            a = t;
            flag = false;
        }
        #endregion
    }
}
