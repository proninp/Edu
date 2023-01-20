/*
 * Не используя рекурсию, выведите первые N чисел
* Фибоначчи. Первые два числа Фибоначчи: 0 и 1.
* Если N = 5 -> 0 1 1 2 3
* Если N = 3 -> 0 1 1
* Если N = 7 -> 0 1 1 2 3 5 8
*/
void PrintArray(int[] a)
{
    for(int i = 0; i < a.Length; i++)
        if (i < a.Length - 1)
            System.Console.Write($"{a[i]}, ");
        else
            System.Console.Write($"{a[i]}");
}

int[] GetFibArray(int n)
{
    int[] a = new int[n];
    for(int i = 0; i < n; i ++)
    {
        if (i < 2)
            a[i] = i;
        else
            a[i] = a[i - 2] + a[i - 1];
    }
    return a;
}
Console.Clear();
System.Console.WriteLine("Введите количество чисел Фибоначчи для вывода:");
int n = Convert.ToInt32(Console.ReadLine());
PrintArray(GetFibArray(n));
