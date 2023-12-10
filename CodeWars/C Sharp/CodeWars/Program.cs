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
            var r = SumOfDifferencesBetweenProductsAndLCMs.SumDifferencesBetweenProductsAndLCMs(
                new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 }, new int[] { 13, 91 } });
            Console.WriteLine(r);
            Console.ReadLine();
        }   
    }
}
