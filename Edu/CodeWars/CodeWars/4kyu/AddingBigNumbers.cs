using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._4kyu
{
    public class AddingBigNumbers
    {
        /*
         * Adding Big Numbers
         * We need to sum big numbers and we require your help.
         * Write a function that returns the sum of two numbers. The input numbers are strings and the function must return a string.
         * Example
         * add("123", "321"); -> "444"
         * add("11", "99"); -> "110"
         */
        public static string Add(string a, string b)
        {
            if (a.Length > b.Length) b = b.PadLeft(a.Length, '0');
            if (b.Length > a.Length) a = a.PadLeft(b.Length, '0');
            int hb = 0;
            StringBuilder r = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int sum = a[i] - 48 + b[i] - 48 + hb;
                if (sum >= 10) { hb = 1; sum -= 10; }
                else hb = 0;
                r.Append(sum);
            }
            if (hb != 0) r.Append(hb);
            return string.Concat(r.ToString().Reverse());
        }
    }
}
