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
     * Задание №1
     * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
     * б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;
     */
    class Task1
    {
        #region Описание структуры ComplexStruct для работы с комплексными числами
        public struct ComplexStruct
        {
            double im;
            double re;
            public double Im
            {
                get { return im; }
                set { im = value; }
            }

            public double Re
            {
                get { return re; }
                set { re = value; }
            }
            /// <summary>
            /// Конструктор структуры ComplexStruct для инициализации экземпляра струтуры.
            /// </summary>
            /// <param name="im">Коэффициент мнимой единицы</param>
            /// <param name="re">Вещественная часть числа</param>
            public ComplexStruct(double im, double re)
            {
                this.im = im;
                this.re = re;
            }
            /// <summary>
            /// Метод сложения двух экземпляров структуры
            /// </summary>
            /// <param name="x">Второе слагаемое</param>
            /// <returns>Сумма двух экземпляров структуры</returns>
            public ComplexStruct Plus(ComplexStruct x)
            {
                return new ComplexStruct(this.im + x.im, this.re + x.re);
            }
            /// <summary>
            /// Метод умножения двух экземпляров структуры
            /// </summary>
            /// <param name="x">Множитель</param>
            /// <returns>Произведение двух экземпляров структуры</returns>
            public ComplexStruct Multi(ComplexStruct x)
            {
                return new ComplexStruct(this.im * x.im + this.re * x.im, this.re * x.im - this.im * x.re);
            }
            /// <summary>
            /// Метод вычитания двух экземпляров структуры
            /// </summary>
            /// <param name="x">Вычитаемое</param>
            /// <returns>Разница</returns>
            public ComplexStruct Subtraction(ComplexStruct x)
            {
                return new ComplexStruct(this.im - x.im, this.re - x.re);
            }
            /// <summary>
            /// Переопределение метода ToString() для структуры
            /// </summary>
            /// <returns>Строковое представление экземпляра структуры</returns>
            public override string ToString()
            {
                return re + ((im.ToString()[0] == '-') ? (" " + im.ToString()[0] + " " + ((im == 0) ? "" : (im.ToString().Substring(1)))) : (" + " + ((im==0) ? "" : im.ToString()))) + "i";
            }
        }
        #endregion

        #region Описание класса ComplexClass для работы с комплексными числами
        public class ComplexClass
        {
            double im;
            double re;
            public double Im { get; set; }
            public double Re { get; set; }
            /// <summary>
            /// Конструктор класса ComplexClass для инициализации экземпляра класса.
            /// </summary>
            /// <param name="im">Коэффициент мнимой единицы</param>
            /// <param name="re">Вещественная часть числа</param>
            public ComplexClass(double im, double re)
            {
                this.im = im;
                this.re = re;
            }
            /// <summary>
            /// Метод сложения двух экземпляров класса
            /// </summary>
            /// <param name="x">Второе слагаемое</param>
            /// <returns>Сумма двух экземпляров класса</returns>
            public ComplexClass Plus(ComplexClass x)
            {
                return new ComplexClass(this.im + x.im, this.re + x.re);
            }
            /// <summary>
            /// Метод умножения двух экземпляров класса
            /// </summary>
            /// <param name="x">Множитель</param>
            /// <returns>Произведение двух экземпляров класса</returns>
            public ComplexClass Multi(ComplexClass x)
            {
                return new ComplexClass(this.im * x.im + this.re * x.im, this.re * x.im - this.im * x.re);
            }
            /// <summary>
            /// Метод вычитания двух экземпляров класса
            /// </summary>
            /// <param name="x">Вычитаемое</param>
            /// <returns>Разница</returns>
            public ComplexClass Subtraction(ComplexClass x)
            {
                return new ComplexClass(this.im - x.im, this.re - x.re);
            }
            /// <summary>
            /// Переопределение метода ToString() для класса
            /// </summary>
            /// <returns>Строковое представление экземпляра класса</returns>
            public override string ToString()
            {
                return re + ((im.ToString()[0] == '-') ? (" " + im.ToString()[0] + " " + ((im == 0) ? "" : (im.ToString().Substring(1)))) : (" + " + ((im == 0) ? "" : im.ToString()))) + "i";
            }
        }
        #endregion

        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task1Text, ConsoleColor.Cyan);

            #region Демонстрация работы структуры комплексных чисел
            CommonMethods.ColoredWriteLine("Демонстрация работы структуры.\nВведите вещественную часть первого комплексного числа:", ConsoleColor.Yellow);
            double cs1re = CommonMethods.SetDoubleParametr();
            CommonMethods.ColoredWriteLine("Введите коэффициент мнимой единицы первого комплексного числа:", ConsoleColor.Yellow);
            double cs1im = CommonMethods.SetDoubleParametr();
            ComplexStruct cs1 = new ComplexStruct(cs1im, cs1re);
            CommonMethods.ColoredWriteLine("Вы ввели комплексное число:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(cs1.ToString(), ConsoleColor.White);
            CommonMethods.ColoredWriteLine("Введите вещественную часть второго комплексного числа:", ConsoleColor.Yellow);
            double cs2re = CommonMethods.SetDoubleParametr();
            CommonMethods.ColoredWriteLine("Введите коэффициент мнимой единицы второго комплексного числа:", ConsoleColor.Yellow);
            double cs2im = CommonMethods.SetDoubleParametr();
            ComplexStruct cs2 = new ComplexStruct(cs2im, cs2re);
            CommonMethods.ColoredWriteLine("Вы ввели комплексное число:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(cs2.ToString(), ConsoleColor.White);
            CommonMethods.ColoredWriteLine("Сумма двух комплексных чисел:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(cs1.Plus(cs2).ToString(), ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine("Разница двух комплексных чисел:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(cs1.Subtraction(cs2).ToString(), ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine("Произведение двух комплексных чисел:", ConsoleColor.Yellow);
            CommonMethods.ColoredWriteLine(cs1.Multi(cs2).ToString(), ConsoleColor.Cyan);
            #endregion

            CommonMethods.ColoredWriteLine("Провести те же самые действия для демонстрации работы класса комплексных чисел?" +
                "\nВведите любой символ для подтверждения, либо нажмите Enter для отмены.", ConsoleColor.Yellow);
            if (Console.ReadLine() != "")
            {
                #region Демонстрация работы класса комплексных чисел
                CommonMethods.ColoredWriteLine("Демонстрация работы класса.\nВведите вещественную часть первого комплексного числа:", ConsoleColor.Yellow);
                double cc1re = CommonMethods.SetDoubleParametr();
                CommonMethods.ColoredWriteLine("Введите коэффициент мнимой единицы первого комплексного числа:", ConsoleColor.Yellow);
                double cс1im = CommonMethods.SetDoubleParametr();
                ComplexClass cc1 = new ComplexClass(cс1im, cc1re);
                CommonMethods.ColoredWriteLine("Вы ввели комплексное число:", ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine(cc1.ToString(), ConsoleColor.White);
                CommonMethods.ColoredWriteLine("Введите вещественную часть второго комплексного числа:", ConsoleColor.Yellow);
                double cc2re = CommonMethods.SetDoubleParametr();
                CommonMethods.ColoredWriteLine("Введите коэффициент мнимой единицы второго комплексного числа:", ConsoleColor.Yellow);
                double cc2im = CommonMethods.SetDoubleParametr();
                ComplexClass cc2 = new ComplexClass(cc2im, cc2re);
                CommonMethods.ColoredWriteLine("Вы ввели комплексное число:", ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine(cc2.ToString(), ConsoleColor.White);
                CommonMethods.ColoredWriteLine("Сумма двух комплексных чисел:", ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine(cc1.Plus(cc2).ToString(), ConsoleColor.Cyan);
                CommonMethods.ColoredWriteLine("Разница двух комплексных чисел:", ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine(cc1.Subtraction(cc2).ToString(), ConsoleColor.Cyan);
                CommonMethods.ColoredWriteLine("Произведение двух комплексных чисел:", ConsoleColor.Yellow);
                CommonMethods.ColoredWriteLine(cc1.Multi(cc2).ToString(), ConsoleColor.Cyan);
                #endregion
            }
        }
    }
}