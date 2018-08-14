using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lesson5
{
    class MyString
    {
        string message;
        string[] array;
        List<string> list;

        public string Message { get; set; }
        public string[] Array { get; set; }
        public List<string> List { get; set;}

        public MyString(string s)
        {
            message = s;
            array = message.Replace(", ", ",").Replace(". ", ".").Split(new char[] { ' ', ',', '.', ';', ':' }); // по сути нужно только для того, чтобы не делать дополнительные преобразования в методах
            list = new List<string>(message.Replace(", ", ",").Replace(". ", ".").Split(new char[] { ' ', ',', '.', ';', ':' })); // сразу создаём лист, для использования в дальнейшем
        }
        /// <summary>
        /// Вывод только тех слов сообщения, которые содержат не более чем n букв
        /// Пояснения:
        /// message.Replace(", ", ",").Replace(". ", ".") - если вдруг сообщение написано с разделителями, после которых идёт пробел
        /// Where(st => (st.Length <= n)  - условие выборки
        /// </summary>
        /// <param name="n">Кол-во букв</param>
        /// <returns></returns>
        public string CheckWordsLength(int n)
        {
            return string.Join(" ", array.Where(st => st.Length <= n));
        }
        /// <summary>
        /// Вывод только тех слов сообщения, которые содержат не более чем n букв при помощи регулярного выражения
        /// Пояснения:
        /// new Regex("[ ]{2, }").Replace - выбирает множественные пробелы, потом заменяем их на 1 пробел
        /// Cast<Match>().Select(m => m.Value) - преобразует MatchCollection в строковый массив
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string RegexCheckWordsLength(int n)
        {
            return new Regex("\\b\\w{" +(++n) + ",}\\s?\\b").Replace(message, " ");
        }
        /// <summary>
        /// Удаление слов из сообщения, заканчивающихся на определенный символ
        /// </summary>
        /// <param name="symbol">Символ</param>
        /// <returns>Итоговое сообщение</returns>
        public string DeleteWords(string symbol)
        {
            return string.Join(" ", array.Except(message.Split(' ').Where(s => s.EndsWith(symbol)))).Replace("  ", " ");
        }
        /// <summary>
        /// Удаление слов из сообщения, заканчивающихся на определенный символ при помощи регулярного выражения
        /// </summary>
        /// <param name="symbol">Символ</param>
        /// <returns>Итоговое сообщение</returns>
        public string RegexDeleteWords(string symbol)
        {
            return new Regex("\\w*" + symbol + "\\s?\\b").Replace(message, "");
        }
        /// <summary>
        /// Поиск самого длинного слова в сообщении
        /// </summary>
        /// <returns>Строка - самое длинное слово</returns>
        public string FindLongestWord()
        {
            //Способ №1
            return array.OrderByDescending(s => s.Length).First();
            // Способ №2
            //return list.Aggregate("", (max, current) => max.Length > current.Length ? max : current);
        }
        /// <summary>
        /// Поиск всех самых длинных слов в сообщении.
        /// </summary>
        /// <returns>Строка - самые длинные слова сообщения</returns>
        public string FindAllLongestWords()
        {
            return string.Join(" ", list.Where(s => s.Length == list.Max(st => st.Length)));
        }
    }
}