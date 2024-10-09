using HomeWork02.Models;

namespace HomeWork02.Data.Interfaces;

public interface IPersonRepo : IRepoBase<Person>
{
    Person? GetItem(string searchTerm);

    int GetLast();
}
