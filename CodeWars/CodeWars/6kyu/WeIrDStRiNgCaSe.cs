using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    class WeIrDStRiNgCaSe
    {
        /*
         * Write a function toWeirdCase (weirdcase in Ruby) that accepts a string, and returns the same string with all even indexed characters in each word upper cased,
         * and all odd indexed characters in each word lower cased. The indexing just explained is zero based, so the zero-ith index is even,
         * therefore that character should be upper cased.
         * 
         * The passed in string will only consist of alphabetical characters and spaces(' '). Spaces will only be present if there are multiple words. Words will be separated by a single space(' ').
         * Examples:
         * toWeirdCase( "String" );//=> returns "StRiNg"
         * toWeirdCase( "Weird string case" );//=> returns "WeIrD StRiNg CaSe"
         */
        public static string ToWeirdCase(string s)
        {
            return string.Join(" ", s.Split(' ').Select(e => string.Join("", e.Select((value, index) => (index % 2 == 0) ? char.ToUpper(value) : char.ToLower(value)))));
        }
    }
}
