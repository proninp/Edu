using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №4
     * Задача ЕГЭ.
     * Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трех худших по среднему баллу учеников.
     * Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трех худших, то следует вывести и их фамилии и имена.
     */
    class Task4
    {
        public static void Go()
        {
            if (File.Exists(TextConstants.FILE_NAME))
            {
                CommonMethods.ColoredWriteLine(TextConstants.TASK4_DESCR, ConsoleColor.Yellow);
                DateTime start = DateTime.Now;
                StreamReader sr = new StreamReader(TextConstants.FILE_NAME);
                int.TryParse(sr.ReadLine(), out int n);     // Кол-во строк в результатах экзаменов
                double[] avereges = new double[n];          // Массив, хранящий среднее значения для каждого ученика
                int[] minElementsIndexes = new int[n];      // Массив, хранящий индексы массива результатов экзаменов, у котрых среднее значение подходит под условие задачи
                double[] minElementsValues = new double[n]; // Массив значений минимальных средних значений
                string[] examsInfo = new string[n];         // Массив результатов экзаменов
                for (int i = 0; i < examsInfo.Length; i++)
                {
                    examsInfo[i] = sr.ReadLine();
                    char [] marks = new char[3] { examsInfo[i][examsInfo[i].Length - 1], examsInfo[i][examsInfo[i].Length - 3], examsInfo[i][examsInfo[i].Length - 5] }; // Массив оценок
                    avereges[i] = (double)(marks[0] + marks[1] + marks[2] - 48 * 3) / 3;
                }
                int k = 0; // Счетчик для массивов minElementsIndexes и minElementsValues
                for (int i = 0; i < 3; i++) // Согласно задания необходимо вывести три худших балла
                {
                    double min = avereges.Min();                // Худший средний балл
                    for (int j = 0; j < avereges.Length; j++)
                        if (avereges[j] == min)
                        {
                            minElementsIndexes[k] = j;          // Заполняем массив индексов минимальных элементов
                            minElementsValues[k] = avereges[j]; // Заполняем массив значений минимальных элементов
                            k++;
                            avereges[j] = int.MaxValue;         // Для того, чтобы элемент не вошел повторно, увеличиваем его значение
                        }
                }
                minElementsIndexes[k] = -1;                     // -1 - как флаг окончания заполнения массива индексов

                StringBuilder sb = new StringBuilder(n * examsInfo[0].Length); // Выделяем память под максимально-возможное количество элементов
                for (int i = 0; i < minElementsIndexes.Length; i++)
                {
                    if (minElementsIndexes[i] < 0) // Если встречаем флаг, завершаем заполнение
                        break;
                    string[] subAr = examsInfo[minElementsIndexes[i]].Split(' '); // Разбиваем элемент массива результатов экзаменов на массив элементов
                    sb.Append(((i == 0) ? "" : "\n")).Append(subAr[0]).Append(" ").Append(subAr[1]).Append("\t- ").Append(String.Format("{0:F2}", minElementsValues[i])); // Формируем вывод
                }
                CommonMethods.ColoredWriteLine(sb.ToString(), ConsoleColor.Cyan);
                CommonMethods.ColoredWriteLine(TextConstants.EXEC_TIME, ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine((DateTime.Now - start).ToString(), ConsoleColor.Cyan); // Замеряем время работы
            }
        }
    }
}
