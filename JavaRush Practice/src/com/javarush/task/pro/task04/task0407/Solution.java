package com.javarush.task.pro.task04.task0407;

/* 
Сумма чисел, не кратных 3
*/

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        int i = 0;
        while (i++ < 100) {
            if (i % 3 == 0)
                continue;
            sum += i;
        }
        scanner.close();
        System.out.println(sum);
    }
}