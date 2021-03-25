using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lesson_4
{
    class OneDimensional
    {
        int[] a;
        Random random;
        #region Indexator
        public int this[int i]
        {
            get => a[i];
            set => a[i] = value;
        }
        #endregion
        #region Properties
        public int Length => a.Length;
        public int Sum => a.Sum();
        public int Min => a.Min();
        public int Max => a.Max();
        public int MaxCount => a.Where(x => x == a.Max()).Count();
        public int MaxCount2 => (from ar in a where ar == a.Max() select ar).Count();
        public int MaxCount3
        {
            get
            {
                int max = 0;
                int maxCount = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        maxCount = 1;
                    }
                    else if (a[i] == max)
                        maxCount++;
                }
                return maxCount;
            }
        }
        #endregion
        #region Constructors
        public OneDimensional(int length) => a = new int[length];
        public OneDimensional(int length, int startValue, int step): this(length)
        {
            a[0] = startValue;
            for (int i = 1; i < length; i++)
                a[i] = a[i - 1] + step;
        }
        public OneDimensional(string fileName)
        {
            List<int> list = new List<int>();
            try
            {
                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                    if (int.TryParse(sr.ReadLine(), out int el))
                        list.Add(el);
                sr.Close();
            }
            catch (FileNotFoundException fileex)
            {
                Console.WriteLine(fileex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (list.Count != 0)
                a = list.ToArray();
        }
        #endregion
        #region Functions
        public void RandomFill(int min, int max)
        {
            random = new Random();
            a = a.Select(x => x = random.Next(min, max + 1)).ToArray();
        }
        public void Multi(int multiplier) => a = a.Select(x => x * multiplier).ToArray();

        public int[] Inverse()
        {
            int[] b = new int[a.Length];
            b = a.Select(x => x * (-1)).ToArray();
            return b;
        }
        public void Print()
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
        }
        public Dictionary<int, int> GetKeyValuePairs()
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            var array = a.Distinct().ToArray();
            for (int i = 0; i < array.Length; i++)
                keyValuePairs.Add(array[i], a.Where(x => x == array[i]).Count());
            return keyValuePairs;
        }
        public void PrintKeyValue()
        {
            var pairs = GetKeyValuePairs();
            string res = "";
            foreach (var pair in pairs)
                res += $"[{pair.Key}, {pair.Value}]";
            if (res.Contains("]["))
                res = res.Replace("][", "], [");
            Console.WriteLine(res);
        }
        #endregion

    }
}
