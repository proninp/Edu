/*
* Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
* и возвращает значение этого элемента или же указание, что такого элемента нет.
* Например, задан массив:
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
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
int[,] a = FillTwoDimArray(3, 4, 0, 10);
PrintTwoDimArray(a);
System.Console.WriteLine("Введите строку массива (нумерация с 1):");
int row = Convert.ToInt32(Console.ReadLine());
System.Console.WriteLine("Введите столбец массива (нумерация с 1):");
int column = Convert.ToInt32(Console.ReadLine());
int rowIndex = row - 1;
int columnindex = column - 1;

if (rowIndex < a.GetLength(0) && rowIndex >= 0 && columnindex < a.GetLength(1) && columnindex >= 0)
    System.Console.WriteLine($"[{row}, {column}]: {a[rowIndex, columnindex], 3}");
else
    System.Console.WriteLine($"Элемента [{row}, {column}] не существует в массиве.");