package week1;

/**
 * Flipping bits
 *
 * You will be given a list of 32 bit unsigned integers. Flip all the bits (1 -> 0 and 0 -> 1) and return
 * the result as an unsigned integer.
 *
 * Function Description
 * Complete the FlippingBits function in the editor below.
 * FlippingBits has the following parameter(s):
 *  int n: an integer
 * Returns
 *  int: the unsigned decimal integer result
 *
 * Input Format
 * The first line of the input contains q, the number of queries.
 * Each of the next q lines contain an integer, n, to process.
 */

public class FlippingBits {
    public static long flippingBits(long n) {
        long num = (1L << 32) - 1;
        return  n ^ num;
    }
}
