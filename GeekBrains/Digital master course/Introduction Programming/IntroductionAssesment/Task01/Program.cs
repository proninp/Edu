/*
 * Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа. 
 */

/// <summary>
/// Метод 1 для поиска элементов массива, подходящих условию задачи
/// </summary>
/// <param name="a">Входящий массив строк</param>
/// <param name="limit">Максимальное количество символов в элементе для выбора</param>
/// <returns>Массив найденных символов</returns>
string[] Solution1(string[] a, int limit)
{
    int j = 0;
    int[] indexes = new int[a.Length];
    for(int i = 0; i < a.Length; i++)
        if (a[i].Length <= limit)
            indexes[j++] = i;
    string[] res = new string[j];
    for(int i = 0; i < j; i++)
        res[i] = a[indexes[i]];
    return res;
}
/// <summary>
/// Метод 2 для поиска элементов массива, подходящих условию задачи
/// </summary>
/// <param name="a">Входящий массив строк</param>
/// <param name="limit">Максимальное количество символов в элементе для выбора</param>
/// <returns>Массив найденных символов</returns>
string[] Solution2(string[] a, int limit) => a.Where(e => e.Length <= limit).ToArray();

/// <summary>
/// Печать массива в консоль
/// </summary>
/// <param name="a">Входящий массив для печати</param>
void PrintArray(string[] a)
{
    System.Console.Write("[");
    for(int i = 0; i < a.Length; i++)
        if (i < a.Length - 1)
            System.Console.Write($"{a[i]}, ");
        else
            System.Console.Write($"{a[i]}");
    System.Console.WriteLine("]");
}

Console.Clear();
string[] a = new string[] {"hello", "2", "world", ":-)", "1234", "1567", "-2", "computer", "foo", "bar", "foobar", "a", "abc"};
int limit = 3;
System.Console.WriteLine("Solution 1:");
PrintArray(Solution1(a, limit));
System.Console.WriteLine("Solution 2:");
PrintArray(Solution2(a, limit));
