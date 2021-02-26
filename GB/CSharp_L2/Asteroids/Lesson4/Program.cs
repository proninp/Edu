using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4
{
    class Program
    {
        delegate int OrdrBy(KeyValuePair<string, int> d);

        static void Main(string[] args)
        {
            #region Задание 2
            /*
             * Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
             * для целых чисел;
             * * для обобщенной коллекции;
             * ** используя Linq.
             */
            Console.WriteLine("Задание №2:");
            Random r = new Random();
            List<int> intCol = new List<int>();
            for (int i = 0; i < 20; i++) { intCol.Add(r.Next(5)); Console.Write(intCol[i] + " "); } // Заполнение списка

            Console.WriteLine("\nГруппировка при помощи методов - расширений:");
            var q1 = intCol.GroupBy(e => e).Select(e => new { e.Key, Count = e.Count() }).
                OrderByDescending(e => e.Count).ThenBy(e => e.Key);
            foreach (var e in q1) // Вывод коллекции на экран
                Console.WriteLine($"{e.Key}: {e.Count};");

            Console.WriteLine("\nГруппировка при помощи linq - запросов:");
            var q2 = from q in intCol
                     group q by q
                     into qq
                     orderby qq.Count() descending, qq.Key
                     select new { qq.Key, Count = qq.Count() };
            foreach (var e in q2) // Вывод коллекции на экран
                Console.WriteLine($"{e.Key}: {e.Count};");
            #endregion

            #region Задание 3
            /*
             * Дан фрагмент программы:
             * а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
             * b. * Развернуть обращение к OrderBy с использованием делегата .
             */
            Console.WriteLine("\nЗадание №3:");
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four",4 },
                { "two",2 },
                { "one",1 },
                { "three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            Console.WriteLine();
            d = dict.OrderBy(e => e.Value); // Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
            foreach (var e in d)
                Console.WriteLine("{0} - {1}", e.Key, e.Value);
            #endregion
            Console.ReadLine();
        }
    }
}
