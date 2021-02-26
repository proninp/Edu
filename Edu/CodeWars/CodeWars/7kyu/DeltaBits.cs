using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Complete the function to determine the number of bits required to convert integer A to integer B (where A and B >= 0)
     * The upper limit for A and B is 216, int.MaxValue or similar.
     * For example, you can change 31 to 14 by flipping the 4th and 0th bit:
     * 31  0 0 0 1 1 1 1 1
     * 14  0 0 0 0 1 1 1 0
     * ---  ---------------
     * bit  7 6 5 4 3 2 1 0
     * Thus 31 and 14 should return 2.
     */
    class DeltaBits
    {
        public static int ConvertBits(int a, int b) => Convert.ToString(a ^ b, 2).Count(c => c == '1');
    }
}
