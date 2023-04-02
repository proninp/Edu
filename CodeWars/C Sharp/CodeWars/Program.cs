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
            int[] ar = YouGotChange.GiveChange(217);
            for (int i = 0; i < ar.Length; i++)
                Console.WriteLine(ar[i]);
            Console.ReadLine();
        }   
    }
}
