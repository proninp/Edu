using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_3
{
    class Task2
    {
        public static void Go()
        {
            string message = "Enter Integer number:";
            string numbers = "";
            int num = 0;
            int sum = 0;
            do
            {
                num = Additional.GetIntegerNumber(message);
                if ((num %2 != 0) && (num > 0))
                {
                    sum += num;
                    numbers += num + ", ";
                }

            } while (num != 0);
            if (numbers.Length > 2 && numbers.Substring(numbers.Length-2).Equals(", "))
                numbers = numbers.Substring(0, numbers.Length - 2);
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Numbers: {numbers}");
        }
    }
}
