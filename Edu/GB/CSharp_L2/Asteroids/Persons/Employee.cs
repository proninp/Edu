namespace Persons
{
    class Employee : Person
    {
        public double Salary { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        public Employee(string name, string surname, int age) : base(name, surname, age){ }
        /// <summary>
        /// Конструктор с ЗП
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public Employee(string name, string surname, int age, double salary) : this(name, surname, age)
        {
            Salary = salary;
        }
        /// <summary>
        /// Переопределенный метод получения средней зарплаты
        /// </summary>
        /// <returns>Средняя ЗП</returns>
        public override double AvgSalary() => Salary;
    }
}