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
     * Задание №4
     * а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
     * Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива,
     * свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
     * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
     */
    class Task4
    {
        /// <summary>
        /// Метод, демонстрирующий работу с двумерным массивом
        /// </summary>
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task4Description, ConsoleColor.Cyan);
            string fileName = "..\\..\\Data\\Task4Data.txt";
            CommonMethods.ColoredWriteLine("Введите размерность массива:", ConsoleColor.Yellow);
            int n = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите значение минимального эл-та массива:", ConsoleColor.Yellow);
            int rangeMin = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите значение максимального эл-та массива:", ConsoleColor.Yellow);
            int rangeMax = CommonMethods.SetIntParametr();
            if (rangeMax < rangeMin)
                CommonMethods.Swap(ref rangeMin, ref rangeMax);
            MyArrayTwoDim myArray = new MyArrayTwoDim(n, rangeMin, rangeMax);
            CommonMethods.ColoredWriteLine(myArray.ToString(), ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Сумма эл-ов массива:\n{myArray.Sum()}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine("Введите нижнее ограничение элементов для подсчета суммы:", ConsoleColor.Yellow);
            int constraint = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine($"Сумма эл-ов массива, больше {constraint}:\n{myArray.Sum(constraint)}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Минимальный элемент:\n{myArray.Min}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Мксимальный элемент:\n{myArray.Max}", ConsoleColor.Cyan);

            myArray.IndexOfMax(out int[] iom);
            CommonMethods.ColoredWriteLine($"Номер максимального элемента:\n[{iom[0]}, {iom[1]}]", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine("Чтение массива из файла:", ConsoleColor.Yellow);
            MyArrayTwoDim mySecArray = new MyArrayTwoDim(fileName);
            CommonMethods.ColoredWriteLine($"{mySecArray.ToString()}", ConsoleColor.Cyan);
            myArray.WriteToFile(fileName);

            CommonMethods.ColoredWriteLine("исходный массив успешно записан в файл!", ConsoleColor.Yellow);
        }
    }
}
