using System.Linq;

namespace CodeWars._6kyu
{
    /*
     * String Letter Counting
     * Take a string str and return a string that is made up of the number of occurances of each english letter in str,
     * followed by that letter. The string shouldn't contain zeros; leave them out.
     * An empty string, or one with no letters, should return an empty string.
     * Ignore all case.
     * str will never be null.
     * For Example:
     * Kata.StringLetterCount("This is a test sentence.") == "1a1c4e1h2i2n4s4t"
     * Kata.StringLetterCount("") == ""
     * Kata.StringLetterCount("555") == ""
     */
    public class StringLetterCounting
    {
        public static string StringLetterCount(string str) =>  string.Concat(str.ToLower().Where(c => char.IsLetter(c)).Distinct().
            OrderBy(c => c).Select(c => string.Concat(str.ToLower().Where(x => x.Equals(c)).Count(), c)));
    }
}
