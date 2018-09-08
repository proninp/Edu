using System;

namespace CodeWars._6kyu
{
    /*
     * Positions Average
     * Suppose you have 4 numbers: '0', '9', '6', '4' and 3 strings composed with them:
     * s1 = "6900690040"
     * s2 = "4690606946"
     * s3 = "9990494604"
     * Compare s1 and s2 to see how many positions they have in common: 0 at index 3, 6 at index 4, 4 at index 8 ie 3 common positions out of ten.
     * Compare s1 and s3 to see how many positions they have in common: 9 at index 1, 0 at index 3, 9 at index 5 ie 3 common positions out of ten.
     * Compare s2 and s3. We find 2 common positions out of ten.
     * So for the 3 strings we have 8 common positions out of 30 ie 0.2666... or 26.666...%
     * Given a set of n strings our function pos_average will calculate the average percentage of 
     * positions that are the same between the (n * (n-1)) / 2 sets of strings taken amongst the given 'n' strings.
     * The function returns the percentage formatted as a float with 10 decimals but the
     * result is tested at 1e.-9 (see function assertFuzzy in the tests).
     * Example:
     * Given string s = "444996, 699990, 666690, 096904, 600644, 640646, 606469, 409694, 666094, 606490" composing a set of n = 10 substrings
     * (hence 45 combinations), pos_average returns 29.2592592593.
     * In a set the n strings will have the same length ( > 0 ).
     */
    public class PositionsAverage
    {
        public static double PosAverage(string s)
        {
            string[] a = s.Split(new string[] { ", " }, StringSplitOptions.None);
            int commonPos = 0;
            for (int i = 0; i < a.Length; i++)
                for (int j = i + 1; j < a.Length; j++)
                    for (int k = 0; k < a[i].Length; k++)
                        if (a[i][k] == a[j][k]) commonPos++;
            Console.WriteLine(commonPos);
            Console.WriteLine(a[0].Length * (a.Length * (a.Length - 1)) / 2);
            return Math.Round((double) commonPos / (a[0].Length * (a.Length * ( a.Length - 1)) / 2) * 100, 10);
        }
    }
}
