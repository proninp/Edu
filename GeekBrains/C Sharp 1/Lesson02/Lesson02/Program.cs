using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Task1(out float avgTemp);
            Task2(out int monthNo);
            Task3();
            Task4();
            Task5(monthNo, avgTemp);
            Task6();

            Console.ReadLine();
        }
        /// <summary>
        /// Запросить у пользователя минимальную и максимальную температуру за сутки и вывести
        /// среднесуточную температуру.
        /// </summary>
        public static void Task1(out float avg)
        {
            Console.WriteLine("Задача 1");
            Console.WriteLine("Введите минимальную температуру:");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальную температуру:");
            int max = Convert.ToInt32(Console.ReadLine());
            avg = (float)(max + min) / 2;
            Console.WriteLine($"Среднесуточная температура: {string.Format("{0:N2}", avg)}");
        }
        /// <summary>
        /// Запросить у пользователя порядковый номер текущего месяца и вывести его название.
        /// </summary>
        public static void Task2(out int monthNo)
        {
            monthNo = 0;
            Console.WriteLine("\nЗадача 2");
            Console.WriteLine("Введите номер текущего месяца:");
            monthNo = Convert.ToInt32(Console.ReadLine());
            if (monthNo < 1 || monthNo > 12)
                Console.WriteLine("Некорректный номер месяца. Может быть от 1 до 12.");
            else
                Console.WriteLine(new DateTime(DateTime.Now.Year, monthNo, DateTime.Now.Day).ToString("MMMM", CultureInfo.CurrentCulture));
        }
        /// <summary>
        /// Определить, является ли введённое пользователем число чётным.
        /// </summary>
        public static void Task3()
        {
            Console.WriteLine("\nЗадача 3");
            Console.WriteLine("Введите число:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((a % 2 == 0 ? "Четное" : "Нечетное"));
        }
        /// <summary>
        /// Для полного закрепления понимания простых типов найдите любой чек, либо фотографию
        /// этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических,
        /// по вашему мнению, данных(это может быть дата, название магазина, сумма покупок)
        /// подставляйте переменные, которые были заранее заготовлены до вывода на консоль.

        /// </summary>
        public static void Task4()
        {
            // Я понимаю, как работают простые типы, задание по поиску чека и копипастом его в консоль - нецелесообразное для меня
            // Ниже сделал упрощенный пример задания в целях экономии времени
            Console.WriteLine("\nЗадача 4");
            StringBuilder builder = new StringBuilder();
            int i = 5;
            float f = 111.1f;
            builder.Append("Пример строки");
            builder.Append("\n");
            builder.Append($"Пример с int: {i}");
            builder.Append("\n");
            builder.Append($"Пример с Datetime: {DateTime.Now.ToString("dd.mm.yyyy")}");
            builder.Append("\n");
            builder.Append($"Пример с float: {f}");
            Console.WriteLine(builder.ToString());
        }
        /// <summary>
        /// Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
        /// </summary>
        public static void Task5(int monthNo, float avgTemperature)
        {
            Console.WriteLine("\nЗадача 5");
            if ((monthNo == 1 || monthNo == 2 || monthNo == 12) && (avgTemperature > 0))
                Console.WriteLine("Дождливая зима");
            else
                Console.WriteLine("\n");
        }
        /// <summary>
        /// Для полного закрепления битовых масок, попытайтесь создать универсальную структуру
        /// расписания недели, к примеру, чтобы описать работу какого либо офиса.Явный пример -
        /// воскресенья и выведите его на экран консоли.
        /// </summary>
        public static void Task6()
        {
            Console.WriteLine("\nЗадача 6");
            int[] offices = { 0b1111100, 0b0111110, 0b0011111 };
            int[] week = { 0b1000000, 0b0100000, 0b0010000, 0b0010000, 0b0000100, 0b0000010, 0b0000001 };
            string[] dayName = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
            for (int i = 0; i < offices.Length; i++)
            {
                Console.WriteLine($"Расписание работы офиса: {i+1}");
                string office1Schedule = "";
                for (int j = 0; j < week.Length; j++)
                    if ((week[j] & offices[i]) > 0)
                        JoinLines(ref office1Schedule, dayName[j], ", ");
                Console.WriteLine(office1Schedule);
            }
        }
        static void JoinLines(ref string line, string subLine, string separator)
        {
            if (subLine == "")
                return;
            line += ((line.Length > 0) ? separator : "") + subLine;
        }
    }
}
