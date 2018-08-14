using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    class TripleTrouble
    {
        /*
         * Write a function
         * TripleDouble(long num1, long num2.
         * which takes in numbers num1 and num2 and returns 1 if there is a straight triple of a number at any place in num1 and also a straight double of the same number in num2.
         * For example:
         * TripleDouble(451999277, 41177722899) == 1 // num1 has straight triple 999s and 
         * // num2 has straight double 99s
         * TripleDouble(1222345, 12345) == 0 // num1 has straight triple 2s but num2 has only a single 2
         * TripleDouble(12345, 12345) == 0
         * TripleDouble(666789, 12345667) == 1
         * If this isn't the case, return 0
         */
        public static int TripleDouble(long num1, long num2)
        {
            return (num1.ToString().Substring(0, num1.ToString().Length - 3).ToList().Select((value, index) => (value == num1.ToString()[index + 1] &&
            value == num1.ToString()[index + 2]) ? ((num2.ToString().IndexOf(value.ToString() + value.ToString()) > 0) ? "1" : "") : "").Contains("1")) ? 1 : 0;
            //List<char> list = num1.ToString().ToList();
            //for (int i = 0; i < list.Count-2; i++)
            //    if (list[i].CompareTo(list[i + 1]) == 0 && list[i].CompareTo(list[i + 2]) == 0)
            //        if (num2.ToString().IndexOf(list[i].ToString() + list[i + 1]) > 0)
            //            return 1;
            //return 0;
        }
    }
}
