using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Task 1:");
            TestCase testTask1Case1 = new TestCase()
            {
                X = 3,
                ExpectedBool = true,
                ExpectedException = null
            };
            TestCase testTask1Case2 = new TestCase()
            {
                X = 61,
                ExpectedBool = true,
                ExpectedException = null
            };
            TestCase testTask1Case3 = new TestCase()
            {
                X = 158,
                ExpectedBool = false,
                ExpectedException = null
            };
            TestCase testTask1Case4 = new TestCase()
            {
                X = 158,
                ExpectedBool = true,
                ExpectedException = null
            };
            TestCase testTask1Case5 = new TestCase()
            {
                X = -1,
                ExpectedBool = true,
                ExpectedException = null
            };
            TestTask1(testTask1Case1);
            TestTask1(testTask1Case2);
            TestTask1(testTask1Case3);
            TestTask1(testTask1Case4);
            TestTask1(testTask1Case5);

            Console.WriteLine("\nTask 2:");
            Console.WriteLine("Асимптотическая сложность функции O(N^3)");

            Console.WriteLine("\nTask 3:");
            TestCase testTask3Case1 = new TestCase()
            {
                X = 3,
                ExpectedInt = 2,
                ExpectedException = null
            };
            TestCase testTask3Case2 = new TestCase()
            {
                X = 10,
                ExpectedInt = 55,
                ExpectedException = null
            };
            TestCase testTask3Case3 = new TestCase()
            {
                X = -5,
                ExpectedInt = 5,
                ExpectedException = null
            };
            TestCase testTask3Case4 = new TestCase()
            {
                X = -5,
                ExpectedInt = -5,
                ExpectedException = null
            };
            TestCase testTask3Case5 = new TestCase()
            {
                X = 8,
                ExpectedInt = 22,
                ExpectedException = null
            };
            TestTask3(testTask3Case1);
            TestTask3(testTask3Case2);
            TestTask3(testTask3Case3);
            TestTask3(testTask3Case4);
            TestTask3(testTask3Case5);
            Console.ReadLine();
        }
        #region Task1
        /// <summary>
        /// Напишите на C# функцию согласно блок-схеме
        /// Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм
        /// проверки, простое число или нет
        /// </summary>
        static bool Task1(int n)
        {
            // В алгоритме блок схемы допущена неточность, 0 и 1 не являются простыми числами (большинство математиков первым простым числом считают 2)
            // В блоке ниже описан механизм выхода из функции, если n < 2
            #region Непредусмотренный в блоксхеме выход
            if (n < 2)
                return false;
            #endregion

            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }
            return (d == 0);
        }
        static void TestTask1(TestCase testCase)
        {
            try
            {
                var actual = Task1(testCase.X);
                if (actual == testCase.ExpectedBool)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        #endregion

        #region Task2
        /// <summary>
        /// Вычислите асимптотическую сложность функции из примера ниже
        /// </summary>
        /// <param name="inputArray"></param>
        static void Task2(int[] inputArray)
        {
            // Асимптотическая сложность функции O(N^3)
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
        }
        #endregion

        #region Task3
        /// <summary>
        /// Реализуйте функцию вычисления числа Фибоначчи
        /// Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
        /// </summary>
        static void Task3(int n)
        {
            Console.WriteLine($"Рекурсивная функция: {GetFibonacciRecoursive(n)}");
            Console.WriteLine($"Итеративная функция: {GetFibonacciIteration(n)}");
            Console.WriteLine();
        }
        static int GetFibonacciRecoursive(int n)
        {
            int sign = PrepareFibonacci(ref n);
            int fib = FibonacciRecoursive(n) * sign;
            return fib;
        }
        static int GetFibonacciIteration(int n)
        {
            int sign = PrepareFibonacci(ref n);
            int fib = FibonacciIteration(n) * sign;
            return fib;
        }
        static int PrepareFibonacci(ref int n)
        {
            int sign = (n < 0) ? -1 : 1;
            n = Math.Abs(n);
            if (n % 2 != 0)
                sign *= sign;
            return sign;
        }
        static int FibonacciRecoursive(int n)
        {
            if (n < 2)
                return n;
            return FibonacciRecoursive(n - 2) + FibonacciRecoursive(n - 1);
        }
        static int FibonacciIteration(int n)
        {
            if (n < 2)
                return n;
            
            int fibFirst = 0;
            int fibSecond = 1;

            int fib = 0;
            for (int i = 1; i < n; i++)
            {
                fib = fibFirst + fibSecond;
                fibFirst = fibSecond;
                fibSecond = fib;
            }
            return fib;
        }

        static void TestTask3(TestCase testCase)
        {
            try
            {
                var actualRecoursive = GetFibonacciRecoursive(testCase.X);
                var actualIteration = GetFibonacciIteration(testCase.X);
                if (actualRecoursive != actualIteration)
                {
                    Console.WriteLine("INVALID TEST");
                    return;
                }
                if (actualRecoursive == testCase.ExpectedInt)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        #endregion
    }
}
