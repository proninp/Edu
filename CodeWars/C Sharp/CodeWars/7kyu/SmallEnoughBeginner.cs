using System;
using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Small enough? - Beginner
     * 
     * You will be given an array and a limit value.
     * You must check that all values in the array are below or equal to the limit value.
     * If they are, return true. Else, return false.
     * You can assume all values in the array are numbers.
     */
    public class SmallEnoughBeginner
    {
        public static bool SmallEnough(int[] a, int limit)
        {
            return a.All(x => x <= limit);
        }
    }
}
