using System.Text;

int[] FillArray(int size, int min, int max)
{
    Random random = new Random();
    max++;
    int[] a = new int[size];
    for(int i = 0; i < size; i++)
        a[i] = random.Next(min, max);
    return a;
}

void PrintArray(int[] a)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("[");
    string separator = ", ";
    for(int i = 0; i < a.Length; i++)
        sb.Append(a[i]).Append((i < a.Length - 1) ? separator : "");
    sb.Append("]");
    System.Console.WriteLine(sb.ToString());
}

int GetEvenCount(int[] a)
{
    int count = 0;
    for(int i = 0; i < a.Length; i++)
        if (a[i] % 2 == 0)
            count++;
    return count;
}

int[] a = FillArray(10, 100, 999);
PrintArray(a);
System.Console.WriteLine($"Количество четных чисел в массиве: {GetEvenCount(a)}");