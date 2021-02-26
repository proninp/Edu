using System;

namespace CSVToXML
{
    [Serializable]
    public class Student
    {
        static int bakalavr;
        static int magistr;

        string lastName;
        string firstName;
        string university;
        string faculty;
        int course;
        string department;
        int group;
        string city;
        int age;

        #region Свойства
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string University { get => university; set => university = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public int Course { get => course; set => course = value; }
        public string Department { get => department; set => department = value; }
        public int Group { get => group; set => group = value; }
        public string City { get => city; set => city = value; }
        public int Age { get => age; set => age = value; }
        public static int Bakalavr { get => bakalavr; set => bakalavr = value; }
        public static int Magistr { get => magistr; set => magistr = value; }
        #endregion

        #region Конструкторы
        public Student() { }

        public Student(string lastName, string firstName, string univercity, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = univercity;
            this.faculty = faculty;
            this.course = course;
            this.department = department;
            this.group = group;
            this.city = city;
            this.age = age;
            if (course < 5) bakalavr++; else magistr++;
        }
        public Student(string[] ar)
        {
            lastName = ar[0];
            firstName = ar[1];
            university = ar[2];
            faculty = ar[3];
            department = ar[4];
            age = int.Parse(ar[5]);
            course = int.Parse(ar[6]);
            group = int.Parse(ar[7]);
            city = ar[8];
            if (course < 5) bakalavr++; else magistr++;
        }
        #endregion
    }
}
