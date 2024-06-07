package com.javarush.task.task20.task2025;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.TreeSet;
import java.util.Collections;
import java.util.List;

/* 
Алгоритмы-числа
*/

public class Solution {

    public static long[] getNumbers(long N) {
        if (N < 1L) return new long[0];
        long[] result;
        TreeSet<Long> treeSet = new TreeSet<>();
        int digits = 10;

        int digitsCount = getDigitsCount(N);
        long[][] powers = new long[digits][digitsCount + 1];
        for (int i = 0; i < digits; i++) {
            powers[i][1] = i;
        }
        for (int i = 1; i < digits; i++) {
            for (int j = 2; j <= digitsCount; j++) {
                powers[i][j] = powers[i][j-1] * i;
            }
        }

        int[] numbers = new int[digitsCount];
        Arrays.fill(numbers, 9);
        int index = 0;
        long number;
        while (index < numbers.length) {
            while(numbers[index] >= 0) {
                number = getDigitsNumber(numbers);
                checkNumber(N, treeSet, numbers, powers, number);
                if (numbers[index] == 0)
                    break;
                numbers[index]--;
            }
            while(index < numbers.length && numbers[index] == 0)
                index++;

            if (index < numbers.length) {
                Arrays.fill(numbers, 0, index + 1, numbers[index] - 1);
                index = 0;
            }
        }
        result = treeSet.stream().mapToLong(Long::longValue).filter(x -> x > 0 && x < N).toArray();
        treeSet.clear();
        return result;
    }

    public static void checkNumber(long N, TreeSet<Long> treeSet, int[] numbers, long[][] powers, long number) {
        if (number >= N)
            return;
        long powersSum, powerSum2;
        int i = 0;
        do {
            powersSum = getDigitsPowerSum(numbers, powers, i);
            if (number == powersSum) {
                treeSet.add(powersSum);
            }
            if (powersSum < N) {
                powerSum2 = getDigitsPowerSum(powersSum, powers, 0);
                if (powersSum == powerSum2) {
                    treeSet.add(powerSum2);
                }
            }
        } while (i < numbers.length && numbers[i++] == 0);
    }

    public static long getDigitsPowerSum(int[] numbers, long[][] powers, int fromIndex) {
        long digitsPowerSum = 0;
        for (int i = fromIndex; i < numbers.length; i++) {
            digitsPowerSum += powers[numbers[i]][numbers.length - fromIndex];
        }
        return digitsPowerSum;
    }

    public static long getDigitsPowerSum(long number, long[][] powers, int fromIndex) {
        long digitsPowerSum = 0;
        long tmpSum;
        int digitsCount = getDigitsCount(number);
        while(number > 0) {
            tmpSum = powers[(int) (number % 10)][digitsCount - fromIndex];
            if (digitsPowerSum > digitsPowerSum + tmpSum)
                return tmpSum;
            digitsPowerSum += powers[(int) (number % 10)][digitsCount - fromIndex];
            number /= 10;
        }
        return digitsPowerSum;
    }

    public static long getDigitsNumber(int[] numbers) {
        long number = 0;
        long power = 1;
        for (int i = numbers.length - 1; i >= 0; i--) {
            number += (long) numbers[i] * power;
            power *= 10;
        }
        return number;
    }

    public static int getDigitsCount(long n) {
        int digitsCount = 0;
        while (n > 0) {
            n /= 10;
            digitsCount++;
        }
        return digitsCount;
    }

    public static void main(String[] args) {
        long a = System.currentTimeMillis();
        System.out.println(Arrays.toString(getNumbers(1000)));
        long b = System.currentTimeMillis();
        System.out.println("memory " + (Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory()) / (8 * 1024));
        System.out.println("time = " + (b - a) / 1000);

        a = System.currentTimeMillis();
        System.out.println(Arrays.toString(getNumbers(1000000)));
        b = System.currentTimeMillis();
        System.out.println("memory " + (Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory()) / (8 * 1024));
        System.out.println("time = " + (b - a) / 1000);

        a = System.currentTimeMillis();
        System.out.println(Arrays.toString(getNumbers(548834)));
        b = System.currentTimeMillis();
        System.out.println("memory " + (Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory()) / (8 * 1024));
        System.out.println("time = " + (b - a) / 1000);

        a = System.currentTimeMillis();
        System.out.println(Arrays.toString(getNumbers(10)));
        b = System.currentTimeMillis();
        System.out.println("memory " + (Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory()) / (8 * 1024));
        System.out.println("time = " + (b - a) / 1000);

        a = System.currentTimeMillis();
        System.out.println(Arrays.toString(getNumbers(Long.MAX_VALUE)));
        b = System.currentTimeMillis();
        System.out.println("memory " + (Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory()) / (8 * 1024));
        System.out.println("time = " + (b - a) / 1000);
    }
}