/*
 * Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
 * Например, задан массив:
 * 1 4 7 2
 * 5 9 2 3
 * 8 4 2 4
 * 5 2 6 7
*/

/// <summary>
/// Заполнение двумерного массива
/// </summary>
/// <param name="rows"></param>
/// <param name="columns"></param>
/// <param name="min"></param>
/// <param name="max"></param>
/// <returns></returns>
int[,] FillTwoDimArray(int rows, int columns, int min, int max)
{
    Random random = new Random();
    max++;
    int[,] a = new int[rows, columns];
    for(int i = 0; i < a.GetLength(0); i++)
        for(int j = 0; j < a.GetLength(1); j++)
            a[i, j] = random.Next(min, max);
    return a;
}

/// <summary>
/// Печать двумерного массива в консоль
/// </summary>
/// <param name="a">Двумерный массив типа int</param>
void PrintTwoDimArray(int[,] a)
{
    for(int i = 0; i < a.GetLength(0); i++)
    {
        System.Console.Write("[ ");
        int rowSum = 0;
        for(int j = 0; j < a.GetLength(1); j++)
        {
            rowSum += a[i, j];
            if (j < a.GetLength(1) - 1)
                System.Console.Write($"{a[i, j], 4}; ");
            else
                System.Console.Write($"{a[i, j], 4}");
        }
        System.Console.WriteLine($" ]\t({rowSum})");
    }
}
/// <summary>
/// Получение номера и наименьшей суммы строки
/// </summary>
/// <param name="a">Двумерный массив</param>
/// <returns>Номер строки и сумма</returns>
(int, int) GetLowestSumRow(int[,] a)
{
    int lowestSum = int.MaxValue;
    int row = 0;
    for(int i = 0; i < a.GetLength(0); ++i)
    {
        int currentRowSum = 0;
        for(int j = 0; j < a.GetLength(1); ++j)
            currentRowSum += a[i, j];
        if (currentRowSum < lowestSum)
        {
            lowestSum = currentRowSum;
            row = i;
        }
    }
    return (row, lowestSum);
}

Console.Clear();
int[,] a = FillTwoDimArray(4, 6, 0, 20);
System.Console.WriteLine("Matrix:");
PrintTwoDimArray(a);
var tuple = GetLowestSumRow(a);
System.Console.WriteLine($"Строка с индексом {tuple.Item1} имеет наименьшую сумму {tuple.Item2}");