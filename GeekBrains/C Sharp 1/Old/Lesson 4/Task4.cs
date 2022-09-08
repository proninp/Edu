using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lesson_4
{
    class Task4
    {
        struct Account
        {
            string login;
            string password;

            public string Login { get => login; set => login = value; }
            public string Password { get => password; set => password = value; }
            public Account(string login, string password)
            {
                this.login = login;
                this.password = password;
            }
            public Account(string[] sa) : this("", "")
            {
                if (sa.Length == 2)
                {
                    login = sa[0];
                    password = sa[1];
                }
            }
            public void Print() => Console.WriteLine($"{login} {password}");
            public override bool Equals(object obj)
            {
                if (!(obj is Account))
                    return false;
                Account account = (Account)obj;
                return account.login == login && account.password == password;
            }

            public override int GetHashCode()
            {
                int hashCode = -1761403500;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(login);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
                return hashCode;
            }
        }

        public static void Go()
        {
            Console.WriteLine("\nTask 4\n");
            const string FILENAME = "..\\..\\Data\\Task4Data.txt";
            if (File.Exists(FILENAME))
            {
                List<Account> accounts = new List<Account>();
                ReadLogPasFromFile(FILENAME, accounts);
                Console.WriteLine("Readed logins with passwords:");
                foreach (var acc in accounts)
                    acc.Print();
                Account correct = accounts.Last();
                Console.WriteLine("\nType correct login and password separated with whitespace (the last one is correct):");
                string s = Console.ReadLine();
                Account a;
                try
                {
                    a = new Account(s.Split(' '));
                    if (a.Equals(correct))
                        Console.WriteLine("Authorized.");
                    else
                        Console.WriteLine("Incorrect credentials.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect pair of credentials. " + ex.Message);
                }
            }   
            else
                Console.WriteLine("File not found.");

        }
        static void ReadLogPasFromFile(string fileName, List<Account> accounts)
        {
            string[] s = File.ReadAllLines(fileName);
            for (int i = 0; i < s.Length; i++)
                accounts.Add(new Account(s[i].Split(' ')));
        }
    }
}
