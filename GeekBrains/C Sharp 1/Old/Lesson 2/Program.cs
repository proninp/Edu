using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonMethods.CenterOutput();
            bool exit = false;
            while (!exit)
            {
                CommonMethods.ColoredWriteLine("\nChoose task number:\n- 1\n- 2\n- 3\n- 4\n- 5\n- 6\n- 7\nTo exit press 0.", ConsoleColor.Magenta);
                int choice = CommonMethods.SetIntParametr();
                switch (choice)
                {
                    case 0:
                        CommonMethods.ColoredWriteLine("Good luck!", ConsoleColor.Cyan);
                        exit = true;
                        break;

                    #region Задание 1
                    case 1:
                        CommonMethods.ColoredWriteLine(TasksText.Task1Text, ConsoleColor.Cyan);
                        Task1.Go();
                        break;
                    #endregion

                    #region Задание 2
                    case 2:
                        CommonMethods.ColoredWriteLine(TasksText.Task2Text, ConsoleColor.Cyan);
                        Task2.Go();
                        break;
                    #endregion

                    #region Задание 3
                    case 3:
                        CommonMethods.ColoredWriteLine(TasksText.Task3Text, ConsoleColor.Cyan);
                        Task3.Go();
                        break;
                    #endregion

                    #region Задание 4
                    case 4:
                        CommonMethods.ColoredWriteLine(TasksText.Task4Text, ConsoleColor.Cyan);
                        Task4.Go();
                        break;
                    #endregion

                    #region Задание 5
                    case 5:
                        CommonMethods.ColoredWriteLine(TasksText.Task5Text, ConsoleColor.Cyan);
                        Task5.Go();
                        break;
                    #endregion

                    #region Задание 6
                    case 6:
                        CommonMethods.ColoredWriteLine(TasksText.Task6Text, ConsoleColor.Cyan);
                        Task6.Go();
                        break;
                    #endregion

                    #region Задание 7
                    case 7:
                        CommonMethods.ColoredWriteLine(TasksText.Task7Text, ConsoleColor.Cyan);
                        Task7.Go();
                        break;
                    #endregion

                    default:
                        CommonMethods.ColoredWriteLine("There is no such task number!", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}