using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Persons
{
    class Employee : Person
    {
        public double Salary { get; set; }
        public Employee(string name, string surname, double salary) : base(name, surname) => Salary = salary;
        protected override double GetAvgSalary() => Salary;
        protected override void DisplayInfo()
        {
            Console.WriteLine($"{Name} {Surname} with averege salary: {GetAvgSalary()}");
        }
    }
}
