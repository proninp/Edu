using System.Collections.Generic;
using System.Linq;

namespace CodeWars._6kyu
{
    /*
     * The main idea is to count all the occuring characters(UTF-8) in string.
     * If you have string like this aba then the result should be { 'a': 2, 'b': 1 }
     * What if the string is empty ? Then the result should be empty object literal { }
     */
    public class CountCharactersInYourString
    {
        public static Dictionary<char, int> Count(string str) => str.GroupBy(c => c).ToDictionary(gdc => gdc.Key, gdc => gdc.Count());
    }
}
