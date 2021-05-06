namespace CodeWars._7kyu
{
    /*
     * Sum of odd numbers
     * Given the triangle of consecutive odd numbers:

                     1
                  3     5
               7     9    11
           13    15    17    19
        21    23    25    27    29
        ...
        Calculate the row sums of this triangle from the row index (starting at index 1) e.g.:
        
     * rowSumOddNumbers(1); // 1
     * rowSumOddNumbers(2); // 3 + 5 = 8
     */
    public class SumOfOddNumbers
    {
        public static long RowSumOddNumbers(long n)
        {
            long sum = n * (n + 1) - 1;
            long t = sum;
            for (int i = 1; i < n; i++) sum += t  - i * 2;
            return sum;
        }
    }
}
