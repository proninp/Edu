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
            for (int i = 0; i < p.Length; i++)
            {
                if (i % 2 == 0) p[i] = new Employee("Employee" + i + 1, "Ivanov", 120);
                else p[i] = new OutSourcer("OutSourcer" + i + 1, "Petrov", 20 * (i + 1));
            }
        }
    }
}
