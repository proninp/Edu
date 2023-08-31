using System;
using System.Linq;

namespace Route_256_Practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static void Task3PairProgramming()
        {
            int.TryParse(Console.ReadLine(), out int setsCount);
            for (int setIndex = 0; setIndex < setsCount; setIndex++)
            {
                int.TryParse(Console.ReadLine(), out int devsCount);
                var set = new HashSet<int>(devsCount);
                var devsList = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
                for (int i = 0; i < devsCount - 1; i++)
                {
                    if (set.Contains(i))
                        continue;
                    int currDevSkill = devsList[i];
                    int min = int.MaxValue;
                    (int, int) pair = (0, 1);
                    for (int j = i + 1; j < devsCount; j++)
                    {
                        if (set.Contains(j))
                            continue;
                        int diff = Math.Abs(currDevSkill - devsList[j]);
                        if (diff < min)
                        {
                            min = diff;
                            pair = (i, j);
                        }
                    }
                    Console.WriteLine($"{pair.Item1 + 1} {pair.Item2 + 1}");
                    set.Add(pair.Item1);
                    set.Add(pair.Item2);
                }
                Console.WriteLine();
            }
        }
        public static void Task2AmmoutToPay()
        {
            Dictionary<int, int> map;
            int.TryParse(Console.ReadLine(), out int n);
            while (n-- > 0)
            {
                int.TryParse(Console.ReadLine(), out int itemsCount);
                var prices = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
                map = new Dictionary<int, int>();
                int sumToPay = 0;
                foreach (int price in prices)
                {
                    if (map.ContainsKey(price))
                        map[price]++;
                    else
                        map.Add(price, 1);
                    if (map[price] % 3 != 0)
                        sumToPay += price;
                }
                Console.WriteLine(sumToPay);
            }
        }

        public static void Task1Combiner()
        {
            int.TryParse(Console.ReadLine(), out int n);
            while (n-- > 0)
            {
                Console.WriteLine(Console.ReadLine().Split(" ").Select(x => int.Parse(x)).Sum());
            }
        }
    }
}