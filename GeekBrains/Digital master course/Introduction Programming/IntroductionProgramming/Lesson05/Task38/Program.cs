using System.Text;

double[] FillArrayDouble(int size, int min, int max, int precision)
{
    Random random = new Random();
    max++;
    double[] a = new double[size];
    for(int i = 0; i < size; i++)
        a[i] = Math.Round((random.NextDouble() * (max - min) + min), precision);
        
    return a;
}

void PrintArray(double[] a)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("[");
    string separator = "; ";
    for(int i = 0; i < a.Length; i++) {
        sb.Append(a[i]);
        if (i < a.Length - 1)
            sb.Append(separator);
    }
    sb.Append("]");
    System.Console.WriteLine(sb.ToString());
}
double FindMinMaxDiff(double[] a)
{
    if (a.Length == 0)
        return 0;
    double min = double.MaxValue;
    double max = double.MinValue;
    for(int i = 0; i < a.Length; i++)
    {
        if (a[i] < min)
            min = a[i];
        if (a[i] > max)
            max = a[i];
    }
    return max - min;
}

double[] a = FillArrayDouble(5, 0, 10, precision: 2);
PrintArray(a);
System.Console.WriteLine($"Разница между максимальным и минимальным элементами массива: {FindMinMaxDiff(a).ToString("#.##")}");
