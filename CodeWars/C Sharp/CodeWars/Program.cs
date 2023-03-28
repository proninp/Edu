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
            List<int> numbers = new List<int> { 5, 3, 2, 1, 4 };
            List<int> list = Remover.RemoveSmallest(numbers);
            Console.WriteLine("Numbers:");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("List:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
        }   
    }
}
