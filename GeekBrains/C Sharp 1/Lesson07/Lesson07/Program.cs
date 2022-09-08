using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "some secret password";
            Console.WriteLine("Entere password");
            string input = Console.ReadLine();
            if (input == secret)
                Console.WriteLine("Welcome!");
        }
    }
}
