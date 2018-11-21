using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal
{
    public class Data
    {
        public static ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>
        {
            new Department(1, "Администрация", Administartion),
            new Department(2, "Бухгалтерия", Accountant),
            new Department(3, "Продажи", Sales),
            new Department(4, "ИТ", It)
        };
        public static ObservableCollection<Employee> Administartion { get; set; } = new ObservableCollection<Employee>
        {
            new Employee(1, "Иван", "Иванов", 50, "Директор"),
            new Employee(1, "Лариса", "Иванова", 40, "Секретарь")
        };
        public static ObservableCollection<Employee> Accountant { get; set; } = new ObservableCollection<Employee>
        {
            new Employee(1, "Федор", "Петров", 45, "Главный бухгалтер"),
            new Employee(1, "Ирина", "Сидорова", 38, "Бухгалтер")
        };
        public static ObservableCollection<Employee> Sales { get; set; } = new ObservableCollection<Employee>
        {
            new Employee(1, "Роман", "Борисов", 35, "Директор по продажам"),
            new Employee(1, "Дмитрий", "Медведев", 28, "Менеджер")
        };
        public static ObservableCollection<Employee> It { get; set; } = new ObservableCollection<Employee>
        {
            new Employee(1, "Николай", "Федоров", 30, "Руководитель отдела"),
            new Employee(1, "Михаил", "Смирнов", 25, "Программист")
        };
    }
}
