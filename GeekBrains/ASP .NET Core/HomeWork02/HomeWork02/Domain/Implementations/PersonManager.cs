using HomeWork02.Data.Interfaces;
using HomeWork02.DataTransferObjects;
using HomeWork02.Domain.Interfaces;
using HomeWork02.Models;

namespace HomeWork02.Domain.Implementations;

public class PersonManager : IPersonManager
{
    private IPersonRepo _personRepo;

    public PersonManager(IPersonRepo personRepo)
    {
        _personRepo = personRepo;
    }

    public int Create(PersonDto personDto)
    {
        var person = new Person
        {
            Id = _personRepo.GetLast() + 1,
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Email = personDto.Email,
            Company = personDto.Company,
            Age = personDto.Age
        };
        _personRepo.Add(person);
        return person.Id;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Person? GetPerson(int id)
    {
        return _personRepo.GetItem(id);
    }

    public Person GetPerson(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person>? GetPersons(int skip, int take)
    {
        return _personRepo.GetItems(skip, take);
    }

    public void Update(PersonDto person)
    {
        throw new NotImplementedException();
    }
}
