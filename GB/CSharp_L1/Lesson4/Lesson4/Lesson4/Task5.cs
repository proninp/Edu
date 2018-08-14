using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №5
     * Существует алгоритмическая игра “Удвоитель”.
     * В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число шагов.
     * Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1.
     * Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число, которого нужно достичь, конструктор, в котором задается конечное число.
     * Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое возвращает текущее значение, свойство Finish,которое возвращает конечное значение.
     * Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек. выбирая из меню на экране, отдает команды удвоителю и старается получить это число за наименьшее число ходов.
     * Если человек получает число больше положенного, игра прекращается.
     */
    class Task5
    {
        /// <summary>
        /// Игра "Удвоитель"
        /// </summary>
        public static void Go()
        {
            // Приветствие и печать правил игры
            CommonMethods.ColoredWriteLine(TasksDescription.Task5Description, ConsoleColor.Cyan);
            Random r = new Random();
            bool exit = false;
            while (!exit) // Внешний цикл отвечает за выход из игры
            {
                bool restart = false;
                CommonMethods.ColoredWriteLine(TasksDescription.StartGame, ConsoleColor.Magenta);
                int count = 0; // Кол-во шагов
                Doubler d = new Doubler(0, 100, r);
                CommonMethods.ColoredWriteLine("Компьютер загадал число: " + d.Finish, ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine("Ваше число: " + d.Current, ConsoleColor.Cyan);
                bool skip = false; // Если для ответа введён некорректный символ, пропускаем ход
                while (!restart) // Цикл отвечает за рестарт игры
                {
                    if (count == 0 && !skip) // Выводим список возможных действий только при новом старте
                        CommonMethods.ColoredWriteLine(TasksDescription.Action, ConsoleColor.Yellow);
                    skip = false;
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "+": // Прибавить единицу
                            d.Increase();
                            break;
                        case "*": // Удвоить
                            d.MultiTwice();
                            break;
                        case "r": // Сбросить до единицы
                            d.Reset();
                            break;
                        case "s": // Начать заново
                            restart = true;
                            break;
                        case "q": // Выход из игры
                            exit = true;
                            break;
                        default:
                            CommonMethods.ColoredWriteLine("Непредвиденное действие!", ConsoleColor.Red);
                            skip = true;
                            break;
                    }
                    if (restart || exit)
                        break;
                    if (!skip)
                        count++;
                    if (d.Current == d.Finish)
                    {
                        CommonMethods.ColoredWriteLine("Поздравляем! Вы выиграли!\nКол-во шагов: " + count, ConsoleColor.Green);
                        exit = !IsAnotherRound();
                        break;
                    } else if (d.Current > d.Finish)
                    {
                        CommonMethods.ColoredWriteLine("Увы, но вы проиграли..!", ConsoleColor.Red);
                        exit = !IsAnotherRound();
                        break;
                    } else
                    {
                        if (!skip)
                        {
                            CommonMethods.ColoredWrite($"Ваше число {d.Current} всё еще недотягивает до ", ConsoleColor.Cyan);
                            CommonMethods.ColoredWriteLine(d.Finish.ToString(), ConsoleColor.Magenta);
                        }
                    }
                }
                if (exit)
                    break;
            }
        }
        /// <summary>
        /// Метод определяет, будет ли игрок участвовать в следующем раунде
        /// </summary>
        /// <returns>Да/Нет</returns>
        static bool IsAnotherRound()
        {
            CommonMethods.ColoredWriteLine("Жнлаете еще сыграть?\nВыберите \"+\", если хотите продолжить или нажмите любую клавишк, чтобы выйти.", ConsoleColor.Yellow);
            return Console.ReadLine().Equals("+");
        }
    }
}
