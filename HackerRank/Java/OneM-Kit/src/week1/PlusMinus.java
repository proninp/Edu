package week1;

import java.util.List;

/**
 * Plus Minus
 * Given an array of integers, calculate the ratios of its elements that are positive, negative, and zero. Print the
 * decimal value of each fraction on a new line with 6 places after the decimal.
 * Note: This challenge introduces precision problems. The test cases are scaled to six decimal places, though
 * answers with absolute error of up to 10^(-4) are acceptable.
 */
public class PlusMinus {
    public static void plusMinus(List<Integer> arr) {
        int[] chunks = new int[3];
        for (int e : arr) {

            if (e > 0)
                chunks[0]++;
            else if (e < 0)
                chunks[1]++;
            else
                chunks[2]++;
        }
        for (int chunk : chunks)
            System.out.printf("%.6f\n", (chunk * 1.0 / arr.size()));
    }
}
