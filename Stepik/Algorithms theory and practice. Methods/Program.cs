using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_theory_and_practice.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample2_2_3();
            Console.ReadLine();
        }
        
        static void Sample1_1()
        {
            /*In this problem, you need to calculate the sum of two input integers lying in the interval from zero to ten.No tricks,
             * this is an obvious task designed to introduce you to the checking system.The next step shows solutions to this problem
             * in several programming languages(you can go there right now and copy the solution from there).In this problem, as in all
             * programming problems, you do not need to check that the input data meets the requirements stated in the condition.
             * In other words, in all the tests that your program will be tested on, two integers from 0 to 10 will be input.
             * 
             * Sample Input:
             * 7 3
             * Sample Output:
             * 10
             */
            Console.WriteLine(Console.ReadLine().Sum(c => char.IsDigit(c) ? c - 48 : 0));
        }
        static void Sample2_2_1()
        {
            /*
             * Given an integer 1 < = n < = 40, it is necessary to calculate the n-th Fibonacci number
            */
            int x = int.Parse(Console.ReadLine());
            int res = 1;
            int y = 0;
            for (int i = 2; i <= x; i++)
            {
                res += y;
                y = res - y;
            }
            Console.WriteLine(res);
        }
        static void Sample2_2_2()
        {
            /*
             * Given an integer 1 < = n < = 10^7, you need to find the last number of bigger Fibonacci number
            */
            int x = int.Parse(Console.ReadLine());
            int res = 1;
            int y = 0;
            for (int i = 2; i <= x; i++)
            {
                res += y;
                y = res - y;
                res = res % 10;
            }
            Console.WriteLine(res);
        }
        static void Sample2_2_3()
        {
            /*
             * Given an integer 1 < = n < = 10^7, you need to find the last number of bigger Fibonacci number
            */
            string[] s = Console.ReadLine().Split(' ');
            long x = long.Parse(s[0]);
            long n = long.Parse(s[1]);
            long res = 1;
            long y = 0;
            for (long i = 2; i <= x; i++)
            {
                res += y;
                y = res - y;
            }
            res = res % n;
            Console.WriteLine(res);
        }
    }
}
