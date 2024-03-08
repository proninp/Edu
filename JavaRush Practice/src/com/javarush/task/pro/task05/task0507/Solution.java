package com.javarush.task.pro.task05.task0507;

import java.util.Scanner;

/* 
Максимальное из N чисел
*/

public class Solution {
    public static int[] array;

    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        int N = scanner.nextInt();
        array = new int[N];
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < N; i++) {
            array[i] = scanner.nextInt();
            if (array[i] > max)
                max = array[i];
        }
        scanner.close();
        System.out.println(max);
    }
}
