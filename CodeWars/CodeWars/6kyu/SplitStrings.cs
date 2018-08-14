using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Complete the solution so that it splits the string into pairs of two characters.
     * If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
     * Examples:
     * SplitString.Solution("abc"); // should return ["ab", "c_"]
     * SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]

     */
    class SplitStrings
    {
        public static string[] Solution(string str)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < str.Length / 2; i++)
                s.Add(string.Join("", str.Skip(i * 2).Take(2)));
            if (str.Length % 2 != 0) s.Add(str[str.Length - 1] + "_");
            return s.ToArray();

            //if (str.Length % 2 != 0) str += '_';
            //return Enumerable.Range(0, str.Length / 2).Select(i => str.Substring(2 * i, 2)).ToArray();
        }
    }
}
