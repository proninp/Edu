using System.Collections;
using System.Collections.Generic;

namespace Persons
{
    public class Company : IEnumerable
    {
        public List<Person> Department { get; set; }
        public Company(List<Person> list)
        {
            Department = list;
        }
        public Company() : this(new List<Person>()){ }
        /// <summary>
        /// Реализация метода GetEnumerator() интерфейса IEnumerator
        /// </summary>
        /// <returns>Экземпляр Person</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var d in Department)
                yield return d.ToString();
        }
    }
}