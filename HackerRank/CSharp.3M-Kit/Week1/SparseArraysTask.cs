using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1;

/*
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

public class SparseArraysTask
{
    public static List<int> MatchingStrings(List<string> strings, List<string> queries)
    {
        var frequencyMap = new Dictionary<string, int>();
        foreach(string s in strings)
            if (frequencyMap.ContainsKey(s))
                frequencyMap[s]++;
            else
                frequencyMap[s] = 1;
        var res = new List<int>();
        foreach(var q in queries)
        {
            if (frequencyMap.ContainsKey(q))
                res.Add(frequencyMap[q]);
            else
                res.Add(0);
        }
        return res;
    }
}
