package week1.mockTest;

import java.util.Collections;
import java.util.List;

public class MockTest {
    public static int findMedian(List<Integer> arr) {
        Collections.sort(arr);
        return arr.get(arr.size() / 2);
    }
    public static int flippingMatrix(List<List<Integer>> matrix) {
        int len = matrix.size() / 2;
        int max, maxSum = 0;
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len; j++) {
                max = Integer.MIN_VALUE;
                max = Math.max(max, matrix.get(i).get(j));
                max = Math.max(matrix.get(len * 2 - 1 - i).get(j), max);
                max = Math.max(matrix.get(i).get(len * 2 - 1 - j), max);
                max = Math.max(matrix.get(len * 2 - 1 - i).get(len * 2 - 1 - j), max);
                maxSum += max;
            }
        }
        return maxSum;
    }
}
