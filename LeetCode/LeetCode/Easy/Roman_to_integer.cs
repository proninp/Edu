using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    public class Roman_to_integer
    {
        public static int RomanToInt(string s)
        {
            StringBuilder builder = new StringBuilder(s.Length);
            builder.Append(s);
            StringBuilder stringBuilder = new StringBuilder(2);
            int result = 0;
            string[] romanArray = new string[] { "I", "V", "X", "L", "C", "D", "M"};
            int[] numericArray = new int[] { 1, 5, 10, 50, 100, 500, 1000 };
            string[] romanSecArray = new string[] { "IV", "IX", "XL", "XC", "CD", "CM" };
            int[] numericSecArray = new int[] { 4, 9, 40, 90, 400, 900 };
            
            while (builder.Length > 0)
            {
                int numeric = 0;
                if (builder.Length > 1)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(builder.ToString(0, 2));
                    for (int i = 0; i < romanSecArray.Length; i++)
                        if (stringBuilder.ToString().Equals(romanSecArray[i]))
                            numeric = numericSecArray[i];
                }
                if (numeric == 0)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(builder.ToString(0, 1));
                    for (int i = 0; i < romanArray.Length; i++)
                        if (stringBuilder.ToString().Equals(romanArray[i]))
                                numeric = numericArray[i];
                }
                builder.Remove(0, stringBuilder.Length);
                result += numeric;
            }
            return result;
        }
   }
}
