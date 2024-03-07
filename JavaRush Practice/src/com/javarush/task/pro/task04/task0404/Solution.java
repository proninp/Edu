package com.javarush.task.pro.task04.task0404;

/* 
Заполненный прямоугольник
*/

public class Solution {
    public static void main(String[] args) {
        int rows = 5;
        int cols = 10;
        int i = 0;
        while (i++ < rows) {
            int j = 0;
            while (j++ < cols) {
                System.out.print("Q");
            }
            System.out.println();
        }

    }
}