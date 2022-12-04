package com.codewars.kyu5;

import java.util.ArrayList;
import java.util.Arrays;

public class NumbersThatAreAPowerOfTheirSumOfDigits {
    public static long powerSumDigTerm(int n) {
        int seek = 0;
        long num = 11;
        long numConcat = 0;
        while(seek != n) {
            long numDigits = num++;
            int digitSum = 0;
            numConcat = 0;
            int numConcatPow = 1;
            while (numDigits > 0) {
                int digit = (int)(numDigits % 10);
                digitSum += digit;
                numDigits /= 10;
                numConcat += (long) digit * numConcatPow;
                numConcatPow *= 10;
            }
            int pow = 2;
            long found = 0;
            while(found < numConcat && digitSum != 1) {
                found = (long)Math.pow(digitSum, pow++);
            }
            if (found == numConcat)
                seek++;
        }
        return numConcat;
    }
}
