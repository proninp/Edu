using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._3kyu
{
    /*
     * Calculator
     * 
     * Create a simple calculator that given a string of operators (+ - * and /) and numbers separated by spaces returns the value of that expression
     * Example:
     * Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7
     * Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right.
     * Additions and subtractions have a lower priority and should also be performed left-to-right.
     * 
     */
    public class Calculator
    {
        public static double Evaluate(string expression)
        {
            string s = expression.Replace(" ", "");
            string r = Calc(s);
            return Convert.ToDouble(r);
        }

        public static string Calc(string s)
        {
            string f = Func(ref s, new char[] { '*', '/' });
            string res = Func(ref f, new char[] { '+', '-' });
            return res;
        }
        public static string Func(ref string s, char[] a)
        {
            if ((s.Contains(a[0]) || s.Contains(a[1])) && !CheckNegative(s))
            {
                int i = s.IndexOf(a[0]);
                if (i < 0) i = s.IndexOf(a[1]);
                string val = Action(BeforeSign(s, i, out int l), s[i], AfterSign(s, i, out int r));
                string lp = l == 0 ? "" : s.Substring(0, l);
                string rp = r < s.Length ? s.Substring(r) : "";
                s = lp + val + rp;
                Func(ref s, a);
            }
            return s;
        }
        public static bool CheckNegative(string s)
        {
            return (s.Length > 0 && s[0] == '-' && s.Substring(1).Length > 0 &&
                !(s.Substring(1).Contains('*') || s.Substring(1).Contains('/') || s.Substring(1).Contains('+') || s.Substring(1).Contains('-')));
        }

        public static string BeforeSign(string s, int i, out int l)
        {
            if (i == 0 && s[i] == '-') { l = 0; return "-" + AfterSign(s, i, out int r); }
            StringBuilder sb = new StringBuilder();
            while (--i >= 0 && !(new char[] { '*', '/', '+', '-' }.Contains(s[i]))) sb.Append(s[i]);
            l = i + 1;
            return string.Concat(sb.ToString().Reverse());
        }
        public static string AfterSign(string s, int i, out int r)
        {
            if (i == 0 && s[i] == '-')
            {
                i = s.Substring(1).IndexOf("-");
                if (i < 0) i = s.Substring(1).IndexOf("+");
                r = 0;
                return AfterSign(s.Substring(1), i, out int z);
            }
            StringBuilder sb = new StringBuilder();
            while (++i < s.Length && !(new char[] { '*', '/', '+', '-' }.Contains(s[i]))) sb.Append(s[i]);
            r = i;
            return sb.ToString();
        }
        public static string Action(string lp, char sign, string rp)
        {
            double res = 0;
            if (sign.Equals('*')) res = Convert.ToDouble(lp) * Convert.ToDouble(rp);
            if (sign.Equals('/')) res = Convert.ToDouble(lp) / Convert.ToDouble(rp);
            if (sign.Equals('+')) res = Convert.ToDouble(lp) + Convert.ToDouble(rp);
            if (sign.Equals('-')) res = Convert.ToDouble(lp) - Convert.ToDouble(rp);
            return res.ToString();
        }
    }
}
