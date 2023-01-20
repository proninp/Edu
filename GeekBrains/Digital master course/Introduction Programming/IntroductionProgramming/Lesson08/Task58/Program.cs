/*
 * Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
 * Например, даны 2 матрицы:
 * 2 4 | 3 4
 * 3 2 | 3 3
 * Результирующая матрица будет:
 * 18 20
 * 15 18
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
        System.Console.WriteLine($" ]");
    }
}
/// <summary>
/// Генерация матриц
/// </summary>
/// <param name="a">Матрица А</param>
/// <param name="b">Матрица Б</param>
void GenerateMatrix(out int[,] a, out int[,] b, int minValue, int maxValue, int maxRows, int maxCols)
{
    maxValue++;
    maxRows++;
    maxCols++;
    Random random = new Random();
    GetRowsColsCount(out int rowsA, out int colsA, maxRows, maxCols, random);
    a = FillTwoDimArray(rowsA, colsA, minValue, maxValue);
    System.Console.WriteLine("Matrix A:");
    PrintTwoDimArray(a);
    int rowsB = colsA;
    int colsB = random.Next(1, maxCols);
    b = FillTwoDimArray(rowsB, colsB, minValue, maxValue);
    System.Console.WriteLine("Matrix B:");
    PrintTwoDimArray(b);
}
/// <summary>
/// Получение случайных значений строк и столбцов матрицы
/// </summary>
/// <param name="rows">строк</param>
/// <param name="cols">столбцов</param>
/// <param name="maxRows">макс. строк</param>
/// <param name="maxCols">макс. столбцов</param>
/// <param name="random">рандомайзер</param>
void GetRowsColsCount(out int rows, out int cols, int maxRows, int maxCols, Random random)
{
    rows = 1;
    cols = 1;
    while (rows == 1 && cols == 1)
    {
        rows = random.Next(1, maxRows);
        cols = random.Next(1, maxCols);
    }
}
/// <summary>
/// Умножений матриц
/// </summary>
/// <param name="a"></param>
/// <param name="b"></param>
/// <returns></returns>
int[,] MatrixMultiplication(int[,] a, int[,] b)
{
    int rowsA = a.GetLength(0);
    int colsA = a.GetLength(1);
    int rowsB = b.GetLength(0);
    int colsB = b.GetLength(1);
    int[,] c = new int[rowsA, colsB];
    for(int i = 0; i < rowsA; ++i)
    {
        for(int j = 0; j < colsB; ++j)
        {
            for(int k = 0; k < colsA; ++k)
            {
                c[i, j] += a[i, k] * b[k, j];
            }
        }
    }
    return c;
}
Console.Clear();
GenerateMatrix(out int[,] a, out int[,] b, -5, 5, 4, 4);
int[,] c = MatrixMultiplication(a, b);
System.Console.WriteLine("Matrix C:");
PrintTwoDimArray(c);
