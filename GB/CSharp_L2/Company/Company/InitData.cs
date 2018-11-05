using System;
using System.Linq;
using System.Collections.ObjectModel;


namespace Company
{
    /// <summary>
    /// Заполнение списков данными
    /// </summary>
    public class InitData
    {
        private static Random rand = new Random();
        /// <summary>
        /// Список департаментов
        /// </summary>
        //public static ObservableCollection<Department> depList = new ObservableCollection<Department>
        //{
        //    new Department(001, "Администрация", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 001).ToList())),
        //    new Department(002, "Бухгалтерия", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 002).ToList())),
        //    new Department(003, "Финансовый отдел", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 003).ToList())),
        //    new Department(004, "Отдел продаж", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 004).ToList())),
        //    new Department(005, "Отлел логистики", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 005).ToList())),
        //    new Department(006, "Производственный участок", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 006).ToList())),
        //    new Department(007, "Отдел ИТ", new ObservableCollection<Employee>( empList.Where(e => e.DepartmentId == 007).ToList()))
        //};
        public static ObservableCollection<Position> posList = new ObservableCollection<Position>
        {
            new Position(001, "Директор", 001),
            new Position(002, "Секретарь", 001),
            new Position(003, "Главный бухгалтер", 002),
            new Position(004, "Бухгалтер", 002),
            new Position(005, "Финансовый директор", 003),
            new Position(006, "Экономист", 003),
            new Position(007, "Коммерческий директор", 004),
            new Position(008, "Менеджер по продажам", 004),
            new Position(009, "Начальник отдела логистики", 005),
            new Position(010, "Кладощик", 005),
            new Position(011, "Начальник производства", 006),
            new Position(012, "Технолог", 006),
            new Position(013, "Руководитель отдела ИТ", 007),
            new Position(014, "Программист", 007)
        };
        public static ObservableCollection<Employee> empList = new ObservableCollection<Employee>
        {
            new Employee(001, "Иванов", "Сергей", "Иванович", new DateTime(rand.Next(1975, 1991), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 888 77 66", "IvanovSI@company.ru", 001, 001),
            new Employee(002, "Петров", "Иван", "Петрович", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 777 77 66", "PetrovIP@company.ru", 002, 001),
            new Employee(003, "Сидоров", "Дмитрий", "Сергеевич", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 666 77 66", "SidorovDS@company.ru", 003, 002),
            new Employee(004, "Смирнов", "Андрей", "Дмитриевич", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 555 77 66", "SmirnovAD@company.ru", 004, 002),
            new Employee(005, "Романов", "Николай", "Николаевич", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 444 77 66", "RomanovNN@company.ru", 005, 003),
            new Employee(006, "Сергеев", "Михаил", "Иванович", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 333 77 66", "SergeevMI@company.ru", 006, 003),
            new Employee(007, "Андреев", "Евгений", "Михайлович", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 222 77 66", "AndreevEM@company.ru", 007, 004),
            new Employee(008, "Филиппов", "Максим", "Сергеевич", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Male, "+7 (999) 111 77 66", "FilippovMS@company.ru", 008, 004),
            new Employee(009, "Иванова", "Ирина", "Михайловна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 88 66", "IvanovaIM@company.ru", 009, 005),
            new Employee(010, "Петрова", "Светлана", "Сергеевна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 99 66", "PetrovaSS@company.ru", 0010, 005),
            new Employee(011, "Сидорова", "Тамара", "Константиновна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 66 66", "SidorovaTK@company.ru", 011, 006),
            new Employee(012, "Романова", "Виктория", "Николаевна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 55 66", "RomanovaNN@company.ru", 012, 006),
            new Employee(013, "Сергеева", "Наталья", "Дмитриевна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 44 66", "SergeevaND@company.ru", 012, 006),
            new Employee(014, "Андреева", "Ольга", "Вячеславовна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 33 66", "AndreevaOV@company.ru", 013, 007),
            new Employee(015, "Филиппова", "Марина", "Александровна", new DateTime(rand.Next(1975, 1990), rand.Next(1,13), rand.Next(1, 28)), Sex.Female, "+7 (999) 888 22 66", "FilippovaMA@company.ru", 014, 007),
            };
    }
}
