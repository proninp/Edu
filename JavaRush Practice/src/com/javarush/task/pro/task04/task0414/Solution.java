package com.javarush.task.pro.task04.task0414;

import java.util.Scanner;

/* 
Хорошего не бывает много
*/

public class Solution {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String s = scanner.nextLine();
        int a = scanner.nextInt();
        do {
            System.out.println(s);
            a--;
        } while (a > 0 && a < 4);

    }
}