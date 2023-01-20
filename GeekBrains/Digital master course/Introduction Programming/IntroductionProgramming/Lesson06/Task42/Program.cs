/*
* Напишите программу, которая будет преобразовывать десятичное число в двоичное.
 * 45 -> 101101
 * 3 -> 11
 * 2 -> 10
*/
void ConvertToBinary(int a)
{
    int res = 0;
    int c = 1;
    while(a > 0)
    {
        res += c * (a % 2);
        a /= 2;
        c *= 10;
    }
    System.Console.WriteLine(res);
}
Console.Clear();
System.Console.WriteLine("Введите число:");
int a = Convert.ToInt32(Console.ReadLine());
ConvertToBinary(a);