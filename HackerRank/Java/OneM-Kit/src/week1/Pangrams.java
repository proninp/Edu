package week1;

import java.util.*;

/**
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

public class Pangrams {
    public static String pangrams(String s) {
        Set<Character> set = new HashSet<>();
        for(char c : s.toCharArray()) {
            if (Character.isLetter(c))
                set.add(Character.toLowerCase(c));
        }
        return set.size() == 26 ? "pangram" : "not pangram";
    }
}
