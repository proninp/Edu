using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public abstract class Person
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
        public abstract void GetInfo();
    }
}
