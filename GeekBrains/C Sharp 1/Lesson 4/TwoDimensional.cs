using System;
using System.IO;

namespace Lesson_4
{
    class TwoDimensional
    {
        static char delimiter = '\t';
        int[,] a;

        #region Properties
        public int Min
        {
            get
            {                
                int min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > 0) count++;
                return count;
            }
        }  
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum += a[i, j];
                return sum / a.GetLength(0) / a.GetLength(1);
            }
        }
        #endregion

        #region Constructors
        public TwoDimensional(int n, int el)
        {
            a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = el;
        }
        public TwoDimensional(int n, int min, int max)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(min, max);
        }
        public TwoDimensional(string fileName)
        {
            string s = "";
            if (!File.Exists(fileName))
                Console.WriteLine("File not found.");
            else
            {
                s = File.ReadAllText(fileName);
                string[] sa = s.Split('\n');
                a = new int[sa.Length, sa[0].Split(delimiter).Length];
                for (int i = 0; i < sa.Length; i++)
                {
                    for (int j = 0; j < sa[i].Split(delimiter).Length; j++)
                        int.TryParse(sa[i].Split(delimiter)[j], out a[i, j]);
                }
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + delimiter.ToString();
                s += ((i != a.GetLength(0) - 1) ? "\n" : ""); // Don't add crlf if the last row
            }
            return s;
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];
            return sum;
        }
        public int Sum(int constraint)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > constraint)
                        sum += a[i, j];
            return sum;
        }
        public void IndexOfMax(out int[] ind)
        {
            ind = new int[2];
            int max = Max;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] == max)
                    {
                        ind[0] = i + 1;
                        ind[1] = j + 1;
                    }
        }
        public void WriteToFile(string fileName)
        {
            if (a.Length != 0)
            {
                if (!File.Exists(fileName))
                    File.Create(fileName).Dispose();
                StreamWriter sw = new StreamWriter(fileName, false);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        sw.Write(a[i, j] + ((j == a.GetLength(1) - 1) ? "" : delimiter.ToString()));
                    if (i != a.GetLength(0) - 1) sw.Write("\n");
                }
                sw.Close();
            }
        }
        #endregion
    }
}
