using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    class SimplePigLatin
    {
        /*
         * Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.
         * Examples
         * Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
         * Kata.PigIt("Hello world !");     // elloHay orldWay !
         */
        public static string PigIt(string str) => string.Join(" ", str.Split(' ').Select(s => !char.IsPunctuation(s[0]) ? string.Concat(s.Substring(1), s[0], "ay") : s));
    }
}
