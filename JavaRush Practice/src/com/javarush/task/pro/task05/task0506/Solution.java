package com.javarush.task.pro.task05.task0506;

import java.util.Scanner;

/* 
Минимальное из N чисел
*/

public class Solution {
    public static int[] array;

    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        int N = scanner.nextInt();
        array = new int[N];
        int min = Integer.MAX_VALUE;
        for (int i = 0; i < N; i++) {
            array[i] = scanner.nextInt();
            if (min > array[i])
                min = array[i];
        }
        scanner.close();
        System.out.println(min);
    }
}
