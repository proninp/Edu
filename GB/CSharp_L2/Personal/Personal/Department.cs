using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal
{
    public class Department
    {
        /// <summary>
        /// ID Департамента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование Департамента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список сотрудников Департамента
        /// </summary>
        public List<Employee> Employees { get; set; }
        public Department(int id, string name, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
        public Department(int id, string name) : this (id, name, new List<Employee>()) { }

    }
}
