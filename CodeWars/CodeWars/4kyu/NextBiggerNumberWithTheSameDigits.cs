using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._4kyu
{
    class NextBiggerNumberWithTheSameDigits
    {
        public static long NextBiggerNumber(long n)
        {
            char[] ac = n.ToString().ToArray();
            for (int i = ac.Length-1; i > 0; i--)
            {
                if (ac[i] > ac[i - 1])
                {
                    int x = i;
                    if (i + 1 < ac.Length)
                        if (ac[i - 1] < ac[i + 1] && ac[i + 1] < ac[i]) x = i + 1;
                    char c = ac[x];
                    ac[x] = ac[i - 1];
                    ac[i - 1] = c;
                    for (int j = i; j < ac.Length-1; j++)
                        if (ac[i] > ac[i+1])
                        {
                            c = ac[i];
                            ac[i] = ac[i + 1];
                            ac[i + 1] = c;
                        }
                    break;
                }
            }

            return (n.ToString() == new string(ac)) ? -1 : long.Parse(new string(ac));
        }
    }
}
