using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Personal
{
    public class Employee : INotifyPropertyChanged
    {
        /// <summary>
        /// ID Сотрудника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Признак того, что сотруднк заблокирован
        /// </summary>
        private bool blocked;
        public bool Blocked
        {
            get => blocked;
            set
            {
                blocked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Blocked)));
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="position">Должность</param>
        /// <param name="salary">Зарплата</param>
        public Employee(int id, string firstName, string lastName, int age, string position, string salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Position = position;
            Salary = salary;
            Blocked = false;
        }
        /// <summary>
        /// Дополнительный конструктор
        /// </summary>
        /// <param name="id">ID Сотрудника</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="position">Должность</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="blocked">Признак блокировки</param>
        public Employee(int id, string firstName, string lastName, int age, string position, string salary, bool blocked) :this(id, firstName, lastName, age, position, salary)
        {
            Blocked = blocked;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => FullName;
    }
}
