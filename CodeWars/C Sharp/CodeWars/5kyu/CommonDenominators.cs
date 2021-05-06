using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    public class CommonDenominators
    {
        /*
         * Common Denominators
         * 
         * You will have a list of rationals in the form
         * { {numer_1, denom_1} , ... {numer_n, denom_n} }
         * or
         * [ [numer_1, denom_1] , ... [numer_n, denom_n] ]
         * or
         * [ (numer_1, denom_1) , ... (numer_n, denom_n) ]
         * where all numbers are positive ints.
         * You have to produce a result in the form
         * (N_1, D) ... (N_n, D)
         * or
         * [ [N_1, D] ... [N_n, D] ]
         * or
         * [ (N_1', D) , ... (N_n, D) ]
         * or
         * {{N_1, D} ... {N_n, D}}
         * depending on the language (See Example tests)
         * in which D is as small as possible and
         * N_1/D == numer_1/denom_1 ... N_n/D == numer_n,/denom_n.
         * Example:
         * convertFracs [(1, 2), (1, 3), (1, 4)] `shouldBe` [(6, 12), (4, 12), (3, 12)]
         */
        public static string ConvertFrac(long[,] lst)
        {
            long scd = 1;
            for (long i = 1; i < lst.GetLength(0); i++)
            {
                if (!(scd % lst[i, 1] == 0 && scd % lst[i - 1, 1] == 0))
                {
                    scd = SCD(lst[i, 1], lst[i - 1, 1]);
                    lst[i - 1, 0] = scd / lst[i - 1, 1] * lst[i - 1, 0];
                    lst[i, 0] = scd / lst[i, 1] * lst[i, 0];
                    lst[i - 1, 1] = lst[i, 1] = scd;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (long i = 0; i < lst.GetLength(0); i++)
            {
                if (lst[i, 1] != scd)
                {
                    lst[i, 0] = scd / lst[i, 1] * lst[i, 0];
                    lst[i, 1] = scd;
                }
                sb.Append(string.Format("({0},{1})", lst[i, 0], lst[i, 1]));
            }
            return sb.ToString();
        }

        public static long SCD(long a, long b) => a * b / GCD(a, b);

        public static long GCD(long a, long b)
        {
            while(a != b)
                if (a > b) a = a - b;
                else b = b - a;
            return a;
        }
    }
}
