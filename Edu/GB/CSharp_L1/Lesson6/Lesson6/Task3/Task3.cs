using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        /*
         * Исполнитель:
         * Пронин Павел
         * 
         * Задание №3
         * Подсчитать количество студентов:
         * а) учащихся на 5 и 6 курсах;
         * б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
         * в) отсортировать список по возрасту студента;
         * г) *отсортировать список по курсу и возрасту студента.
         */
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("..\\..\\Data\\students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[1], s[0], s[2], s[3], int.Parse(s[6]), s[4], int.Parse(s[7]), s[8], int.Parse(s[5])));
                }
                catch(Exception ex)
                {
                    Lesson6.Support.ColoredWriteLine(ex.Message, ConsoleColor.Red);
                    Lesson6.Support.ColoredWriteLine("Ошибка!ESC - прекратить выполнение программы.", ConsoleColor.Red);
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            // а)
            Lesson6.Support.ColoredWriteLine($"Учащихся на 5 и 6 курсах:\t{GetFiveAndSixCourseStudents(list)}", ConsoleColor.Cyan);
            // б)
            Lesson6.Support.ColoredWriteLine("Список студентов в возрасте от 18 до 20 лет:", ConsoleColor.Yellow);
            GetCurrCourseStudentsCount(list);
            // в)
            Lesson6.Support.ColoredWriteLine("Список студентов, отсортированнй по возрасту:", ConsoleColor.Yellow);
            AgeSort(list);
            AgePrint(list);
            // г)
            Lesson6.Support.ColoredWriteLine("Список студентов, отсортированнй по курсу возрасту:", ConsoleColor.Yellow);
            CourseAgeSort(list);
            CourseAgePrint(list);
            Console.ReadLine();
        }
        /// <summary>
        /// Получаем кол-во учеников, учащихся на 5 и 6 курсах
        /// </summary>
        /// <param name="list">Коллекция учеников</param>
        /// <returns>Кол-во учеников</returns>
        static int GetFiveAndSixCourseStudents(List<Student> list)
        {
            return list.Where(l => l.Course > 4).Count();
        }
        /// <summary>
        /// Подсчитываем сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void GetCurrCourseStudentsCount(List<Student> list)
        {
            int[] arr = new int[6];
            for (int i = 0; i < list.Count(); i++)
                if (list[i].Age >=18 && list[i].Age <= 20)
                    arr[list[i].Course - 1]++;
            for (int i = 0; i < arr.Length; i++)
                Lesson6.Support.ColoredWriteLine($"На {i + 1} курсе учится {arr[i]}.", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Сортировка студентов по возрасту
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void AgeSort(List<Student> list)
        {
            list.Sort(delegate (Student s1, Student s2) { return s1.Age - s2.Age; });
        }
        /// <summary>
        /// Еще один вариант сортировки по возрасту, при помощи Linq
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void LinqAgeSort(List<Student> list)
        {
            list.OrderBy(l => l.Age).ToList();
        }

        /// <summary>
        /// Сортировка по курсу и возрасту студента
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void CourseAgeSort(List<Student> list)
        {
            list.Sort(Comparer);
        }
        /// <summary>
        /// Еще один вариант сортировки по курсу и возрасту, при помощи Linq
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void LinqCourseAgeSort(List<Student> list)
        {
            list.OrderBy(l => l.Course).ThenBy(l => l.Age).ToList();
        }
        /// <summary>
        /// Компаратор по курсу и возрасту студента
        /// </summary>
        /// <param name="s1">Студент 1</param>
        /// <param name="s2">Студент 2</param>
        /// <returns>Результат сравнения</returns>
        static int Comparer(Student s1, Student s2)
        {
            int res = s1.Course - s2.Course;
            if (res == 0)
                res = s1.Age - s2.Age;
            return res;
        }
        /// <summary>
        /// Печать списка для сортировки по возрасту
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void AgePrint(List<Student> list)
        {
            foreach (var s in list)
                Lesson6.Support.ColoredWriteLine($"{s.FirstName} {s.LastName},\tвозраст: {s.Age}", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Печвть списка для сортировки по курсу и возрасту
        /// </summary>
        /// <param name="list">Список студентов</param>
        static void CourseAgePrint(List<Student> list)
        {
            foreach (var s in list)
                Lesson6.Support.ColoredWriteLine($"{s.FirstName} {s.LastName},\tкурс: {s.Course}\tвозраст: {s.Age}", ConsoleColor.Cyan);
        }

    }
}
