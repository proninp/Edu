using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Welcome. In this kata, you are asked to square every digit of a number.
     * For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.
     * Note: The function accepts an integer and returns an integer
     */
    class SquareEveryDigit
    {
        public static int SquareDigits(int n)
        {
            List<string> l = new List<string>();
            n.ToString().ToList().ForEach(c => l.Add(((c - 48) * (c - 48)).ToString()));
            return int.Parse(string.Join("", l));
            //return int.Parse(String.Concat(n.ToString().Select(a => (int)Math.Pow(char.GetNumericValue(a), 2))));
        }
    }
}
