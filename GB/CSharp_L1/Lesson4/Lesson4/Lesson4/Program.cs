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
            CommonMethods.CenterOutput();
            bool exit = false;
            while (!exit)
            {
                CommonMethods.ColoredWriteLine(TasksDescription.TaskList, ConsoleColor.Magenta);
                int choice = CommonMethods.SetIntParametr();
                switch (choice)
                {
                    case 0:
                        CommonMethods.ColoredWriteLine("Всего доброго!", ConsoleColor.Cyan);
                        exit = true;
                        break;

                    #region Задание 1
                    case 1:
                        Task1.Go();
                        break;
                    #endregion

                    #region Задание 2
                    case 2:
                        Task2.Go();
                        break;
                    #endregion

                    #region Задание 3
                    case 3:
                        Task3.Go();
                        break;
                    #endregion

                    #region Задание 4
                    case 4:
                        Task4.Go();
                        break;
                    #endregion

                    #region Задание 5
                    case 5:
                        Task5.Go();
                        break;
                    #endregion

                    #region Задание 6
                    case 6:
                        Task6.Go();
                        break;
                    #endregion

                    default:
                        CommonMethods.ColoredWriteLine("Пункт не предусматривается системой!", ConsoleColor.Red);
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
