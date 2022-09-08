using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5
{
    class Task1
    {
        public static void Go()
        {
            Console.WriteLine("Task 1.\n");
            Console.WriteLine(">> Enter login. The login must contain from two to ten characters, only letters or numbers, and the number cannot be the first.");
            string s = Console.ReadLine();
            Console.WriteLine("> Check without Regular expression:");
            Authorization(s, false);
            Console.WriteLine("> Check with Regular expression:");
            Authorization(s, true);
            Console.WriteLine(@"RegEx: ^[A - Za - z][A - Za - z0 - 9]{ 1,9}");
        }
        static bool Check(string s) => !(s.Length == 0 || char.IsDigit(s[0]) || (s.Length < 2 || s.Length > 10)) && s.All(c => char.IsLetterOrDigit(c));
        static bool RegexCheck(string s) => new Regex("^[A-Za-z][A-Za-z0-9]{1,9}$").IsMatch(s);
        static bool Authorization(string s, bool isRegExMethod)
        {            
            bool check = (isRegExMethod) ? RegexCheck(s) : Check(s);
            if (check)
                Console.WriteLine("Authorized.");
            else
                Console.WriteLine("Authorization failed.");
            return check;
        }
    }
}
