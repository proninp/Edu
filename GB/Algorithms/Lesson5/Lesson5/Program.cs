using System;
using System.Collections.Generic;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();

            Task2();

            Task4();

            Task6();

            Console.ReadLine();
        }

        #region Task1
        /*
         * Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.
         */
        static void Task1()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Enter a number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("By Iterations:");
            PrintStack(BinaryConverterI(n));
            Console.WriteLine("By Recursion:");
            PrintStack(BinaryConverterR(n, new Stack<int>()));
            Console.ReadLine();
        }
        /// <summary>
        /// Stack and Iterations
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static Stack<int> BinaryConverterI(int n)
        {
            Stack<int> st = new Stack<int>();
            if (n == 0) st.Push(n);
            while (n > 0) { st.Push(n % 2); n /= 2; }
            return st;
        }
        /// <summary>
        /// Stack and Recursion
        /// </summary>
        /// <param name="n"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        static Stack<int> BinaryConverterR(int n, Stack<int> st)
        {
            if (n == 0) return st;
            st.Push(n % 2);
            return BinaryConverterR(n / 2, st);
        }
        /// <summary>
        /// Print st
        /// </summary>
        /// <param name="st"></param>
        static void PrintStack(Stack<int> st)
        {
            while (st.Count != 0) Console.Write(st.Pop());
            Console.WriteLine();
        }
        #endregion

        #region Task2
        /*
         * Написать программу, которая определяет, является ли введенная скобочная
         * последовательность правильной. Примеры правильных скобочных выражений: (), ([])(), {}(),
         * ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [, (, {.
         * Например: (2+(2*2)) или [2/{5*(4+7)}].
         */
        static void Task2()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine("Enter expression:");
            string s = Console.ReadLine();
            Console.WriteLine(Check(s));
        }
        /// <summary>
        /// Brackets check
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool Check(string s)
        {
            int[] a = new int[] { 40, 41, 91, 93, 123, 125 }; // int values of chars ()[]{}
            Stack<int> all = new Stack<int>();
            Stack<int> st = new Stack<int>();
            Queue<int> qu = new Queue<int>();
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (a[j] == s[i]) { all.Push(a[(j % 2 == 0) ? j + 1 : j]); break; } // if "(" then ")" if "[" then "]", but if ")" then itself, etc..
            if (all.Count % 2 != 0) return false;
            while (st.Count != all.Count) st.Push(all.Pop()); // fill s by first half of all
            while (all.Count > 0) qu.Enqueue(all.Pop()); // fill queue by seconfhalf of all
            while (st.Count > 0) if (st.Pop() != qu.Dequeue()) return false; // compare first with last of all..
            return true;
        }
        #endregion

        #region Task4

        static void Task4()
        {
            Console.WriteLine("Task 4");
            Console.WriteLine("Enter infix line:");
            string s = Console.ReadLine();
            Console.WriteLine(ConvertInToPost(s));
        }

        static string ConvertInToPost(string infix)
        {
            Stack<string> st = new Stack<string>();
            Stack<string> postfixSt = new Stack<string>();
            infix = infix.Replace(" ", "");
            string s;
            for (int i = 0; i < infix.Length; i++)
            {
                if (!ContainsOperators(infix[i]))
                    postfixSt.Push(infix[i].ToString());
                else
                {
                    if (infix[i] == '(') st.Push("(");
                    else if (infix[i] == ')')
                    {
                        s = st.Pop();
                        while (s != "(")
                        {
                            postfixSt.Push(s);
                            if (st.Count > 0) s = st.Pop();
                        }
                    }
                    else
                    {
                        while (st.Count > 0)
                        {
                            s = st.Pop();
                            if (GetPriority(s) >= GetPriority(infix[i].ToString()))
                                postfixSt.Push(s);
                            else
                            {
                                st.Push(s);
                                break;
                            }
                        }
                        st.Push(infix[i].ToString());
                    }
                }
            }
            while (st.Count > 0) postfixSt.Push(st.Pop());
            return RevSt(postfixSt);
        }

        static bool ContainsOperators(char c)
        {
            string s = "*+/-()";
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c) return true;
            return false;
        }
        static int GetPriority(string s) => (s == "(") ? 1 : (s == "*" || s == "/") ? 3 : 2;

        static string RevSt(Stack<string> st)
        {
            String s = "";
            while (st.Count > 0)
                s = st.Pop() + s;
            return s;

        }

        #endregion

        #region Task6
        static void Task6()
        {
            Console.WriteLine("Task 6");
            Deq<int> d = new Deq<int>();
            d.AddFirst(5);
            d.AddFirst(4);
            d.AddFirst(3);
            d.AddFirst(2);
            d.AddLast(6);
            d.AddLast(7);
            d.AddLast(8);
            d.AddLast(9);

            while(d.Count != 0)
            {
                Console.WriteLine("First:\t" + d.PopFirst());
                Console.WriteLine("Last:\t" + d.PopLast());
            }
        }
        #endregion
    }
}
