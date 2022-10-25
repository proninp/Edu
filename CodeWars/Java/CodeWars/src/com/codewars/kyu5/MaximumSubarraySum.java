package com.codewars.kyu5;

public class MaximumSubarraySum {
    public static int sequence(int[] arr) {
        int sum = 0;
        int currSum = 0;
        for (int i = 0; i < arr.length; i++) {
            if (currSum < 0)
                currSum = 0;
            currSum += arr[i];
            if (currSum > sum)
                sum = currSum;
        }
        return sum;
    }
    public static int sequence2(int[] arr) {
        int sum = 0;
        for (int i = 0; i < arr.length; i++) {
            int currSum = 0;
            for (int j = i; j < arr.length; j++) {
                currSum += arr[j];
                if (currSum > sum) {
                    sum = currSum;
                }
            }
        }
        return sum;
    }
}
