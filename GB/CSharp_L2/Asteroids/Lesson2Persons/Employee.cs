using System;

namespace Lesson2Persons
{
    class Employee : Person
    {
        /// <summary>
        /// Зарплата в месяц
        /// </summary>
        public double Salary { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="salary">Зарплата в месяц</param>
        public Employee(string name, string surname, double salary) : base(name, surname) => Salary = salary;
        /// <summary>
        /// Подсчет среднемесячной зарплаты
        /// </summary>
        /// <returns>Средняя зарплата в месяц</returns>
        protected override double GetAvgSalary() => Salary;
        /// <summary>
        /// Вывод информации по работнику
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} {Surname} with averege salary: {GetAvgSalary()}");
        }
    }
}
