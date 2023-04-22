using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Sum a list but ignore any duplicates
     * Please write a function that sums a list, but ignores any duplicate items in the list.
     * For instance, for the list [3, 4, 3, 6] , the function should return 10.
     */
    internal class SumListIgnoreAnyDuplicates
    {
        public static int SumNoDuplicates(int[] arr)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (pairs.ContainsKey(arr[i]))
                    pairs[arr[i]]++;
                else
                    pairs.Add(arr[i], 1);
            }
            int sum = 0;
            foreach (var pair in pairs)
                if (pair.Value == 1)
                    sum += pair.Key;
            return sum;
        }
    }
}
