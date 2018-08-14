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
     * Задание №6
     * Написать игру “Верю. Не верю”. В файле хранятся некоторые данные и правда это или нет.
     * Например: “Шариковую ручку изобрели в древнем Египте”, “Да”.
     * Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
     * Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы. Список вопросов ищите во вложении или можно воспользоваться Интернетом.
     */
    class Task6
    {
        public static void Go()
        {
            bool exit = false;
            const int maxQuestions = 5; //Кол-во вопросов в раунде игры
            Random r = new Random();
            string fileName = "..\\..\\Data\\BelieveOrNotBelieve.txt";
            // Приветствие и печать правил игры
            CommonMethods.ColoredWriteLine(TasksDescription.Task6Description, ConsoleColor.Cyan);
            BelieveOrNot[] believeOrNot = BelieveOrNot.GenerateFromFile(fileName);
            int[] questionsNumbers = new int[maxQuestions];
            //Если оставить массив, проиницилизированным нолями, вопрос с индексом ноль никогда не попадёт в выборку
            for (int j = 0; j < questionsNumbers.Length; j++)
                questionsNumbers[j] = believeOrNot.Length + 1; // Таким образом, массив проинициализирован индексами, для которых непредусмотрены вопросы

            while (!exit)
            {
                int i = 0;
                while (i < maxQuestions) // Заполняем массив неповторяющимися номерами вопросов, которые будут заданы игроку
                {
                    int nextQuestion = r.Next(0, believeOrNot.Length);
                    if (RepeatedQuestionsCheck(questionsNumbers, nextQuestion))
                    {
                        questionsNumbers[i] = nextQuestion;
                        i++;
                    }
                }
                i = 0;
                bool restart = false; // начать заново
                int score = 0; // счет игрока
                bool skip = false; // Если для ответа введён некорректный символ, пропускаем ход
                CommonMethods.ColoredWriteLine(TasksDescription.StartGame, ConsoleColor.Magenta);
                while (!restart && i != questionsNumbers.Length)
                {
                    if (!skip)
                        CommonMethods.ColoredWriteLine(believeOrNot[questionsNumbers[i]].Question, ConsoleColor.Yellow);
                    skip = false;
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "+": // Верю
                            if (believeOrNot[questionsNumbers[i]].Answer)
                            {
                                score++;
                                CommonMethods.ColoredWriteLine("Верно!", ConsoleColor.Green);
                            } else
                                CommonMethods.ColoredWriteLine("Не верно!", ConsoleColor.Red);
                            break;
                        case "-": // Не верю
                            if (!believeOrNot[questionsNumbers[i]].Answer)
                            {
                                score++;
                                CommonMethods.ColoredWriteLine("Верно!", ConsoleColor.Green);
                            } else
                                CommonMethods.ColoredWriteLine("Не верно!", ConsoleColor.Red);
                            break;
                        case "r": // Рестарт
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
                    {
                        if (i++ == questionsNumbers.Length - 1)
                        {
                            CommonMethods.ColoredWriteLine("Поздравляем!\nВы закончили игру со счетом: " + score + " из " + questionsNumbers.Length, ConsoleColor.Cyan);
                            exit = !IsAnotherRound();
                            break;
                        }
                    }
                }
                if (exit)
                    break;
                // Задаём вопросы игроку
            }

        }
        /// <summary>
        /// метод проверки повторяющихся вопросов
        /// </summary>
        /// <param name="a">Массив уже выбранных вопросов</param>
        /// <param name="q">Номер выбранного вопроса</param>
        /// <returns>Подходит или нет</returns>
        static bool RepeatedQuestionsCheck(int[] a, int q)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == q)
                    return false;
            }
            return true;
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