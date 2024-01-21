namespace Namespace;

/*
 * Pangrams
 * 
 * A pangram is a string that contains every letter of the alphabet.  Given a
 * sentence determine whether it is a pangram in the English alphabet. Ignore
 * case. Return either pangram or not pangram as appropriate.
 * 
 * Function Description
 * Complete the function Pangrams in the editor below. It should return the
 * string pangram if the input string is a pangram. Otherwise, it should return
 * not pangram.
 * 
 * pangrams has the following parameter(s):
 *  string s: a string to test
 * 
 * Returns
 *  string: either pangram or not pangram
 */
public class PangramsTask
{
    public static string Pangrams(string s)
    {
        var alphabet = new int[26];
        foreach (var c in s)
            if (char.IsLetter(c))
                alphabet[char.ToLower(c) - 'a']++;
        return alphabet.Min() == 0 ? "not pangram" : "pangram";
    }
}
