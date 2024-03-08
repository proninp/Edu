package com.javarush.task.pro.task05.task0505;

import java.util.Scanner;

/* 
Reverse
*/

public class Solution {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        if (n <= 0)
            return;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) {
            arr[i] = scanner.nextInt();
        }
        scanner.close();

        if (n % 2 != 0) {
            for (int i = 0; i < n; i++) {
                System.out.println(arr[i]);
            }
        } else {
            for (int i = arr.length - 1; i >= 0 ; i--) {
                System.out.println(arr[i]);
            }
        }
    }
}
