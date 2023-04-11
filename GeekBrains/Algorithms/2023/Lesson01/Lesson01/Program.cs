namespace Lesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1:");
            Console.WriteLine(Task1());
            Console.WriteLine();
            Console.WriteLine("Task 3:");
            Task3();
        }
        /*
         * Требуется реализовать на C# функцию согласно блок-схеме.
         * Блок-схема описывает алгоритм проверки, простое число или нет.
         */
        public static bool Task1()
        {
            Console.WriteLine("Введите n:");
            int n = Int32.Parse(Console.ReadLine() ?? "0");
            int d = 0;
            int i = 2;
            while (d == 0 && i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }
            return (d == 0);
        }
        /*
         * Вычислите асимптотическую сложность функции из примера ниже.
         */
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;
                        if (j != 0)
                        {
                            y = k / j;
                        }
                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }
            return sum;
        }
        // O(N^3)

        /*
         * Реализуйте функцию вычисления числа Фибоначчи
         * Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
         */
        public static void Task3()
        {
            Console.WriteLine("Введите число для вычисления числа Фибоначчи:");
            int n = Int32.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Рекурсивное выполнение:");
            Console.WriteLine(FibRecursive(n));
            Console.WriteLine("Итеративное выполнение:");
            Console.WriteLine(FibIterative(n));
        }
        public static int FibRecursive(int n)
        {
            if (n < 2)
                return n;
            return FibRecursive(n - 2) + FibRecursive(n - 1);
        }
        public static int FibIterative(int n)
        {
            int[] arr = new int[n+1];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 2] + arr[i - 1];
            }
            return arr[n];
        }
    }
}