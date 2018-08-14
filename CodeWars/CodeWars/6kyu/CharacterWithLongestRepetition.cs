using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * For a given string s find the character c with longest consecutive repetition and return a tuple (c, l) (in Haskell Just (Char, Int),
     * in C# Tuple<char?, int>, in Shell a String of comma-separated values c,l, in JavaScript [c,l], in Ruby [c, l]) where l is the length of the repetition.
     * If there are two or more characters with the same l return the first.
     * For empty string return ('', 0) (in Haskell Nothing, in C# Tuple<char, int>(null, 0), in Shell ,0, in JavaScript ["",0], in Ruby ["", 0]).
     */
    class CharacterWithLongestRepetition
    {
        public static Tuple<char?, int> LongestRepetition(string input)
        {
            if (input == "") return new Tuple<char?, int>(null, 0);
            int max = 1;
            char c = input[0];
            for (int i = 0; i < input.Length-1; i++)
            {
                int count = 1;
                while (i != (input.Length - 1) && input[i] == input[i + 1])
                {
                    count++;
                    i++;
                }
                if (count > max) { max = count; c = input[i]; }
            }
            return new Tuple<char?, int>(c, max);
        }
    }
}
