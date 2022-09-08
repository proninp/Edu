using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5
{
    class Task4
    {
        const string FILE_NAME = "..\\..\\Data\\Task4Data.txt";
        public static void Go()
        {
            Console.WriteLine("\nTask 4.\nStudents with marks.\n");
            ShowLaggingStudent();
        }
        static void GetDataFromFile(Dictionary<string, double> studentsWithMarks)
        {
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(FILE_NAME);
            while (!sr.EndOfStream)
                lines.Add(sr.ReadLine());
            foreach (var line in lines)
            {
                string[] array = line.Split(' ');
                studentsWithMarks.Add(string.Format($"{array[0]} {array[1]}"), Math.Round(array.Skip(2).Select(x => int.Parse(x)).Average(), 4));
            }
        }
        static void ShowLaggingStudent()
        {
            Dictionary<string, double> studentsWithMarks = new Dictionary<string, double>();
            GetDataFromFile(studentsWithMarks);
            var list = (from cte in studentsWithMarks.OrderBy(x => x.Value).Take(3).Select(x => x.Value).Distinct()
                         from firstThree in studentsWithMarks
                         where cte == firstThree.Value
                         select firstThree).ToList();
            foreach (var student in list)
                Console.WriteLine($"{student.Key} with average mark - {student.Value}");
        }




    }
}
