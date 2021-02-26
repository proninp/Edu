using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace GB_HW_Lesson8
{
    class TrueFalse
    {
        String fileName;
        List<Question> list;

        public string FileName { get => fileName; set => fileName = value; }
        public List<Question> List { get => list; set => list = value; }
        public Question this[int index] { get => List[index]; }
        public int Count { get => List.Count; }

        public TrueFalse(string fileName, List<Question> list)
        {
            this.fileName = fileName;
            this.list = list;
        }
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        /// <summary>
        /// Добавляем элемент в список
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isTrue"></param>
        public void Add(string text, bool isTrue)
        {
            List.Add(new Question(text, true));
        }
        /// <summary>
        /// Удаляем элемент из списка
        /// </summary>
        /// <param name="i"></param>
        public void Remove(int i)
        {
            if (List != null && i < List.Count && i >= 0)
                List.RemoveAt(i);
        }
        /// <summary>
        /// Индекс вопроса, который еще не был задан, если таковых нет, вернёт -1
        /// </summary>
        /// <returns></returns>
        public int GetNewQuestion()
        {
            return List.FindIndex(l => !l.IsAnswered);
        }

        /// <summary>
        /// Кол-во правильных ответов
        /// </summary>
        /// <returns></returns>
        public int GetCorrectedCount()
        {
            return List.Where(l => l.IsCorrect).Count();
        }

        /// <summary>
        /// Очищаем ответы
        /// </summary>
        public void ClearAnswers()
        {
            List.ForEach(l => { l.IsAnswered = false; l.IsCorrect = false; });
        }

        /// <summary>
        /// Сохраняем в .xml
        /// </summary>
        public void Save()
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                new XmlSerializer(typeof(List<Question>)).Serialize(fs, List);
        }
        /// <summary>
        /// Создаём экземпляр из .xml
        /// </summary>
        public void Load()
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                List = (List<Question>)new XmlSerializer(typeof(List<Question>)).Deserialize(fs);
        }
    }
}
