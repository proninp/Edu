using System;
using System.Linq;

namespace Persons
{
    /*
     * Dev by Pronin P.S.
     * 
     * а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
     * Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»,
     * для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
     * б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
     * в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
     * г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Person[] p = new Person[10];
            for (int i = 0; i < p.Length; i++) // Заполнение массива
            {
                if (i % 2 == 0) p[i] = new Employee("Employee" + r.Next(1, 100), "Ivanov", r.Next(18,55), 1000);
                else p[i] = new Outsourcer("OutSourcer" + r.Next(1, 100), "Petrov", r.Next(18, 55), (i + 1));
            }
            foreach (var e in p) e.GetInfo();
            Console.WriteLine();
            Array.Sort(p); // Сортировка массива
            Console.WriteLine();
            Company d = new Company(p.ToList()); // Экземпляр класса, содержащего массив сотрудников
            foreach (var e in d) Console.WriteLine(e);
            Console.ReadLine();
        }
    }
}