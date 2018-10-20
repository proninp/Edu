using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Persons
{
    abstract class Person
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        protected abstract double GetAvgSalary();
        protected abstract void DisplayInfo();
    }
}
