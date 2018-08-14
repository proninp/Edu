using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
        class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.UserName);
            Console.ReadLine();
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.WriteLine("Приветствую!\n" +
            //    "Меня зовут Paul Pronin!");
            //bool exit = false;
            //while (!exit)
            //{
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("Выберите задание для выполнения:\n- 1\n- 2\n- 3\n- 4\n- 5/6\nДля выхода нажмите 0.");
            //    int choice = Additional.SetIntParametr();
            //    switch (choice)
            //    {
            //        case 0:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine("Всего доброго!");
            //            exit = true;
            //            break;

            //        #region Задание 1
            //        case 1:

            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task1Text);
            //            Task1.Go();
            //            break;
            //        #endregion

            //        #region Задание 2
            //        case 2:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task2Text);
            //            Task2.Go();
            //            break;
            //        #endregion

            //        #region Задание 3
            //        case 3:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task3Text);
            //            Task3.Go();
            //            break;
            //        #endregion

            //        #region Задание 4
            //        case 4:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task4Text);
            //            Task4.Go();
            //            break;
            //        #endregion

            //        #region Задание 5 и 6
            //        case 5:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task5Text);
            //            Task5.Go();
            //            break;
            //        case 6:
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //            Console.WriteLine(Additional.task5Text);
            //            Task5.Go();
            //            break;
            //        #endregion

            //        default:
            //            Console.WriteLine("Пункт не предусматривается системой!");
            //            break;
            //    }
            //}

        }
    }
}