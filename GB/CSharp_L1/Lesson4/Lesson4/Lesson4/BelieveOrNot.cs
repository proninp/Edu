using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Класс для управления игрой "Верю - не верю"
     */
    class BelieveOrNot
    {
        string question;
        bool answer;

        #region Свойства
        /// <summary>
        /// Вопрос
        /// </summary>
        public string Question
        {
            set { question = value; }
            get { return question; }
        }
        /// <summary>
        /// Ответ
        /// </summary>
        public bool Answer
        {
            set { answer = value; }
            get { return answer; }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        BelieveOrNot()
        {

        }
        /// <summary>
        /// Конструктор объекта Пары
        /// </summary>
        /// <param name="question">Вопрос</param>
        /// <param name="answer">Ответ</param>
        public BelieveOrNot(string question, bool answer)
        {
            this.question = question;
            this.answer = answer;
        }
        #endregion

        #region Метод
        /// <summary>
        /// Получения массива пар вопрос-ответ из файла
        /// </summary>
        /// <param name="fileName">Полное имя файла</param>
        /// <returns>Массив объектов вопрос-ответ</returns>
        public static BelieveOrNot[] GenerateFromFile(string fileName)
        {
            string s = "";
            if (!File.Exists(fileName))
            {
                CommonMethods.ColoredWriteLine("Файл не существует!", ConsoleColor.Red);
                return null;
            }
            else
            {
                s = File.ReadAllText(fileName);
                string[] sa = s.Split('\n');
                BelieveOrNot[] bon = new BelieveOrNot[sa.Length];
                for (int i = 0; i < sa.Length; i++)
                    bon[i] = new BelieveOrNot(sa[i].Split(';')[0], sa[i].Split(';')[1].Substring(0, 2) == "Да");
                return bon;
            }
        }
        #endregion
    }
}
