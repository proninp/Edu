package com.leetcode.problems.Reverse_Integer;

public class Reverse_Integer {
    /** Given a signed 32-bit integer x, return x with its digits reversed.
     * If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
     */
    public static int reverse(int x) {
        int sign = (x < 0) ? -1 : 1;
        int[] max = {2, 1, 4, 7, 4, 8, 3, 6, 4, 7};
        x = Math.abs(x);
        int[] a = intToArray(x);
        if (!checkArrMax(max, a))
            return 0;
        return reverseUnsigned(x) * sign;
    }
    static int reverseUnsigned(int x) {
        int reverse = 0;
        while(x > 0) {
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return reverse;
    }
    static int[] intToArray(int x) {
        int len = 10;
        int[] a = new int[len];
        int i = 0;
        while (x > 0) {
            a[len - 1 - i++] = x % 10;
            x /= 10;
        }
        return a;
    }
    static boolean checkArrMax(int[] src, int[] target) {
        if (target[0] == 0)
            return true;
        boolean equality = true;
        for (int i = 0; i < src.length; i++) {
            int j = (src.length - 1 - i);
            if (src[i] > target[j])
                return true;
            if (src[i] < target[j] && equality)
                return false;
            equality = (src[i] == target[j]);
        }
        return true;
    }
    static void printArray(int[] a) {
        for (int i = 0; i < a.length; i++) {
            System.out.print(a[i] + " ");
        }
        System.out.println();
    }
}
