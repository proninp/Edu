namespace Week2;

public class W2MockTest
{
    public static int FlippingMatrix(List<List<int>> matrix)
    {
        int len = matrix.Count / 2;
        int max, maxSum = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                max = int.MinValue;
                max = Math.Max(matrix[i][j], max);
                max = Math.Max(matrix[len * 2 - 1 - i][j], max);
                max = Math.Max(matrix[i][len * 2 - 1 - j], max);
                max = Math.Max(matrix[len * 2 - 1 - i][len * 2 - 1 - j], max);
                maxSum += max;
            }
        }
        return maxSum;
    }
}
