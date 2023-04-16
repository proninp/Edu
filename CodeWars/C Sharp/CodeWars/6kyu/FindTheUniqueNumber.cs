using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * There is an array with some numbers. All numbers are equal except for one. Try to find it!
     * findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
     * findUniq([ 0, 0, 0.55, 0, 0 ]) === 0.55
     */
    internal class FindTheUniqueNumber
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var n in numbers)
                if (map.ContainsKey(n))
                    map[n]++;
                else
                    map[n] = 1;
            return map.OrderBy(x => x.Value).First().Key;
        }
    }
}
