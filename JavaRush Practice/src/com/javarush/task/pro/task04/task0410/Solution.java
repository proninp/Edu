package com.javarush.task.pro.task04.task0410;

import java.util.Scanner;

/* 
Второе минимальное число из введенных
*/

public class Solution {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int min = Integer.MAX_VALUE;
        int nextMin = Integer.MAX_VALUE;
        while (scanner.hasNextInt()) {
            int i = scanner.nextInt();
            if (i < min) {
                nextMin = min;
                min = i;
            }
            if (i > min && i < nextMin)
                nextMin = i;
        }
        scanner.close();
        System.out.println(nextMin);
    }
}