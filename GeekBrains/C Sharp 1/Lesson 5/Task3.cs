using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5
{
    class Task3
    {
        public static void Go()
        {
            Console.WriteLine("\nTask 3.\nFor two strings, write a method that determines whether one string is a permutation of the other.\n");
            Console.WriteLine(">> Enter first string:");
            string s1 = Console.ReadLine();
            Console.WriteLine(">> Enter second string:");
            string s2 = Console.ReadLine();
            if (IsPermutation(s1, s2))
                Console.WriteLine("The string is permutation of another string");
            else
                Console.WriteLine("The string isn't permutation of another string");
        }
        static bool IsPermutation(string s1, string s2) => string.Concat(s1.OrderBy(c => c)).Equals(string.Concat(s2.OrderBy(c => c)));
    }
}
