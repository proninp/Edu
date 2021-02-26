using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    /*
     * We have a string s
     * We have a number n
     * Here is a function that takes your string, concatenates the even-indexed chars to the front, odd-indexed chars to the back.
     * Examples
     * s = "Wow Example!"
     * result = "WwEapeo xml!"
     * s = "I'm JomoPipi"
     * result = "ImJm ii' ooPp"
     * The Task:
     * return the result of the string after applying the function to it n times.
     * example where s = "qwertyuio" and n = 2:
     * after 1 iteration  s = "qetuowryi"
     * after 2 iterations s = "qtorieuwy"
     * return "qtorieuwy"
     * Note
     * There are 50000 random tests where
     * the string contains between 50 and 200 chars
     * n is greater than a billion
     * so be ready to optimize.
     */
    class StringNIterationsString
    {
        public static string JumbledString(string s, long n)
        {
            int elInd = 1, steps = 0;
            do
            {
                if (elInd % 2 == 0 && (elInd & (elInd - 1)) == 0)
                {
                    steps += (int)Math.Log(elInd, 2);
                    break;
                }
                if (elInd == s.Length)
                {
                    steps *= 2;
                    break;
                }
                if (elInd % 2 == 0) elInd /= 2;
                else elInd += (s.Length - elInd) / 2;
                steps++;
            } while (elInd != 1);

            int[,] a = new int[steps, s.Length];
            for (int i = 0; i < steps; i++)
                for (int j = 0; j < s.Length; j++)
                    if (i == 0) a[i, j] = j;
                    else
                    {
                        if (a[i - 1, j] % 2 == 0) a[i, j] = a[i - 1, j] / 2;
                        else a[i, j] = a[i - 1, j] + (s.Length - a[i - 1, j]) / 2;
                    }
            char[] ac = new char[s.Length];
            for (int k = 0; k < s.Length; k++)
                ac[a[n % steps, k]] = s[k];
            return new string(ac);
        }

    }
}
