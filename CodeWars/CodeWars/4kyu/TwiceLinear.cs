using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._4kyu
{
    /*
     * Consider a sequence u where u is defined as follows:
     * The number u(0) = 1 is the first one in u.
     * For each x in u, then y = 2 * x + 1 and z = 3 * x + 1 must be in u too.
     * There are no other numbers in u.
     * Ex: u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, ...]
     * 1 gives 3 and 4, then 3 gives 7 and 10, 4 gives 9 and 13, then 7 gives 15 and 22 and so on...
     * #Task: Given parameter n the function dbl_linear (or dblLinear...) returns the element u(n) of the ordered (with <) sequence u.
     * #Example: dbl_linear(10) should return 22
     * #Note: Focus attention on efficiency
     */
    public class TwiceLinear
    {
        public static int DblLinear(int n)
        {
            //int i = 0, p = 0;
            //int[] a = new int[n+1];
            //a[i] = 1;
            //while(p <= n)
            //{
            //    int dbl = a[i] * 2 + 1;
            //    int trpl = a[i++] + dbl;
            //    if (!a.Contains(dbl))
            //        a[++p] = dbl;
            //    for (int j = i; j < a.Length; j++)
            //    {
            //        if (a[j] == 0) break;
            //        int dbl2 = a[j] * 2 + 1;
            //        if (dbl2 < trpl && !a.Contains(dbl2))
            //        {
            //            if (++p < a.Length) a[p] = dbl2;
            //            else break;
            //        }
            //    }
            //    if (++p < a.Length) a[p] = trpl;
            //    else break;
            //}
            //foreach (var x in a)
            //    Console.Write(x + ", ");
            //Console.WriteLine();
            //Console.WriteLine();
            //return a[n];

            List<int> l = new List<int>();
            l.Add(1);
            int i = 0;
            while (i <= n)
            {
                int dbl = l[i] * 2 + 1;
                int trpl = l[i++] + dbl;
                l.Add(dbl);
                l.Add(trpl);
                //for (int j = i; j < l.Count(); j++)
                //{
                //    int dbl2 = l[j] * 2 + 1;
                //    if (dbl2 < trpl && !l.Contains(dbl2)) l.Add(dbl2);
                //}
                //l.Add(trpl);
            }
            l = l.Distinct().ToList();
            foreach (var x in l)
                Console.Write(x + ", ");
            Console.WriteLine();
            Console.WriteLine();
            //return l.Distinct().OrderBy(x => x).ToList()[n];

            //List<int> l = new List<int>();
            l.Clear();
            l.Add(1);
            i = 0;
            while (i <= n)
            {
                int dbl = l[i] * 2 + 1;
                int trpl = l[i++] + dbl;
                //if (!l.Contains(dbl))
                l.Add(dbl);
                for (int j = i; j < l.Count(); j++)
                {
                    int dbl2 = l[j] * 2 + 1;
                    if (dbl2 < trpl && !l.Contains(dbl2)) l.Add(dbl2);
                }
                l.Add(trpl);
            }
            l = l.Distinct().ToList();
            foreach (var x in l)
                Console.Write(x + ", ");
            return l.Distinct().OrderBy(x => x).ToList()[n];
        }

    }
}
