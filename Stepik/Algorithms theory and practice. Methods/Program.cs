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
            Sample1_1();
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
    }

}
