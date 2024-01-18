namespace Week2;

/*
 * Diagonal Difference
 * 
 * Given a square matrix, calculate the absolute difference between the sums of its diagonals.
 * For example, the square matrix arr is shown below:
 * 1 2 3
 * 4 5 6
 * 9 8 9  
 * 
 * The left-to-right diagonal = 1+ 5 + 9 = 15. The right to left diagonal = 3 + 5 + 9 = 17.
 * Their absolute difference is |15 - 17| = 2
 * 
 * Function description
 * Complete the DiagonalDifference function in the editor below.
 * 
 * DiagonalDifference takes the following parameter:
 *  int arr[n][m]: an array of integers
 * 
 * Return
 *  int: the absolute diagonal difference
 * 
 * Input Format
 * The first line contains a single integer, n, the number of rows and columns in the square matrix arr.
 * Each of the next n lines describes a row, arr[i], and consists of n space-separated integers arr[i][j].
 */

public class DiagonalDifferenceTask
{
    public static int DiagonalDifference(List<List<int>> arr)
    {
        int leftDiagonalSum = 0;
        int rightDiagonalSum = 0;
        int size = arr.Count;
        for (int i = 0; i < size; i++)
        {
            leftDiagonalSum += arr[i][i];
            rightDiagonalSum += arr[i][size - 1 - i];
        }
        return Math.Abs(leftDiagonalSum - rightDiagonalSum);
    }
}
