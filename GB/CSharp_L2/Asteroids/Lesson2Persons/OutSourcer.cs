using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Persons
{
    class OutSourcer: Person
    {
        public double SalaryPerHour { get; set; }
        public OutSourcer(string name, string surname, double salary): base(name, surname) => SalaryPerHour = salary;
        protected override double GetAvgSalary() => 20.8 * 8 * SalaryPerHour;
        protected override void DisplayInfo()
        {
            Console.WriteLine($"{Name} {Surname} with averege salary: {GetAvgSalary()}");
        }
    }
}
