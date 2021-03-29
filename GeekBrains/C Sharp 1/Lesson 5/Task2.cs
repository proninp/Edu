using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5
{
    class Task2
    {
        public static void Go()
        {
            Console.WriteLine("\nTask 2.\n");
            Console.WriteLine(">> Enter your message: ");
            MyString s = new MyString(Console.ReadLine());

            #region a)
            Console.WriteLine("\n> Print only the words of the message that contain no more than n letters.\nEnter max letters count for your message words:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n> Words (without regular expression): ");
            Console.WriteLine(s.CheckWordsLength(n));
            Console.WriteLine("\n> Words (with regular expression: ");
            Console.WriteLine(s.RegexCheckWordsLength(n));
            #endregion

            #region b)
            Console.WriteLine("> Remove all words that end with the specified character from the message.\nEnter the ending symbol:");
            string st = Console.ReadLine();
            Console.WriteLine("\n> Words (without regular expression): ");
            Console.WriteLine(s.DeleteWords(st));
            Console.WriteLine("\n> Words (with regular expression: ");
            Console.WriteLine(s.RegexDeleteWords(st));
            #endregion

            #region c)
            Console.WriteLine("\n> Find the longest word in the message:");
            Console.WriteLine(s.FindLongestWord());
            #endregion

            #region d)
            Console.WriteLine("\n> Generate a string using StringBuilder from the longest words of the message:");
            s.FindAllLongestWords();
            s.PrintSb();
            #endregion

            #region e)
            Console.WriteLine("\n> Create a method that performs frequency analysis of the text.");
            Console.WriteLine(">> Enter text:");
            string text = Console.ReadLine();
            Console.WriteLine(">> Enter words:");
            string words = Console.ReadLine();
            MyString line = new MyString(words, text);
            line.WordsFrequency(true);
            #endregion
        }
    }
}
