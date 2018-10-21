using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    public class FindTheSmallest
    {
        public static long[] Smallest(long n)
        {
            string s = n.ToString();
            if (s.Where(c => c == s.Min()).Count() == s.Length - 1)
            {
                string max = char.ToString(s.Max());
                return new long[] { Convert.ToInt64(new string(s.Min(), s.Length - 1) + max), s.IndexOf(max), s.Length - 1 };
            }
            int min = s.IndexOf(s.Max());
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] < s[i - 1] && s[i] <= s[min])
                    min = i;
            }
            int j = min - 1;
            int np = 0;
            while ((j >= 0) && s[min] <= s[j])
                np = j--;
            return new long[] { Convert.ToInt64(s.Substring(0, np) + char.ToString(s[min]) + s.Substring(np, min - np) + s.Substring(min + 1)),
                s[min] == 48 ? np : min, s[min] == 48 ? min : np };
        }
    }
}
