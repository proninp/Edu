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
     * Задание №2
     * а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
     * Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива,
     * Метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.
     * В Main продемонстрировать работу класса.
     * б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
     * 
     * Реализация класса одномерного массива реализована в классе MyArray, файла MyArray.cs
     */
    class Task2
    {
        public static void Go()
        {
            string fileName = "..\\..\\Data\\Task2Data.txt";
            CommonMethods.ColoredWriteLine(TasksDescription.Task2Description, ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine("Введите кол-во эл-тов массива:", ConsoleColor.Yellow);
            int n = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите значение первого эл-та массива:", ConsoleColor.Yellow);
            int fEl = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите шаг для значений эл-ов массива:", ConsoleColor.Yellow);
            int step = CommonMethods.SetIntParametr();
            MyArray myArray = new MyArray(n, fEl, step);
            CommonMethods.ColoredWriteLine(myArray.ToString(), ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Сумма эл-ов массива:\n{myArray.Sum}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine("Введите число, на которое хотите умножить эл-ты массива:", ConsoleColor.Yellow);
            int mlt = CommonMethods.SetIntParametr();
            myArray.Multi(mlt);
            CommonMethods.ColoredWriteLine($"Массив:\n{myArray.ToString()}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Мксимальный элемент:\n{myArray.Max}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine($"Кол-во максимальных эл-ов:\n{myArray.MaxCount}", ConsoleColor.Cyan);

            CommonMethods.ColoredWriteLine("Чтение массива из файла:", ConsoleColor.Yellow);
            myArray = new MyArray(fileName);
            CommonMethods.ColoredWriteLine($"Массив:\n{myArray.ToString()}", ConsoleColor.Cyan);

            myArray.Inverse();
            CommonMethods.ColoredWriteLine($"Инверсия массива:\n{myArray.ToString()}", ConsoleColor.Cyan);

            myArray.WriteToFile(fileName);
            CommonMethods.ColoredWriteLine("Массив успешно записан в файл!", ConsoleColor.Yellow);
        }
    }
}