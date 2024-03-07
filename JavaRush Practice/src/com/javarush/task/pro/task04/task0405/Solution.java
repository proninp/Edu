package com.javarush.task.pro.task04.task0405;

/* 
Незаполненный прямоугольник
*/

public class Solution {
    public static void main(String[] args) {
        int rows = 10;
        int cols = 20;
        int i = 0;
        while (i++ < rows) {
            int j = 0;
            while (j++ < cols) {
                if (i == 1 || i == rows || j == 1 || j == cols)
                    System.out.print("Б");
                else
                    System.out.print(" ");
            }
            System.out.println();
        }

    }
}