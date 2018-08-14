using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonMethods.CenterOutput();
            bool exit = false;
            while (!exit)
            {
                CommonMethods.ColoredWriteLine(TextConstants.TASK_LIST, ConsoleColor.Magenta);
                int choice = CommonMethods.SetIntParametr();
                switch (choice)
                {
                    case 0:
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

                    default:
                        CommonMethods.ColoredWriteLine("Пункт не предусматривается системой!", ConsoleColor.Red);
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
