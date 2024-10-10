using HomeWork02.Models;

namespace HomeWork02.Data.Interfaces;

public interface IRepoBase<T>
{
    T? GetItem(int id);

    IEnumerable<T>? GetItems(int skip, int take);

    void Add(T item);

    void Delete(T item);
}
