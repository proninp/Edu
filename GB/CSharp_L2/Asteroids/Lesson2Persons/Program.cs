using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] p = new Person[10];
            Random r = new Random();
            for (int i = 0; i < p.Length; i++)
            {
                if (i % 2 == 0) p[i] = new Employee("Employee" + r.Next(1, 100), "Ivanov", 120);
                else p[i] = new OutSourcer("OutSourcer" + r.Next(1, 100), "Petrov", 20 * (i + 1));
            }
            foreach(var e in p) e.DisplayInfo();
            Console.WriteLine();
            Array.Sort(p);
            foreach (var e in p) e.DisplayInfo();
            Console.ReadLine();
        }
    }
}
