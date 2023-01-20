int GetInputRate(string rateName)
{
    System.Console.WriteLine($"Введите коэффициент {rateName}:");
    return Convert.ToInt32(Console.ReadLine());
}

void PrintEquation(int k1, int b1, int k2, int b2)
{
    System.Console.WriteLine($"y = {k1} * x + {b1};");
    System.Console.WriteLine($"y = {k2} * x + {b2};");
}
double CalcX(int k1, int b1, int k2, int b2) => Math.Round((b2 - b1) * 1.0 / (k1 - k2), 2);
double CalcY(int k1, int b1, double x) => Math.Round(k1 * x + b1, 2);

int b1 = GetInputRate("b1");
int k1 = GetInputRate("k1");
int b2 = GetInputRate("b2");
int k2 = GetInputRate("k2");

Console.Clear();
PrintEquation(k1, b1, k2, b2);
double x = CalcX(k1, b1, k2, b2);
double y = CalcY(k1, b1, x);
System.Console.WriteLine($"[{x}, {y}]");

