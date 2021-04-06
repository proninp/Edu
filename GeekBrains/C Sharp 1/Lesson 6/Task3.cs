using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Lesson_6
{
    class Task3
    {
        public static void Go()
        {
            Console.WriteLine("\nTask 3.\n");
            FillStudentList(out List<Student> students);
            // a
            Console.WriteLine($"Students on 5 and 6 cources: {StudentsAfterSpecifiedCourseCount(4, students)}");
            // b
            Console.WriteLine($"\nStudents from 18 to 21 age old by cources:");
            PrintDictionary(StudentsOnCourse(students));
            // c
            Console.WriteLine("\nStudents by age:");
            PrintList(StudentsByAge(students));
            // d
            Console.WriteLine("\nStudents by course and age:");
            PrintList(StudentsByCourceAndAge(students));
        }
        static int StudentsAfterSpecifiedCourseCount(int course, List<Student> students) => students.Where(s => s.Course > 4).Count();
        static Dictionary<int, int> StudentsOnCourse(List<Student> students) =>
            students.Where(s => (s.Age > 17 && s.Age < 21)).GroupBy(st => st.Course).ToDictionary(sgk => sgk.Key, sgk => sgk.Count());
        static List<Student> StudentsByAge(List<Student> students) => students.OrderBy(s => s.Age).ToList();
        static List<Student> StudentsByCourceAndAge(List<Student> students) => students.OrderBy(s => s.Course).ThenBy(s => s.Age).ToList();
        static int FillStudentList(out List<Student> students)
        {
            students = new List<Student>();
            StreamReader sr = new StreamReader("..\\..\\Data\\students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    students.Add(new Student(s[1], s[0], s[2], s[3], int.Parse(s[6]), s[4], int.Parse(s[7]), s[8], int.Parse(s[5])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            return 0;
        }
        static void PrintDictionary(Dictionary<int, int> keyValues)
        {
            foreach (var el in keyValues)
                Console.WriteLine($"Course {el.Key}; Count {el.Value}");
        }
        static void PrintList(List<Student> students)
        {
            foreach(var el in students)
                Console.WriteLine($"Surname: {el.LastName}; Name: {el.FirstName}; Age: {el.Age}; Course: {el.Course}");
        }
    }
}
