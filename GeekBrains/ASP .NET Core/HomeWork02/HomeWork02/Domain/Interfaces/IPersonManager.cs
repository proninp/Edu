using HomeWork02.DataTransferObjects;
using HomeWork02.Models;

namespace HomeWork02.Domain.Interfaces;

public interface IPersonManager
{
    PersonDto? GetPerson(int id);

    PersonDto? GetPerson(string searchTerm);

    IEnumerable<PersonDto>? GetPersons(int skip, int take);

    int Create(PersonDto person);

    bool Update(int id, PersonDto person);

    bool Delete(int id);
}