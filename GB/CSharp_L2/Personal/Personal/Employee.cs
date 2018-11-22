using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal
{
    public class Employee
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
        public Employee(int id, string firstName, string lastName, int age, string position)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Position = position;
        }
    }
}
