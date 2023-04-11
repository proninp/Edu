using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeWars._6kyu
{
    /*
     * The set of words is given. Words are joined if the last letter of one word and the first letter of another word are the same.
     * Return true if all words of the set can be combined into one word.
     * Each word can and must be used only once. Otherwise return false.
     */
    internal class Millipede_of_words
    {
        public static bool Millipede(string[] arr)
        {
            char[] firsts = new char[arr.Length];
            char[] lasts = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                firsts[i] = arr[i][0];
                lasts[i] = arr[i][arr[i].Length - 1];
            }
            for (int i = 0; i < firsts.Length; i++)
            {
                if (Search(i, firsts, lasts))
                    return true;
            }
            return false;
        }
        public static bool Search(int except, char[] firsts, char[] lasts)
        {
            List<char> rests = new List<char>(lasts);
            int j = 0;
            for (int i = 0; i < firsts.Length; i++)
            {
                if (i != except)
                {
                    int index = rests.IndexOf(firsts[i]);
                    if (index < 0)
                        return false;
                        rests.RemoveAt(index);
                }
            }
            return !rests[0].Equals(firsts[except]);
        }
    }
}
