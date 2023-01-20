/**
 * Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
 * m = 3, n = 4.
 * 0,5 7 -2 -0,2
 * 1 -3,3 8 -9,9
 * 8 7,8 -7,1 9
*/

/// <summary>
/// Создание и заполнение массива случайными числами
/// </summary>
/// <param name="rows">Строк массива</param>
/// <param name="columns">Столбцов массива</param>
/// <param name="min">Минимальное значение элемента массива</param>
/// <param name="max">Максимальное значение элемента массива</param>
/// <param name="precision">Точность округления</param>
/// <returns>Двумерный массив типа double</returns>
double[,] FillTwoDimArray(int rows, int columns, int min, int max, int precision)
{
    Random random = new Random();
    max++;
    double[,] a = new double[rows, columns];
    for(int i = 0; i < a.GetLength(0); i++)
        for(int j = 0; j < a.GetLength(1); j++)
            a[i, j] = Math.Round((random.NextDouble() * (max - min) + min), precision);
    return a;
}

/// <summary>
/// Печать двумерного массива в консоль
/// </summary>
/// <param name="a">Двумерный массив типа double</param>
void PrintTwoDimArray(double[,] a)
{
    for(int i = 0; i < a.GetLength(0); i++)
    {
        System.Console.Write("[ ");
        for(int j = 0; j < a.GetLength(1); j++)
        {
            if (j < a.GetLength(1) - 1)
                System.Console.Write($"{a[i, j], 5}; ");
            else
                System.Console.Write($"{a[i, j], 5}");
        }
        System.Console.WriteLine(" ]");
    }
}
double[,] a = FillTwoDimArray(3, 4, 0, 10, 2);
PrintTwoDimArray(a);