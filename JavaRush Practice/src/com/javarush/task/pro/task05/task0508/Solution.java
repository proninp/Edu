package com.javarush.task.pro.task05.task0508;

import java.util.Arrays;
import java.util.Scanner;

/* 
Удаляем одинаковые строки
*/

public class Solution {
    public static String[] strings;

    public static void main(String[] args) {
        strings = new String[6];
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < strings.length; i++) {
            strings[i] = scanner.nextLine();
        }
        scanner.close();

        for (int i = 0; i < strings.length - 1; i++) {
            boolean isDuplicate = false;
            for (int j = i + 1; j < strings.length && strings[i] != null; j++) {
                if (strings[j] != null && strings[j].equals(strings[i])) {
                    strings[j] = null;
                    isDuplicate = true;
                }
            }
            if (isDuplicate)
                strings[i] = null;
        }

        for (int i = 0; i < strings.length; i++) {
            System.out.print(strings[i] + ", ");
        }
    }
}
