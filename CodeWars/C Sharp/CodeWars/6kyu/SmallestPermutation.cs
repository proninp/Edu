using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Given a number, find the permutation with the smallest absolute value (no leading zeros).
     * -20 => -20
     * -32 => -23
     * 0 => 0
     * 10 => 10
     * 29394 => 23499
     */
    public class SmallestPermutation
    {
        public static int MinPermutation(int n)
        {
            //int ZeroCount = n.ToString().Where(c => c.Equals('0')).Count();
            //n.ToString().First().ToString() + (new String('0', n.ToString().Where(c => c.Equals('0')).Count())) + n.ToString().Skip(1)
            return (n > 0) ? int.Parse((n.ToString().First().ToString() + (new String('0', n.ToString().Where(c => c.Equals('0')).Count())) + n.ToString().Skip(1))) :
                int.Parse("-" + (new String(n.ToString().Replace("-", "").OrderByDescending(c => c).ToArray())));
        }
    }
}
