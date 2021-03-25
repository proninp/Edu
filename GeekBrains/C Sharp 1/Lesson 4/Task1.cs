using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_4
{
    class Task1
    {
        public static void Go()
        {
            Console.WriteLine("Task 1.\n");
            FillArray(out int[] array);
            Print(array);
            Console.WriteLine($"\nElements count: {FindElementsCount(array, out string elements)}");
            Console.WriteLine(elements);
        }
        static void FillArray(out int[] array)
        {
            array = new int[20];
            const int MIN_VALUE = -10000;
            const int MAX_VALUE = 10001;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(MIN_VALUE, MAX_VALUE);
        }
        static int FindElementsCount(int[] array, out string elements)
        {            
            int count = 0;
            elements = "";
            for (int i = 0; i < array.Length-1; i++)
                if ((array[i] % 3 == 0) ^ (array[i + 1] % 3 == 0))
                {
                    count++;
                    elements += $"[{array[i]}, {array[i + 1]}]";
                }
            if (elements.Contains("]["))
                elements = elements.Replace("][", "]; [");
            return count;
        }
        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
        }
    }
}
