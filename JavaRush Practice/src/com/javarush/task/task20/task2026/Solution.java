package com.javarush.task.task20.task2026;

/* 
Алгоритмы-прямоугольники
*/

public class Solution {
    public static void main(String[] args) {
        byte[][] a1 = new byte[][]{
                {1, 1, 0, 0},
                {1, 1, 0, 0},
                {1, 1, 0, 0},
                {1, 1, 0, 1}
        };
        byte[][] a2 = new byte[][]{
                {1, 0, 0, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {1, 0, 0, 1}
        };

        int count1 = getRectangleCount(a1);
        System.out.println("count = " + count1 + ". Должно быть 2");
        int count2 = getRectangleCount(a2);
        System.out.println("count = " + count2 + ". Должно быть 4");
    }

    public static int getRectangleCount(byte[][] a) {
        int count = 0;
        int len = a.length;
        boolean[][] visited = new boolean[len][len];

        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len; j++) {
                if (!visited[i][j] && a[i][j] == 1) {
                    checkRectangle(a, visited, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    public static void checkRectangle(byte[][] a, boolean[][] visited, int i, int j) {
        if (i >= a.length || j >= a.length)
            return;
        if (a[i][j] == 0)
            return;
        visited[i][j] = true;
        checkRectangle(a, visited, i + 1, j);
        checkRectangle(a, visited, i, j + 1);
    }
}
