/*
 * Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
 * Например, задан массив:
 * 1 4 7 2
 * 5 9 2 3
 * 8 4 2 4
 * В итоге получается вот такой массив:
 * 7 4 2 1
 * 9 5 3 2
 * 8 4 4 2
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
        for(int j = 0; j < a.GetLength(1); j++)
        {
            if (j < a.GetLength(1) - 1)
                System.Console.Write($"{a[i, j], 4}; ");
            else
                System.Console.Write($"{a[i, j], 4}");
        }
        System.Console.WriteLine(" ]");
    }
}
/// <summary>
/// Сортировка строк двумерного массива
/// </summary>
/// <param name="a">Двумерный массив с отсортированными строками</param>
void SortTwoDimArrayRows(int[,] a)
{
    for(int i = 0; i < a.GetLength(0); ++i)
    {
        for(int j = 1; j < a.GetLength(1); ++j)
        {
            int val = a[i, j];
            int k = j;
            while (k > 0 && a[i, k - 1] < val)
            {
                a[i, k] = a[i, k - 1];
                k--;
            }
            a[i, k] = val;
        }
    }
}
Console.Clear();
int[,] a = FillTwoDimArray(5, 5, 0, 20);
System.Console.WriteLine("Original matrix:");
PrintTwoDimArray(a);
SortTwoDimArrayRows(a);
System.Console.WriteLine("Sorted matrix:");
PrintTwoDimArray(a);