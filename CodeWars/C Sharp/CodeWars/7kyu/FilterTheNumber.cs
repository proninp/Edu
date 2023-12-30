using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Filter the number
     * 
     * Oh, no! The number has been mixed up with the text.
     * Your goal is to retrieve the number from the text, can you return the number back to its original state?
     * 
     * Task
     * Your task is to return a number from a string.
     * 
     * Details
     * You will be given a string of numbers and letters mixed up,
     * you have to return all the numbers in that string in the order they occur.
     */
    public class FilterTheNumber
    {
        public static int FilterString(string s)
        {
            int n = 0;
            foreach(var e in s)
            {
                if (char.IsDigit(e))
                {
                    if (n != 0)
                        n *= 10;
                    n += e - '0';
                }
            }
            return n;
            //return int.Parse(string.Concat(s.Where(char.IsNumber)));
        }
    }
}
