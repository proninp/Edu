using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * Complete the method/function so that it converts dash/underscore delimited words into camel casing.
     * The first word within the output should be capitalized only if the original word was capitalized.
     * Examples
     * Kata.ToCamelCase("the-stealth-warrior") // returns "theStealthWarrior"
     * Kata.ToCamelCase("The_Stealth_Warrior") // returns "TheStealthWarrior"
     */
    public class ConvertStringToCamelCase
    {
        public static string ToCamelCase(string str)
        {
            return string.Join("", str.Split(new char[]{ '_', '-' }).Select((c, index) => (index == 0) ? c : char.ToUpper(c.First()) + c.Substring(1)));
            //return Regex.Replace(str, @"[_-](\w)", m => m.Groups[1].Value.ToUpper()); //???
        }
    }
}
