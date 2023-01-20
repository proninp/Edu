using System.Text;

Task25();
Task27();
Task29();
#region Task25
/// <summary>
/// Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
/// </summary>
void Task25()
{
    ColoredWrite(ConsoleColor.Yellow, "Задача 25");
    ColoredWrite(ConsoleColor.Blue, "Введите число A:");
    int a = Convert.ToInt32(Console.ReadLine());
    ColoredWrite(ConsoleColor.Blue, "Введите число B:");
    int b = Convert.ToInt32(Console.ReadLine());
    if (b < 0)
    {
        ColoredWrite(ConsoleColor.Red, "Число B не должно быть отрицательным");
        return;
    }
    System.Console.WriteLine(PowNumbers(a, b));
    
}
/// <summary>
/// Возведение числа a в степень b
/// </summary>
/// <param name="a">Число</param>
/// <param name="b">Степень</param>
/// <returns>Число a в степени b</returns>
int PowNumbers(int a, int b)
{    
    if (a == 0)
        return a;
    int sign = (a > 0) ? 1 : -1;
    int res = 1;
    while(b-- > 0)
        res *= Math.Abs(a);
    res *= sign;
    return res;
}
#endregion

#region Task27
/// <summary>
/// Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
/// </summary>
void Task27()
{
    ColoredWrite(ConsoleColor.Yellow, "Задача 27");
    ColoredWrite(ConsoleColor.Blue, "Введите число:");
    int n = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine($"Сумма цифр числа {n}: {GetNumberDigitsSum(n)}");
}
/// <summary>
/// Подсчет суммы цифр в числе
/// </summary>
/// <param name="n">Число</param>
/// <returns>Сумма цифр</returns>
int GetNumberDigitsSum(int n)
{
    int sum = 0;
    while(n > 0)
    {
        sum += n % 10;
        n /= 10;
    }
    return sum;
}
#endregion

#region Task29
/// <summary>
/// Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
/// </summary>
void Task29()
{
    ColoredWrite(ConsoleColor.Yellow, "Задача 29");
    int[] a = FillArray(8, -100, 100);
    PrintArray(a);
    
}
/// <summary>
/// Создает и заполняет массив случайными числами
/// </summary>
/// <param name="len">Длинна массива</param>
/// <param name="min">Минимальное значение элемента массива</param>
/// <param name="max">Максимальное значение элемента массива</param>
/// <returns></returns>
int[] FillArray(int len, int min, int max)
{
    Random random = new Random();
    max++;
    int[] a = new int[len];
    for(int i = 0; i < a.Length; i++)
        a[i] = random.Next(min, max);
    return a;
}
/// <summary>
/// Выводит массив на экран
/// </summary>
/// <param name="a">Массив</param>
void PrintArray(int[] a)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("[");
    string separator = ", ";
    for(int i = 0; i < a.Length; i++)
    {
        sb.Append(a[i])/*.Append((i < a.Length - 1) ? separator : "")*/;
        if (i < a.Length - 1)
            sb.Append(separator);
    }
    sb.Append("]");
    System.Console.WriteLine(sb.ToString());
}
#endregion
#region Additional
/// <summary>
/// Вспомогательный метод для вывода цветного текста
/// </summary>
/// <param name="consoleColor">Цвет текста</param>
/// <param name="text">Текст</param>
void ColoredWrite(ConsoleColor consoleColor, string text)
{
    ConsoleColor curr = Console.ForegroundColor;
    Console.ForegroundColor = consoleColor;
    System.Console.WriteLine(text);
    Console.ForegroundColor = curr;
}
#endregion
