using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson08
{
    class Program
    {
        /// <summary>
        /// Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках
        /// приложения(application-scope). Запросить у пользователя имя, возраст и род деятельности, а затем
        /// сохранить данные в настройках.При следующем запуске отобразить эти сведения.Задать
        /// приложению версию и описание.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.WriteLine("Введите имя пользователя:");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Age))
            {
                Console.WriteLine("Введите возраст:");
                Properties.Settings.Default.Age = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.ActivityType))
            {
                Console.WriteLine("Введите род деятельности:");
                Properties.Settings.Default.ActivityType = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.UserName;
            string age = Properties.Settings.Default.Age;
            string activityType = Properties.Settings.Default.ActivityType;
            string greeting = Properties.Settings.Default.Greeting;
            Console.WriteLine($"{greeting}, {userName}!");
            Console.WriteLine($"Дополнительные сведения:\nВозраст {age}, {activityType}.");
            Console.ReadLine();
        }
    }
}
