using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * In this kata, you must create a digital root function.
     * A digital root is the recursive sum of all the digits in a number. Given n, take the sum of the digits of n. If that value has two digits, continue reducing in this way until a single-digit number is produced. This is only applicable to the natural numbers.
     * Here's how it works (Ruby example given):
     * digital_root(16)
     * => 1 + 6
     * => 7
     * 
     * digital_root(942)
     * => 9 + 4 + 2
     * => 15 ...
     * => 1 + 5
     * => 6
     * 
     * digital_root(132189)
     * => 1 + 3 + 2 + 1 + 8 + 9
     * => 24 ...
     * => 2 + 4
     * => 6
     * 
     * digital_root(493193)
     * => 4 + 9 + 3 + 1 + 9 + 3
     * => 29 ...
     * => 2 + 9
     * => 11 ...
     * => 1 + 1
     * => 2
     */
    class SumOfDigitsDigitalRoot
    {
        public static int DigitalRoot(long n)
        {
            //return (int)(1 + (n - 1) % 9);
            return (n.ToString().Length == 1) ? (int)n : DigitalRoot(n.ToString().ToCharArray().Sum(c => c - 48));
        }
    }
}
