using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Lesson_5
{
    class MyString
    {
        string message;
        string[] array;
        List<string> list;
        StringBuilder sb;
        string text;
        Dictionary<string, int> keyValuePairs;

        public string Message { get; set; }
        public string[] Array { get; set; }
        public List<string> List { get; set; }
        public StringBuilder Sb { get; set; }
        public string Text { get; set; }
        public Dictionary<string, int> KeyValuePairs { get; set; }

        public MyString(string s)
        {
            message = s;
            array = message.Replace(", ", ",").Replace(". ", ".").Split(new char[] { ' ', ',', '.', ';', ':' });
            list = new List<string>(array);
            sb = new StringBuilder();
        }
        public MyString(string s, string text): this(s) => this.text = text;

        /// <summary>
        /// Output only those message words that contain no more than n letters without regular expression
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CheckWordsLength(int n) => string.Join(" ", array.Where(st => st.Length <= n));
        
        /// <summary>
        /// Output only those message words that contain no more than n letters using a regular expression
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string RegexCheckWordsLength(int n) => new Regex("\\b\\w{" + (++n) + ",}\\s?\\b").Replace(message, " ").Replace("  ", " ").Trim();

        /// <summary>
        /// Removing words from a message that end with a specific character
        /// </summary>
        /// <param name="symbol">Символ</param>
        /// <returns>Result message</returns>
        public string DeleteWords(string symbol) => string.Join(" ", array.Except(array.Where(s => s.EndsWith(symbol)))).Replace("  ", " ").Trim();

        /// <summary>
        /// Removing words from a message that end with a specific character using a regular expression
        /// </summary>
        /// <param name="symbol">Символ</param>
        /// <returns>Result message</returns>
        public string RegexDeleteWords(string symbol) => new Regex("\\w*" + symbol + "\\s?\\b").Replace(message, "");
        
        /// <summary>
        /// The longest word in message search
        /// </summary>
        /// <returns>The longest string</returns>
        public string FindLongestWord() => array.OrderByDescending(s => s.Length).First();

        /// <summary>
        /// The longest words in message search
        /// </summary>
        public void FindAllLongestWords()
        {
            var sl = list.Where(s => s.Length == list.Max(st => st.Length));
            foreach(var s in sl)
                sb.Append(s + " ");
            sb.Remove(sb.Length - 1, 1);
        }

        /// <summary>
        /// Print stringbuilder value
        /// </summary>
        public void PrintSb() => Console.WriteLine(sb.ToString());

        /// <summary>
        /// Get key-value pairs
        /// </summary>
        public void WordsFrequency(bool isPrint)
        {
            keyValuePairs = new Dictionary<string, int>();
            var list = array.Distinct().ToList();            
            foreach (var word in list)
                while (text.Contains(word))
                {
                    text = text.Replace(word, "");
                    if (keyValuePairs.ContainsKey(word))
                        keyValuePairs[word] = ++keyValuePairs[word];
                    else
                        keyValuePairs.Add(word, 1);
                }
            if (isPrint)
                PrintDictionary();
        }
        /// <summary>
        /// Print dictionary
        /// </summary>
        public void PrintDictionary()
        {
            Console.WriteLine("\nFrequency array:");
            foreach (var keyValuePair in keyValuePairs)
                Console.WriteLine($"Key word: {keyValuePair.Key}; frequency: {keyValuePair.Value}");
        }
    }
}
