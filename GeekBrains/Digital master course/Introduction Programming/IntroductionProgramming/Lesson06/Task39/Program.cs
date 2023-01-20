/*
* Напишите программу, которая перевернёт
* одномерный массив (последний элемент будет на первом
* месте, а первый - на последнем и т.д.)
* [1 2 3 4 5] -> [5 4 3 2 1]
* [6 7 3 6] -> [6 3 7 6]
*/

void PrintArray(int[] a)
{
    System.Console.Write("[");
    for(int i = 0; i < a.Length; i++)
        if (i < a.Length - 1)
            System.Console.Write($"{a[i]}, ");
        else
            System.Console.Write($"{a[i]}");
    System.Console.WriteLine("]");
}
int[] FillArray(int size, int min, int max)
{
    Random random = new Random();
    max++;
    int[] a = new int[size];
    for(int i = 0; i < size; i++)
        a[i] = random.Next(min, max);
    return a;
}
void RevertArray(int[] a)
{
    int i = 0;
    int j = a.Length - 1;
    while(i < j)
        Swap(ref a[i++], ref a[j--]);
}
void Swap(ref int a, ref int b)
{
    a = a + b;
    b = a - b;
    a = a - b;
}
void TestRevert(int[] src)
{
    System.Console.WriteLine("Original:");
    PrintArray(src);
    System.Console.WriteLine("Reverted:");
    RevertArray(src);
    PrintArray(src);
}
Console.Clear();
TestRevert(FillArray(6, 1, 20));
TestRevert(FillArray(5, 1, 20));
TestRevert(new int[] {6, 7, 3, 6});