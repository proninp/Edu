using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Console.ReadLine();
        }
        #region Задача 1
        /// <summary>
        /// 1. Написать программу, выводящую элементы двухмерного массива по диагонали.
        /// </summary>
        public static void Task1()
        {
            Console.WriteLine("Задача 1");
            int len = 8;
            int delay = 100;
            int[,] a = new int[len, len];
            Point[,] positions = new Point[len, len];
            
            // Заполняем массив позиций
            int psddingTop = 3;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int paddingLeft = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = 1; // Заполняем массив значениями единиц
                    positions[i, j] = new Point(paddingLeft, psddingTop);
                    paddingLeft += 6;
                }
                psddingTop += 3;
            }

            // Выводим массив по диагонали, начиная с нижнего левго элемента (поднимаемся вверх и смещаемся вправо)
            for (int i = (len - 1); i >= 0; i--) // индексатор диагонали
            {
                int k = 0; // индексатор столбца
                for (int j = i; j < a.GetLength(0); j++) // индексатор строки
                {
                    SetCursorPosition(j, k, positions);
                    SetValueToConsole(a[j, k++], delay);
                }
            }
            // Обрабатываем вторую часть массива (спускаемся вниз и смещаемся вправо)
            int rightLim = len - 1;
            for (int i = 0; i < rightLim; i++) // индексатор диагонали
            {
                for (int j = 0; j < (rightLim - i); j++) // индексатор строки
                {
                    int k = j + i + 1; // индексатор столбца
                    SetCursorPosition(j, k, positions);
                    SetValueToConsole(a[j, k], delay);
                }
            }
            SetCursorPosition(positions.GetLength(0) - 1, 0, positions);
        }
        static void SetCursorPosition(int x, int y, Point[,] positions)
        {
            Point p = positions[x, y];
            Console.SetCursorPosition(p.X, p.Y);
        }
        static void SetValueToConsole(int val, int delay)
        {
            Console.Write(val);
            Thread.Sleep(delay);
        }
        #endregion
        /// <summary>
        /// Написать программу — телефонный справочник — создать двумерный массив 5*2, хранящий
        /// список телефонных контактов: первый элемент хранит имя контакта, второй — номер
        /// телефона/e-mail.
        /// </summary>
        public static void Task2()
        {
            Console.WriteLine("\n\nЗадача 2");
            string[,] pb = { { "Друзь Александр Абрамович", "druz.aa@gmail.com" },
                             { "Двенятин Федор Никитич", "dvenyatin.fn@gmail.com" },
                             { "Левин Борис Ефммович", "levin.be@gmail.com" },
                             { "Поташов Максим Оскарович", "potashov.mo@gmail.com" },
                             { "Сиднев Виктор Владимирович", "sidnev.vv@gmail.com" } };
            for (int i = 0; i < pb.GetLength(0); i++)
            {
                for (int j = 0; j < pb.GetLength(1); j++)
                    Console.Write(pb[i, j] + ((j > 0) ? "" : ",\t"));
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).
        /// </summary>
        public static void Task3()
        {
            Console.WriteLine("\nTask 3");
            string s = "Hello";
            Console.WriteLine("Способ 1:");
            Console.WriteLine(new string(s.Reverse().ToArray()));
            Console.WriteLine("Способ 2:");
            char[] a = s.ToArray();
            for (int i = 0; i < s.Length/2; i++)
            {
                char c = a[i];
                a[i] = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = c;
            }
            Console.WriteLine(new string(a));
        }

        #region Задача 4
        /// <summary>
        /// «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
        /// 
        /// Автоматическое формирование массива кораблей по правилам:
        ///     Корабли:
        ///         4 корабля по 1 палубе,
        ///         3 корабля по 2 палубы,
        ///         2 корабле по 3 палубы,
        ///         1 корабль с 4 палубами;
        ///     Расположение кораблей:
        ///         Корабли могут не располаться на смежных и пересекающихся клетках.
        /// 
        /// </summary>
        public static void Task4()
        {
            Console.WriteLine("\nЗадача 4");
            int len = 10;
            int[,] battleField = new int[len, len];
            // Заполнение поля
            for (int i = 0; i < battleField.GetLength(0); i++)
                for (int j = 0; j < battleField.GetLength(1); j++)
                    battleField[i, j] = 0;
            
            // Инициализация колучества палуб для кораблей и количества кораблей для каждой категории
            int[] shipsDecks = { 1, 2, 3, 4 }; // Палубы кораблей
            int[] shipsCount = { 4, 3, 2, 1 }; // Количество кораблей по палубам
            List<Ship> ships = new List<Ship>();

            // Создание кораблей и добавление их на поле
            for (int i = 0; i < shipsDecks.Length; i++)
                for (int j = 0; j < shipsCount[i]; j++)
                    ships.Add(new Ship(shipsDecks[i], battleField));

            PrintBattleField(battleField); // Вывод поля на экран


        }
        static void PrintBattleField(int[,] battleField)
        {
            ConsoleColor standard = Console.ForegroundColor;
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = 0; j < battleField.GetLength(1); j++)
                {
                    if (battleField[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("X\t");
                        Console.ForegroundColor = standard;
                    }
                    else
                        Console.Write("O\t");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
