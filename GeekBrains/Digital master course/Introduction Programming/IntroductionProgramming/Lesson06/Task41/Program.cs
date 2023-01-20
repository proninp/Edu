/*
 * Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
 * 0, 7, 8, -2, -2 -> 2
 * 1, -7, 567, 89, 223-> 3
*/
int[] GetInputNumbers()
{
    int[] a = new int[0];
    System.Console.WriteLine("Введите числа через пробел:");
    string s = Console.ReadLine();
    if (s.Length > 0)
    {
        string[] arr = s.Split(" ");
        a = new int[arr.Length];
        for(int i = 0; i < arr.Length; i++)
            if (Int32.TryParse(arr[i], out int n))
                a[i] = n;
    }
    return a;
}
int GetPositiveNumbersCount(int[] a) => a.Where(b => (b > 0)).Count();

Console.Clear();
System.Console.WriteLine($"Чисел больше 0: {GetPositiveNumbersCount(GetInputNumbers())}");