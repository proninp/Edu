using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * The museum of incredible dull things
     * 
     * The museum of incredible dull things wants to get rid of some exhibitions.
     * Miriam, the interior architect, comes up with a plan to remove the most boring exhibitions.
     * She gives them a rating, and then removes the one with the lowest rating.
     * 
     * However, just as she finished rating all exhibitions, she's off to an important fair,
     * so she asks you to write a program that tells her the ratings of the items after one removed the lowest one.
     * Fair enough.
     * 
     * Task
     * 
     * Given an array of integers, remove the smallest value. Do not mutate the original array/list.
     * If there are multiple elements with the same value, remove the one with a lower index.
     * If you get an empty array/list, return an empty array/list.
    */
    internal class Remover
    {
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return numbers;
            List<int> result = new List<int>(numbers.Count);
            int minIndex = 0;
            int minRatig = numbers[minIndex];
            for (int i = 0; i < numbers.Count; i++)
            {
                result.Add(numbers[i]);
                if (result[i] < minRatig)
                {
                    minIndex = i;
                    minRatig = result[i];
                }
                    
            }
            result.RemoveAt(minIndex);
            return result;
        }
        public static List<int> RemoveSmallest2(List<int> numbers)
        {
            numbers.Remove(numbers.DefaultIfEmpty().Min());
            return numbers;
        }
    }
}
