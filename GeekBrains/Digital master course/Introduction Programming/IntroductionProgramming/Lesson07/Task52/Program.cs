/*
 * Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
* Например, задан массив:
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
* Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

/// <summary>
/// Заполнение двумерного массива
/// </summary>
/// <param name="rows">Количество строк</param>
/// <param name="columns">Количество столбцов</param>
/// <param name="min">Минимальный элемент</param>
/// <param name="max">Максимальный элемент</param>
/// <returns>Двумерный массив</returns>
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
/// Печать одномерного массива
/// </summary>
/// <param name="a">Одномерный массив double</param>
void PrintArray(double[] a)
{
    System.Console.Write("[");
    for(int i = 0; i < a.Length; i++)
        if (i < a.Length - 1)
            System.Console.Write($"{a[i]}, ");
        else
            System.Console.Write($"{a[i]}");
    System.Console.WriteLine("]");
}

/// <summary>
/// Получение одномерного массива, содержащего среднее арифмитическое по каждому столбцу
/// </summary>
/// <param name="a">Входящий двумерный массив</param>
/// <returns>Одномерный массив типа double</returns>
double[] GetColumnAverageArray(int[,] a)
{
    double[] result = new double[a.GetLength(1)];
    for(int cols = 0; cols < a.GetLength(1); cols++)
    {
        for(int rows = 0; rows < a.GetLength(0); rows++)
            result[cols] += a[rows, cols];
        result[cols] = Math.Round(result[cols] * 1.0 / a.GetLength(0), 2);
    }
    return result;
}


int[,] a = FillTwoDimArray(5, 4, 0, 10);
PrintTwoDimArray(a);
System.Console.WriteLine("Среднее арифметическое:");
double[] d = GetColumnAverageArray(a);
PrintArray(d);