using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> intCol = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                intCol.Add(r.Next(5));
                Console.Write(intCol[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Группировка при помощи методов - расширений:");
            var q1 = intCol.GroupBy(e => e).Select(e => $"{e.Key}: {e.Count()};");
            foreach (var e in q1)
                Console.WriteLine(e);
            Console.WriteLine("Группировка при помощи linq - запросов:");
            var q2 = from q in intCol
                     group intCol by q;
            foreach (var e in q2)
                Console.WriteLine($"{e.Key}: {e.Count()};");
                     

            Console.ReadLine();

        }
    }
}
