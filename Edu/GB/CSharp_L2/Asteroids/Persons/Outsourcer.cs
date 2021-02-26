namespace Persons
{
    class Outsourcer : Person
    {
        public double SalaryPH { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        public Outsourcer(string name, string surname, int age) : base(name, surname, age){ }
        /// <summary>
        /// Конструктор с ЗП
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public Outsourcer(string name, string surname, int age, double salaryPH) : this(name, surname, age)
        {
            SalaryPH = salaryPH;
        }
        /// <summary>
        /// Переопределенный метод получения средней зарплаты
        /// </summary>
        /// <returns>Средняя ЗП</returns>
        public override double AvgSalary() => SalaryPH * 20.8 * 8;
    }
}