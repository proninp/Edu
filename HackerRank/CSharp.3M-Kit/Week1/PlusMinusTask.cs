namespace Week1
{
    /*
     * Week 1
     * Plus Minus
     * 
     * Given an array of integers, calculate the ratios of its elements that are positive,
     * negative, and zero. Print the decimal value of each fraction on a new line with  places after the decimal.
     * 
     * Note: This challenge introduces precision problems.
     * The test cases are scaled to six decimal places, though answers with absolute error of up to  are acceptable.
     * 
     * Example
     * arr = [1, 1, 0, -1, -1]
     * 
     * There are  elements, two positive, two negative and one zero. Their ratios are:
     * 2/5 = 0.400000
     * 2/5 = 0.400000
     * 1/5 = 0.200000
     * 
     * Function Description
     * 
     * Complete the PlusMinus function in the editor below.
     * PlusMinus has the following parameter(s):
     * int arr[n]: an array of integers
     * 
     * Print
     * Print the ratios of positive, negative and zero values in the array.
     * Each value should be printed on a separate line with  digits after the decimal.
     * The function should not return a value.
     */
    public class PlusMinusTask
    {
        public static void PlusMinus(List<int> arr)
        {
            var res = new int[3];
            foreach (var e in arr)
            {
                if (e > 0)
                    res[0]++;
                else if (e < 0)
                    res[1]++;
                else
                    res[2]++;
            }
            for (int i = 0; i < res.Length; i++)
                Console.WriteLine(string.Format("{0:0.000000}", res[i] / arr.Count));
        }
    }
}
