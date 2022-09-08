using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    class Program
    {
        /*
         * Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%, сегодня %дата%».
         * Имя пользователя сохранить из консоли в промежуточную переменную. Поставить точку останова и
         * посмотреть значение этой переменной в режиме отладки. Запустить исполняемый файл через
         * системный терминал.
         */
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Hello, {Environment.UserName}! Enter your name: ");
            string name = Console.ReadLine();
            if (name.Length == 0)
                name = Environment.UserName;
            Console.WriteLine($"Nice to meet you {name}! Today is {DateTime.Now.ToShortDateString()}");
            Console.ReadLine();
        }
    }
}
