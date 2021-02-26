namespace CodeWars._7kyu
{
    /*
     * Simple Fun #2: Circle of Numbers
     * 
     * Consider integer numbers from 0 to n - 1 written down along the circle in such a way that the distance between any two
     * neighbouring numbers is equal (note that 0 and n - 1 are neighbouring, too).
     * Given n and firstNumber/first_number, find the number which is written in the radially opposite position to firstNumber.
     * Example
     * For n = 10 and firstNumber = 2, the output should be
     * circleOfNumbers(n, firstNumber) === 7
     * circleOfNumbers(n, firstNumber); // --> 7
     * circle_of_numbers($n, $first_number); // -> 7
     */
    public class SimpleFun2CircleOfNumbers
    {
        public static int CircleOfNumbers(int n, int FirstNumber) => (n / 2 + FirstNumber) % n;
    }
}
