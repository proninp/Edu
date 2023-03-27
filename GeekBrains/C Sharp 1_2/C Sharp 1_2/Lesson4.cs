using System.IO.IsolatedStorage;

namespace C_Sharp_1_2
{
    internal class Lesson4
    {
        static void Main(string[] args)
        {
            #region Launch Lesson Practice
            int[] numbers = { 1, 2, 3, -4, -7, 12, 24 };
            PrintArray(numbers);
            ChangeArrIndexVal(numbers, 1, -2);
            PrintArray(numbers);

            ref int min = ref GetMin(numbers);
            min = -1 * min;
            PrintArray(numbers);
            #endregion


            Console.WriteLine(GetFullName("Иван", "Петров", "Николаеыич"));
            Console.WriteLine(GetFullName("Петр", "Николаев", "Иванович"));
            Console.WriteLine(GetFullName("Николай", "Иванов", "Петрович"));

            Console.WriteLine("Задача 2:");
            Console.WriteLine("Введите набор чисел через пробел:");
            Console.WriteLine(StringNumbersSum(Console.ReadLine() ?? ""));

            Console.WriteLine("Задача 3:");
            Console.WriteLine("Введите номер месяца:");
            Console.WriteLine(GetSeasonName(GetEnumSeason(Convert.ToInt32(Console.ReadLine()))));

            Console.WriteLine("Задача 4:");
            Console.WriteLine("Введите порядковый номер числа:");
            Console.WriteLine(Fib(Convert.ToInt32(Console.ReadLine())));
        }

        #region Lesson practice
        static ref int GetMin(int[] data)
        {
            ref int minValue = ref data[0];

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < minValue)
                {
                    minValue = ref data[i];
                }
            }
            return ref minValue;
        }
        static string[] ReplaceArray(string[] data)
        {
            data = new[] { "replaced", "replaced", "replaced" };
            return data;
        }
        static string[] ReplaceArrayByRef(ref string[] data)
        {
            data = new[] { "ref", "ref", "ref" };
            return data;
        }
        static void PrintArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i != arr.Length - 1)
                    Console.Write(", ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void ChangeArrIndexVal(int[] arr, int index, int val)
        {
            arr[index] = val;
        }
        #endregion

        /// <summary>
        /// Написать метод GetFullName(string firstName, string lastName, string patronymic),
        /// принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО.
        /// Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns>Полное ФИО</returns>
        static string GetFullName(string firstName, string lastName, string patronymic) => $"{lastName} {firstName} {patronymic}";

        /// <summary>
        /// Написать программу, принимающую на вход строку — набор чисел,
        /// разделенных пробелом, и возвращающую число — сумму всех чисел в строке.
        /// Ввести данные с клавиатуры и вывести результат на экран.
        /// </summary>
        /// <param name="numbers">Строка чисел</param>
        /// <returns>Сумма чисел в строке</returns>
        static int StringNumbersSum(string numbers) => numbers.Split(" ").Select(s => Convert.ToInt32(s)).Sum();

        /// <summary>
        /// Написать метод по определению времени года.
        /// На вход подаётся число– порядковый номер месяца.
        /// На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn.
        /// </summary>
        /// <param name="number">Номер месяца</param>
        /// <returns>Enum сезона</returns>
        static Seasons GetEnumSeason(int number)
        {
            if (number == 3 || number == 4 || number == 5)
                return Seasons.Spring;
            if (number == 6 || number == 7 || number == 8)
                return Seasons.Summer;
            if (number == 9 || number == 10 || number == 11)
                return Seasons.Autumn;
            return Seasons.Winter;
        }
        /// <summary>
        /// Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень).
        /// </summary>
        /// <param name="season">Сезон Enum</param>
        /// <returns>Название сезона</returns>
        static string GetSeasonName(Seasons season) => season switch
        {
            Seasons.Spring => "Весна",
            Seasons.Summer => "Лето",
            Seasons.Autumn => "Осень",
            _ => "Зима"
        };

        /// <summary>
        /// Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
        /// </summary>
        /// <param name="n">Номер числа</param>
        /// <returns>Число Фибоначчи</returns>
        static int Fib(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1 || n == 2)
                return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
    internal enum Seasons
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }
}