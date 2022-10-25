package com.codewars.kyu7;

public class BeginnerSeriesSumOfNumbers {
    public static int GetSum(int a, int b)
    {
        if (a == b)
            return a;
        int max = a;
        int min = b;
        if (b > a) {
            max = b;
            min = a;
        }
        int sum = 0;
        while (max >= min) {
            sum += min++;
        }
        return sum;
    }
}
