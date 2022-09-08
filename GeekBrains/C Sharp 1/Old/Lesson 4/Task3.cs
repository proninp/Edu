using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_4
{
    class Task3
    {
        public static void OneDimDemonstrate()
        {
            const string FILENAME = "..\\..\\Data\\Task3Data.txt";

            Console.WriteLine("\nTask 3\n");
            Console.WriteLine("Enter array length:");
            int.TryParse(Console.ReadLine(), out int len);
            Console.WriteLine("Enter array start value:");
            int.TryParse(Console.ReadLine(), out int start);
            Console.WriteLine("Enter step to shift next array value:");
            int.TryParse(Console.ReadLine(), out int step);
            OneDimensional one = new OneDimensional(len, start, step);
            Console.WriteLine("Your new array:");
            one.Print();
            Console.WriteLine("Max element is:");
            Console.WriteLine(one.Max);
            Console.WriteLine("Min element is:");
            Console.WriteLine(one.Min);
            Console.WriteLine("Sum of array elements is:");
            Console.WriteLine(one.Sum);
            Console.WriteLine("Max elements count:");
            Console.WriteLine(one.MaxCount);
            Console.WriteLine("Random Fill:");
            one.RandomFill(one.Min, one.Max);
            Console.WriteLine("Your new array:");
            one.Print();
            Console.WriteLine("Enter number to multiply:");
            int.TryParse(Console.ReadLine(), out int multiply);
            one.Multi(multiply);
            Console.WriteLine("Your new multiplied array:");
            one.Print();
            Console.WriteLine("Key-Value pairs:");
            one.PrintKeyValue();

            Console.WriteLine("New array readed from file:");
            one = new OneDimensional(FILENAME);
            one.Print();
        }        
    }
}
