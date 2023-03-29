using System;
using System.Collections.Generic;
using System.Linq;
using CodeWars._3kyu;
using CodeWars._4kyu;
using CodeWars._5kyu;
using CodeWars._6kyu;
using CodeWars._7kyu;
using CodeWars._8kyu;

namespace CodeWars
{
    class Program
    {
        public static void Main()
        {
            List<Tuple<int, int>> list = CalculateFibReturnDigitPccurrencesCount.FibDigits(10000);
            foreach(Tuple<int, int> t in list)
                Console.WriteLine(t.Item1 + ", " + t.Item2);
            Console.ReadLine();
        }   
    }
}
