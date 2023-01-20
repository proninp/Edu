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

int OddElementsSum(int[] a)
{
    int sum = 0;
    for(int i = 1; i < a.Length; i+= 2)
        sum += a[i];
    return sum;
}

int[] a = FillArray(5, -10, 10);
PrintArray(a);
System.Console.WriteLine($"Сумма элементов, стоящих на нечетных позициях: {OddElementsSum(a)}");