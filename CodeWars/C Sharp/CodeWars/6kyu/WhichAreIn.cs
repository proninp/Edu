using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Given two arrays of strings a1 and a2 return a sorted array r in lexicographical order of the strings of a1 which are substrings of strings of a2.
     * Example 1:
     * a1 = ["arp", "live", "strong"]
     * a2 = ["lively", "alive", "harp", "sharp", "armstrong"]
     * returns ["arp", "live", "strong"]
     * Example 2:
     * a1 = ["tarp", "mice", "bull"]
     * a2 = ["lively", "alive", "harp", "sharp", "armstrong"]
     * returns []
     * Notes:
     * Arrays are written in "general" notation. See "Your Test Cases" for examples in your language.
     * In Shell bash a1 and a2 are strings. The return is a string where words are separated by commas.
     * Beware: r must be without duplicates.
     */
    class WhichAreIn
    {
        public static string[] InArray(string[] array1, string[] array2) => array1.Where(a => array2.Where(x => x.Contains(a)).Count() != 0).OrderBy(s => s).ToArray();

        public static void Test1()
        {
            string[] a1 = new string[] { "tarp", "mice", "bull", "strong", "arp", "live"  };
            string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
            string[] r = InArray(a1, a2);
            foreach(var e in r) Console.WriteLine(e);
        }
    }        
}
