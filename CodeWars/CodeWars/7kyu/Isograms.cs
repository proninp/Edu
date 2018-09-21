using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Isograms
     * An isogram is a word that has no repeating letters, consecutive or non-consecutive.
     * Implement a function that determines whether a string that contains only letters is an isogram.
     * Assume the empty string is an isogram. Ignore letter case.
     * isIsogram "Dermatoglyphics" == true
     * isIsogram "moose" == false
     * isIsogram "aba" == false
     */
    public class Isograms
    {
        public static bool IsIsogram(string str) => str.Length > 0 ? str.ToLower().GroupBy(c => c).Select(c => c.Count()).Max() == 1 : true;
    }
}
