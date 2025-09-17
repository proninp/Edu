package main.java.com.codewars.kyu5;

import java.util.Arrays;

public class NumbersThatAreAPowerOfTheirSumOfDigits {
    public static long powerSumDigTerm2(int n) {
        int size = n + 2;
        long max = Long.MAX_VALUE;
        long[] arr = new long[size];
        int seek = 0;
        int number = 2;
        while (seek < size) {
            int doubledNumber = number * 2;
            long poweredNumber = 0;
            int pow = 1;
            while(pow < number) {
                poweredNumber = (long)Math.pow(number, ++pow);
                long numDigits = poweredNumber;
                int digitsSum = 0;
                while (numDigits > 0) {
                    digitsSum += (int)(numDigits % 10);
                    numDigits /= 10;
                }
                if (digitsSum == number) {
                    arr[seek++] = poweredNumber;
                }
                if ((digitsSum > doubledNumber) || (digitsSum == 1) || (poweredNumber > max / poweredNumber))
                    break;
            }
            number++;
        }
        Arrays.sort(arr);
        return arr[n - 1];
    }
    public static long powerSumDigTerm(int n) {
        int seekIndex = 0;
        long num = 80;
        while(seekIndex != n) {
            long numDigits = ++num;
            int digitsSum = 0;
            while (numDigits > 0) {
                digitsSum += (int)(numDigits % 10);
                numDigits /= 10;
            }
            int pow = 1;
            long found = 0;
            while(found < num && digitsSum != 1) {
                found = (long)Math.pow(digitsSum, ++pow);
            }
            if (found == num) {
                seekIndex++;
                System.out.println(seekIndex + ": " + num + "; digits sum: " + digitsSum + "; pow: " + pow);
                System.out.println();
            }

        }
        return num;
    }
}
