using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * This time no story, no theory. The examples below show you how to write function accum:
     * Examples:
     * Accumul.Accum("abcd");    // "A-Bb-Ccc-Dddd"
     * Accumul.Accum("RqaEzty"); // "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
     * Accumul.Accum("cwAt");    // "C-Ww-Aaa-Tttt"
     */
    class Mumbling
    {
        public static String Accum(string s) => string.Join("-", s.Select((c, i) => char.ToUpper(c) + new string(char.ToLower(c), i)));
    }
}
