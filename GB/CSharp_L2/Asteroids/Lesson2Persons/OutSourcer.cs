using System;

namespace Lesson2Persons
{
    /*
     * Класс для работников с почасовой оплатой
     */
    class OutSourcer: Person
    {
        /// <summary>
        /// Зарплата в час
        /// </summary>
        public double SalaryPerHour { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="surname">Фамилия сотрудника</param>
        /// <param name="salary">Зарплата в час</param>
        public OutSourcer(string name, string surname, double salary): base(name, surname) => SalaryPerHour = salary;
        /// <summary>
        /// Метод для подсчета средней зарплаты
        /// </summary>
        /// <returns>Средняя зарплата за месяц</returns>
        protected override double GetAvgSalary() => 20.8 * 8 * SalaryPerHour;
        /// <summary>
        /// Вывод информации о сотруднике
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} {Surname} with averege salary: {GetAvgSalary()}");
        }
    }
}
