using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Complete the function power_of_two/powerOfTwo (or equivalent, depending on your language)
     * that determines if a given non-negative integer is a power of two. From the corresponding Wikipedia entry:
     * 
     * a power of two is a number of the form 2n where n is an integer,
     * i.e. the result of exponentiation with number two as the base and integer n as the exponent.
     */
    internal class PowerOfTwo
    {
        public static bool PowerOfTwoMethod(int n)
        {
            if (n == 1)
                return true;
            else if (n % 2 != 0 || n == 0)
                return false;
            return PowerOfTwoMethod(n / 2);
        }
    }
}
