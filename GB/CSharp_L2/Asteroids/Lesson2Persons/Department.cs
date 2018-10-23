using System.Collections;
using System.Collections.Generic;

namespace Lesson2Persons
{
    /// <summary>
    /// Класс, содержащий массив сотрудников
    /// </summary>
    class Department : IEnumerable
    {
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public List<Person> Dep { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="list">Список сотрудников</param>
        public Department(List<Person> list)
        {
            Dep = list;
        }
        /// <summary>
        /// Инициализация экземпляра новым списком
        /// </summary>
        public Department() : this(new List<Person>()) { }
        public IEnumerator GetEnumerator()
        {
            foreach (var d in Dep)
                yield return d.Name + " " + d.Surname;
        }
    }
}
