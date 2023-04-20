using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Lesson04
{
    internal class Program
    {
        public static int elementsCount = 10000;
        public static char[] valueToSearch = { 's', 'e', 'a', 'r', 'c', 'h', 'a', 'b', 'l', 'e' };
        public static string[] wordsArray = new string[elementsCount];
        public static HashSet<string> wordsSet = new HashSet<string>();


        static void Main(string[] args)
        {
            PrepareData(wordsArray, wordsSet, elementsCount, valueToSearch);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        public static void PrepareData(string[] wordsArray, HashSet<string> wordsSet, int elementsCount, char[] valueToSearch)
        {
            // A - Z : 65 - 90
            // a - z : 97 - 122
            int upperADigit = 65;
            int upperZDigit = 90;
            int lowerADigit = 97;
            int lowerZDigit = 122;
            int wordLengthMin = 5;
            int wordLengthMax = 10;
            int wordLength;
            int caseSwitcher;

            int i = 0;
            int j;
            char letter;

            Random random = new Random();
            while (i < elementsCount)
            {
                wordLength = random.Next(wordLengthMin, wordLengthMax + 1);
                char[] word;
                if (i != elementsCount / 2)
                {
                    word = new char[wordLength];
                    j = 0;

                    while (j < wordLength)
                    {
                        caseSwitcher = random.Next(0, 2);
                        if (caseSwitcher == 0)
                            letter = (char)random.Next(upperADigit, upperZDigit + 1);
                        else
                            letter = (char)random.Next(lowerADigit, lowerZDigit + 1);
                        word[j] = letter;
                        j++;
                    }
                }
                else
                    word = valueToSearch;

                wordsArray[i] = new string(word);
                wordsSet.Add(wordsArray[i]);
                i++;
            }
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkClass
    {
        [Benchmark]
        public void TestContainsInArray()
        {
            bool contains = Program.wordsArray.Contains(new string(Program.valueToSearch));
        }
        [Benchmark]
        public void TestContainsInSet()
        {
            bool contains = Program.wordsSet.Contains(new string(Program.valueToSearch));
        }
    }
    
}