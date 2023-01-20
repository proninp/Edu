using System.Collections.Generic;
/*
 * Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
* Массив размером 2 x 2 x 2
* 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
* 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)
*/
int[,,] FillThreeDimArray(int rows, int columns, int layers, int min, int max)
{
    
    Random random = new Random();
    LinkedList<int> list = new LinkedList<int>();
    max++;
    int[,,] a = new int[rows, columns, layers];
    for(int i = 0; i < a.GetLength(0); i++)
        for(int j = 0; j < a.GetLength(1); j++)
            for(int k = 0; k < a.GetLength(2); k++)
                GetRandomNumber(ref a[i, j, k], random, list, min, max);
    return a;
}
void GetRandomNumber(ref int n, Random random, LinkedList<int> list, int min, int max)
{
    int loop = 0;
    while(true)
    {
        if (loop++ > short.MaxValue)
            throw new Exception("Нет доступных уникальных двухзначных чисел");
        n = random.Next(min, max);
        if (!list.Contains(n))
        {
            list.AddLast(n);
            break;
        }
    }
}
void PrintThreeDimArray(int[,,] a)
{
    for(int i = 0; i < a.GetLength(0); i++)
    {
        for(int j = 0; j < a.GetLength(1); j++)
            for(int k = 0; k < a.GetLength(2); k++)
            {
                System.Console.Write($"{a[i, j, k], 4}({i},{j}.{k})");
                if (j < a.GetLength(1) - 1)
                    System.Console.Write("; ");
            }
        System.Console.WriteLine();
    }
}
int[,,] a = FillThreeDimArray(3, 3, 3, 10, 99);
PrintThreeDimArray(a);