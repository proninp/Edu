using HomeWork02.DataTransferObjects;
using HomeWork02.Models;

namespace HomeWork02.Domain.Interfaces;

public interface IPersonManager
{
    Person? GetPerson(int id);

    Person GetPerson(string searchTerm);

    IEnumerable<Person> GetPersons(int skip, int take);

    int Create(PersonDto person);

    void Update(PersonDto person);

    void Delete(int id);
}