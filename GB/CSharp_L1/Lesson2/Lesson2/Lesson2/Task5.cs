using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Задание №5
     * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает,
     * нужно ли человеку похудеть, набрать вес или все в норме;
     * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
     */
    class Task5
    {
        /// <summary>
        /// Запрашивает рост человека в см и вес в кг. Вычесляет его ИМТ, сообщает, нужно ли человеку похудеть, набрать вес или всё в норме. 
        /// При отклонении от нормы выдаёт информацию о том, сколько кг набрать или сколько кг скинуть для нормализации веса.
        /// </summary>
        public static void Go()
        {
            #region Инициализация констант, массивов ИМТ и их текстовых пояснений
            const int NORMAL_INDEX = 2; // Индекс верхенего значения нормы ИМТ в массиве indexes
            double[] indexes = new double[] {16, 18.5, 25, 30, 35, 40}; // показатели ИМТ
            string[,] stAr = new string[,] { // Двумерный массив текстовых описаний
                { "Выраженный дефицит массы тела.", "Надо срочно набирать" },
                { "Недостаточная (дефицит) масса тела.", "Надо набирать вес!"},
                {"Нома.","Ваш вес находится в норме!" },
                {"Избыточная масса тела (предожирение).", "Не мешало бы похудеть на" },
                { "Ожирение!", "Нужно сбросить" },
                { "Ожирение резкое!", "Очень срочно нужно похудеть на" },
                { "Очень резкое ожирение!", "Уже поздно, можно съесть еще пончик.\nШутка! Нужно худеть на"}
            };
            #endregion
            CommonMethods.ColoredWriteLine("Введите свой вес в килограммах:", ConsoleColor.Yellow);
            int w = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Введите свой рост в сантиметрах:", ConsoleColor.Yellow);
            double h = CommonMethods.SetDoubleParametr() / 100;
            double index = w / (h * h);
            CommonMethods.ColoredWriteLine($"\nИндекс массы тела = {index:F}", ConsoleColor.Cyan);
            for(int i = 0; i < indexes.Length; i++)
            {
                if (index < indexes[i])
                {
                    if (i == NORMAL_INDEX) // если ИМТ в норме, нам не нужно указывать, на сколько кг худеть или сколько кг набирать
                        CommonMethods.ColoredWriteLine($"{stAr[i, 0]}\n{stAr[i, 1]}", ConsoleColor.Cyan);
                    else
                        CommonMethods.ColoredWriteLine($"{stAr[i, 0]}\n{stAr[i, 1]} {GetWeightDiff(indexes[NORMAL_INDEX-1], indexes[NORMAL_INDEX], h, w):F} кг.", ConsoleColor.Cyan);
                    break;
                } else if (i == indexes.Length - 1) // т.к. размерности массивов ИМТ и текстовых описаний не совпадают, делаем исключение для index > 40
                {
                    CommonMethods.ColoredWriteLine($"{stAr[i+1, 0]}\n{stAr[i+1, 1]} {GetWeightDiff(indexes[NORMAL_INDEX - 1], indexes[NORMAL_INDEX], h, w):F} кг.", ConsoleColor.Cyan);
                }
            }
        }
        /// <summary>
        /// Метод возвращает разницу в килограммах между текущим весом человека и рекомендуемыми ВОЗ показателями ИМТ для указанного роста
        /// </summary>
        /// <param name="minNormalIndex">Минимальный показатель нормы ИМТ по ВОЗ</param>
        /// <param name="maxNormalIndex">Максимальный показатель нормы ИМТ по ВОЗ</param>
        /// <param name="h">Рост человека в метрах</param>
        /// <param name="w">Вес человека в килограммах</param>
        /// <returns>Разница в килограммах</returns>
        public static double GetWeightDiff(double minNormalIndex, double maxNormalIndex, double h, double w)
        {
            return (w / (h * h) < minNormalIndex) ? (h * h * minNormalIndex - w) : w - h * h * maxNormalIndex;

        }
    }
}