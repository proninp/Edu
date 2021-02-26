using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    /*
     * I'm sure, you know Google's "Did you mean ...?", when you entered a search term and mistyped a word.
     * In this kata we want to implement something similar.
     * You'll get an entered term (lowercase string) and an array of known words (also lowercase strings).
     * Your task is to find out, which word from the dictionary is most similar to the entered one.
     * The similarity is described by the minimum number of letters you have to add, remove or replace in order
     * to get from the entered word to one of the dictionary.
     * The lower the number of required changes, the higher the similarity between each two words.
     * Same words are obviously the most similar ones.
     * A word that needs one letter to be changed is more similar to another word that needs 2 (or more) letters to be changed.
     * E.g. the mistyped term berr is more similar to beer (1 letter to be replaced) than to barrel (3 letters to be changed in total).
     * Extend the dictionary in a way, that it is able to return you the most similar word from the list of known words.
     * 
     * Code Examples:
     * var fruits = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
     * fruits.FindMostSimilar("strawbery"); // must return "strawberry"
     * fruits.FindMostSimilar("berry"); // must return "cherry"
     * things = new Dictionary(new List<string> { "stars", "mars", "wars", "codec", "codewars" });
     * things.FindMostSimilar("coddwars"); // must return "codewars"
     * languages = new Dictionary(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript" });
     * languages.FindMostSimilar("heaven"); // must return "java"
     * languages.FindMostSimilar("javascript"); // must return "javascript" (same words are obviously the most similar ones)
     */
    public class DidYouMean
    {
        private IEnumerable<string> words;

        public DidYouMean(IEnumerable<string> words)
        {
            this.words = words;
        }

        public string FindMostSimilar(string term)
        {
            List<string> w = words.ToList();

            for (int i = 0; i < w.Count; i++)
            {
                foreach (char c in term)
                {
                    if (w[i].Contains(c.ToString()))
                        w[i] = w[i].Replace(c.ToString(), "");
                }
                if (w[i].Length < term.Length)
                    w[i] += new string('a', term.Length - w[i].Length);
            }
            return words.ElementAt(w.IndexOf(w.OrderBy(s => s.Length).First()));
        }
    }
}