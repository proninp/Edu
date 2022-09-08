using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_6
{
    class Task2
    {
        public delegate double DelegateFunction(double x);
        public static void Go()
        {
            Console.WriteLine("\nTask 2.\n");
            List<DelegateFunction> delList = new List<DelegateFunction>() { Math.Sin, Math.Cos, delegate (double y) { return y * y; }, Math.Sqrt, delegate (double y) { return y * y / Math.Log(y); } };
            int i = ChooseFunc();
            if (i < 1) return;
            SetStartValues(out double a, out double b, out double step);            
            SaveFunc("data.bin", delList.ElementAt(i-1), a, b, step);
            List<double> list = Load("data.bin", out double min);
            PrintResult(list, min);
        }
        public static void SetStartValues(out double a, out double b, out double step)
        {
            Console.WriteLine("Enter \"a\" parametr (from which the function will start calculation):");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"b\" parametr (to which the function will end calculation):");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"step\" parametr:");
            step = double.Parse(Console.ReadLine());
        }
        public static int ChooseFunc()
        {
            Console.WriteLine("Choose function\n- 1: Sin(x);\n- 2: Cos(x);\n- 3: x^2;\n- 4: Sqrt(x);\n- 5: x^2/Ln(x);\n- 0: Exit.");
            int choice = int.Parse(Console.ReadLine());
            int i;
            switch (choice)
            {
                case 0:
                    i = 0;
                    break;
                case 1:
                    i = 1;
                    break;
                case 2:
                    i = 2;
                    break;
                case 3:
                    i = 3;
                    break;
                case 4:
                    i = 4;
                    break;
                case 5:
                    i = 5;
                    break;
                default:
                    Console.WriteLine("There is no switch for that value.");
                    i = 0;
                    break;
            }
            return i;
        }
        
        public static void SaveFunc(string fileName, DelegateFunction Func, double a, double b, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (a <= b)
            {
                bw.Write(Func(a));
                a += step;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> list = new List<double>();
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                list.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return list;
        }
        static void PrintResult(List<double> list, double min)
        {
            Console.WriteLine("All values:");
            foreach (var el in list)
                Console.WriteLine(el);
            Console.WriteLine($"The minimum value is: {min}");
        }
    }
}
