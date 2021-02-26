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
     * Задание №3
     * 
     * Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
     * Предусмотреть методы сложения, вычитания, умножения и деления дробей.
     * Написать программу, демонстрирующую все разработанные элементы класса.
     * * Добавить упрощение дробей.
     */
    class Task3
    {
        public class FractNumber
        {
            #region Описание класса
            int num; // Числитель
            int denom; // Знаменатель
            int integerPart; // Целая часть
            string sign=""; // Знак дроби
            /// <summary>
            /// Свойство числителя
            /// </summary>
            public int Num
            {
                get { return num; }
                set
                {
                    if (value < 0)
                        sign = (sign.Equals("-") ? sign = "" : sign = "-"); // проверяем знак дроби
                    num = Math.Abs(value);
                }
            }
            /// <summary>
            /// Свойство знаменателя
            /// </summary>
            public int Denom
            {
                set
                {
                    if (value < 0)
                        sign = (sign.Equals("-") ? sign = "" : sign = "-"); // проверяем знак дроби
                    if (denom != 0)
                        denom = Math.Abs(value);
                }
                get { return denom; }
            }
            /// <summary>
            /// Свойство целой части дроби
            /// </summary>
            public int InegerPart { get; }

            /// <summary>
            /// Конструктор класса FractNumber
            /// </summary>
            /// <param name="num">Числитель</param>
            /// <param name="denom">Знаменатель</param>
            public FractNumber(int num, int denom)
            {
                // Определяем знак дроби
                if ((num < 0 && denom > 0) || (num > 0 && denom < 0))
                    sign = "-";
                this.num = Math.Abs(num);
                if (denom != 0)
                    this.denom = Math.Abs(denom);
                // Выделяем целую часть
                integerPart = this.num / this.denom;
                if (integerPart != 0)
                    this.num -= this.num / this.denom * this.denom;
                // Упрощаем дробь
                int gcd = Gcd(this.num, this.denom);
                this.num /= gcd;
                this.denom /= gcd;
            }
            #endregion

            #region Методы арифметических операций с дробями
            /// <summary>
            /// Сложение дробей
            /// </summary>
            /// <param name="x"></param>
            /// <returns>Результат сложения дробей</returns>
            public FractNumber Sum(FractNumber x)
            {
                PrepairFractions();
                x.PrepairFractions();
                // Вычисление для дробей с одинаковым знаменателем
                if (x.denom == denom)
                    return new FractNumber(num + x.num, denom);
                // Вычисление для дробей с разными знаменателями
                int lcm = Lcm(denom, x.denom);
                return new FractNumber(lcm / denom * num + lcm / x.denom * x.num, denom * lcm/denom);

            }
            /// <summary>
            /// Вычитание дробей реализуем через сложение с заменой знака
            /// </summary>
            /// <param name="x"></param>
            /// <returns>Разность дробей</returns>
            public FractNumber Subtraction(FractNumber x)
            {
                //x.Num = -x.num; тут была ошибка. После выполнения операции вычитания для второго числа менялся знак операции, т.к. программа крутится в цикле
                return Sum(new FractNumber(- x.num, x.denom));
            }
            /// <summary>
            /// Умножение дробей
            /// </summary>
            /// <param name="x"></param>
            /// <returns>Произведение дробей</returns>
            public FractNumber Multiply(FractNumber x)
            {
                PrepairFractions();
                x.PrepairFractions();
                return new FractNumber(num * x.num, denom * x.denom);
            }
            /// <summary>
            /// Деление дробей (реализуем через умножение)
            /// </summary>
            /// <param name="x">Делитель</param>
            /// <returns>Частное</returns>
            public FractNumber Division(FractNumber x)
            {
                // Исключаем целую часть без учета знака дроби
                x.num += denom * x.integerPart;
                x.integerPart = 0;
                // Меняем числитель и знаменатель местами
                CommonMethods.Swap(ref x.num, ref x.denom);
                return Multiply(x);
            }
            #endregion

            #region Вспомогательные методы
            /// <summary>
            /// Подготовка дроби к вычислениям
            /// </summary>
            void PrepairFractions()
            {
                // Убираем целую часть, полность переводим в дробь
                num += denom * integerPart;
                integerPart = 0;
                // Определяемся со знаком дроби
                num = ((sign.Equals("-")) ? -num : num);
                sign = "";
            }
            public override string ToString()
            {
                // тут тоже была ошибка, т.к. был неверно записан тернарный оператор
                if (num == 0 && integerPart == 0)
                    return "0";
                if (num == 0 && integerPart != 0)
                    return integerPart.ToString();
                return $"{sign}{((integerPart != 0) ? integerPart + ((integerPart.ToString()[integerPart.ToString().Length - 1] == '1') ? " целая " : " целых ") : "")}{num}/{denom}";
        }

            /// <summary>
            /// Метод нахождения НОД двух чисел
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns>Значение НОД</returns>
            static int Gcd(int x, int y)
            {
                while (y != 0)
                {
                    x %= y;
                    CommonMethods.Swap(ref x, ref y);
                }
                return x;
            }

            /// <summary>
            /// Метод для нахождения НОК двух чисел
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns>Значение НОК</returns>
            static int Lcm(int x, int y)
            {
                return x * y / Gcd(x, y);
            }
            #endregion
        }
        public static void Go()
        {
            CommonMethods.ColoredWriteLine(TasksDescription.Task3Text, ConsoleColor.Cyan);
            CommonMethods.ColoredWriteLine("Введите числитель первой дроби:", ConsoleColor.Yellow);
            int a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите знаменатель первой дроби:", ConsoleColor.Yellow);
            int b = CommonMethods.SetIntParametrExeptZero();
            FractNumber fn1 = new FractNumber(a, b);
            CommonMethods.ColoredWriteLine("Введите числитель второй дроби:", ConsoleColor.Yellow);
            a = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите знаменатель второй дроби:", ConsoleColor.Yellow);
            b = CommonMethods.SetIntParametrExeptZero();
            FractNumber fn2 = new FractNumber(a, b);
            bool exit = false;
            while (!exit)
            {
                CommonMethods.ColoredWriteLine("Выберите арифметическое действие:\n +\t: сложение;\n -\t: вычитание;\n *\t: умножение;\n /\t: деление;\n 0\t: завершить работу.", ConsoleColor.Magenta);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "+":
                        CommonMethods.ColoredWriteLine($"Результат выполнения операции сложения:\n{fn1.Sum(fn2)}", ConsoleColor.Cyan);
                        break;
                    case "-":
                        CommonMethods.ColoredWriteLine($"Результат выполнения операции вычитания:\n{fn1.Subtraction(fn2)}", ConsoleColor.Cyan);
                        break;
                    case "*":
                        CommonMethods.ColoredWriteLine($"Результат выполнения операции умножения:\n{fn1.Multiply(fn2)}", ConsoleColor.Cyan);
                        break;
                    case "/":
                        CommonMethods.ColoredWriteLine($"Результат выполнения операции деления:\n{fn1.Division(fn2)}", ConsoleColor.Cyan);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        CommonMethods.ColoredWriteLine("Пункт не предусматривается системой!", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}