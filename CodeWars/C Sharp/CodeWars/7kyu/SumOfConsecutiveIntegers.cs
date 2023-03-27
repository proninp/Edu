using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeWars._7kyu
{
    /// <summary>
    /// The sum of x consecutive integers is y. 
    /// What is the consecutive integer at position n? Given x, y, and n, solve for the integer.
    /// Assume the starting position is 0.
    /// For example, if the sum of 4 consecutive integers is 14, what is the consecutive integer at position 3?
    /// We find that the consecutive integers are[2, 3, 4, 5], so the integer at position 3 is 5.
    /// </summary>
    internal class SumOfConsecutiveIntegers
    {
        public static int Position(int x, int y, int n)
        {
            int difference = (x * (x - 1)) / 2;
            int first = (y - difference) / x;
            return first + n;
        }
    }
}
