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
        public static ObservableCollection<Department> Dep = new ObservableCollection<Department>
        {
            new Department(1, "Администрация", new ObservableCollection<Employee>
            {
                new Employee(1, "Иван", "Иванов", 50, "Директор", "100000"),
                new Employee(2, "Лариса", "Дмитриева", 40, "Секретарь", "30000")
            }),
            new Department(2, "Бухгалтерия", new ObservableCollection<Employee>
            {
                new Employee(3, "Федор", "Петров", 45, "Главный бухгалтер", "80000"),
                new Employee(4, "Ирина", "Сидорова", 38, "Бухгалтер", "40000")
            }),
            new Department(4, "Продажи", new ObservableCollection<Employee>
            {
                new Employee(5, "Роман", "Борисов", 35, "Директор по продажам", "90000"),
                new Employee(6, "Дмитрий", "Медведев", 28, "Менеджер", "50000")
            }),
            new Department(5, "ИТ", new ObservableCollection<Employee>
            {
                new Employee(7, "Николай", "Федоров", 30, "Руководитель отдела", "80000"),
                new Employee(8, "Михаил", "Смирнов", 25, "Программист", "50000")
            })
        };
        //Department Administartion { get; set; } = new Department(1, "Администрация",
        //    new ObservableCollection<Employee>
        //    {
        //        new Employee(1, "Иван", "Иванов", 50, "Директор"),
        //        new Employee(1, "Лариса", "Иванова", 40, "Секретарь")
        //    });
        //Department Accountant { get; set; } = new Department(1, "Администрация",
        //    new ObservableCollection<Employee>
        //    {
        //        new Employee(1, "Федор", "Петров", 45, "Главный бухгалтер"),
        //        new Employee(1, "Ирина", "Сидорова", 38, "Бухгалтер")
        //    });
        //Department Sales { get; set; } = new Department(1, "Администрация",
        //    new ObservableCollection<Employee>
        //    {
        //        new Employee(1, "Роман", "Борисов", 35, "Директор по продажам"),
        //        new Employee(1, "Дмитрий", "Медведев", 28, "Менеджер")
        //    });
        //Department It { get; set; } = new Department(1, "Администрация",
        //    new ObservableCollection<Employee>
        //    {
        //        new Employee(1, "Николай", "Федоров", 30, "Руководитель отдела"),
        //        new Employee(1, "Михаил", "Смирнов", 25, "Программист")
        //    });
    }
}
