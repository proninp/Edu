using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Write a function that takes an (unsigned) integer as input, and returns the number of bits that are equal to one in the binary representation of that number.
     * Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
     */
    class BitCounting
    {
        public static int CountBits(int n) => Convert.ToString(n, 2).Replace("0", "").Length;
    }
}
