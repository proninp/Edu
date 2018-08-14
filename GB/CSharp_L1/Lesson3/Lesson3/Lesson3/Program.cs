using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Домашнее задание после урока №3
     */
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

                    default:
                        CommonMethods.ColoredWriteLine("Пункт не предусматривается системой!", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
