package week1;

import java.util.*;

/**
 * Sparse Arrays
 *
 * There is a collection of input strings and a collection of query strings. For each query string, determine how
 * many times it occurs in the list of input strings. Return an array of the results.
 *
 * Function Description
 * Complete the function MatchingStrings in the editor below. The function must return an array of integers
 * representing the frequency of occurrence of each query string in strings.
 *
 * MatchingStrings has the following parameters:
 *  string strings[n] - an array of strings to search
 *  string queries[q] - an array of query strings
 * Returns
 *  int[q]: an array of results for each query
 */
public class SparseArrays {
    public static List<Integer> matchingStrings(List<String> strings, List<String> queries) {
        List<Integer> res = new ArrayList<>(queries.size());
        Map<String, Integer> map = new HashMap<>();
        for (String s : strings) {
            map.put(s, map.getOrDefault(s, 0) + 1);
        }
        for (String q : queries) {
            res.add(map.getOrDefault(q, 0));
        }
        return res;
    }
}
