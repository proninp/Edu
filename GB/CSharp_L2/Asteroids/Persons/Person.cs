using System;

namespace Persons
{
    public abstract class Person : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        /// <summary>
        /// Метод для расчета среднемесячной заработной платы
        /// </summary>
        /// <returns></returns>
        public abstract double AvgSalary();
        /// <summary>
        /// Инфорация
        /// </summary>
        public virtual void GetInfo()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Переопределение ToString()
        /// </summary>
        /// <returns>вывод информации</returns>
        public override string ToString() => $"Сотрудник {Name} {Surname}, возраст: {Age}, среднемесячная оплата: {AvgSalary().ToString("F2")}";
        /// <summary>
        /// Реализация компаратора
        /// </summary>
        /// <param name="obj">Экземпляр наследника Person</param>
        /// <returns>Результат сравнения</returns>
        public virtual int CompareTo(object obj) => ((AvgSalary()) > ((Person)obj).AvgSalary()) ? 1 :
            ((AvgSalary() < ((Person)obj).AvgSalary()) ? -1 : 0);
    }
}