using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    class HighestScoringWord
    {
        /*
         * Given a string of words, you need to find the highest scoring word.
         * Each letter of a word scores points according to it's position in the alphabet: a = 1, b = 2, c = 3 etc.
         * You need to return the highest scoring word as a string.
         * If two words score the same, return the word that appears earliest in the original string.
         * All letters will be lowercase and all inputs will be valid.
         */
        public static string High(string s) => s.Split(' ').OrderBy(x => x.ToArray().Sum(c => c - 'a')).Last();
    }
}
