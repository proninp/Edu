using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Description { get => $"{Name} {Patronymic} {Surname}"; }
        public DateTime Birthday { get; set; }
        public int Age { get => DateTime.Today.Year - Birthday.Year; }
        public Sex Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }

        public Employee(int id, string surname,  string name, string patronymic, DateTime birthday, Sex sex, string phone, string email, int posId, int depId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Sex = sex;
            Phone = phone;
            Email = email;
            PositionId = posId;
            DepartmentId = depId;
        }
    }
    public enum Sex
    {
        Male,
        Female
    }

}
