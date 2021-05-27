using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * Complete the solution so that it returns true if the first argument(string)
     * passed in ends with the 2nd argument (also a string).
     * strEndsWith('abc', 'bc') -- returns true
     * strEndsWith('abc', 'd') -- returns false
     */
    public class StringEndsWith
    {
        public static bool Solution(string str, string ending) => str.EndsWith(ending);
    }
}
