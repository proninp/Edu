using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// Список сотрудников департамента
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }
        public Department(int id, string name, ObservableCollection<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
        public Department(int id, string name) : this(id, name, new ObservableCollection<Employee>()) { }

    }
}
