using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * In this kata you will be given an integer n, which is the number of times that is thown a coin.
     * You will have to return an array of string for all the possibilities (heads[H] and tails[T]). Examples:
     * coin(1) should return {"H", "T"}
     * coin(2) should return {"HH", "HT", "TH", "TT"}
     * coin(3) should return {"HHH", "HHT", "HTH", "HTT", "THH", "THT", "TTH", "TTT"}
     * When finished sort them alphabetically.
     */
    public class PossibilitiesOfThrowingACoinNTimes
    {
        public static List<string> Coin(int n)
        {
            //foreach (var r in Enumerable.Range(0, (int)Math.Pow(2, n)).ToList().Select(x => Convert.ToString(x, 2).PadLeft(n, '0').Replace('1', 'T').Replace('0', 'H')).ToList())
            //    Console.WriteLine(r);

            return Enumerable.Range(0, (int)Math.Pow(2, n)).ToList().Select(x => Convert.ToString(x, 2).PadLeft(n, '0').Replace('1', 'T').Replace('0', 'H')).ToList();
        }
    }
}
