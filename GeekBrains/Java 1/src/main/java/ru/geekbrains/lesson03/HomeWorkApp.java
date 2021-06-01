package ru.geekbrains.lesson03;

import java.util.Arrays;

public class HomeWorkApp {
    public static void main(String[] args) {
        task1(new int[]{1, 1, 0, 0, 1, 0, 1, 1, 0, 0});
        task2();
        task3(new int[]{1, 5, 3, 2, 11, 4, 5, 2, 4, 8, 9, 1});
        task4();
        printNewArray(task5(8, 5));
        task6(new int[]{11, 25, 43, -12, 11, 4, 52, -20, -5, 8, 6, -11});
        System.out.println(task7(new int[]{3, -1, 8, 1, 2, 3, -7, -5})); // [3, -1] == [8, 1, 2, 3, -7, -5]
        task8(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, 5);
    }

    /**
     * Task 1
     * Set an integer array consisting of elements 0 and 1.
     * For example: [ 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 ]. Use the loop and condition to replace 0 with 1, 1 with 0;
     *
     * @param array - your source arra
     */
    public static void task1(int[] array) {
        System.out.println("Task1:");
        printCurrentArray(array);
        for (int i = 0; i < array.length; i++) {
            array[i] = (array[i] == 1) ? 0 : (array[i] == 0) ? 1 : array[i];
        }
        printNewArray(array);
    }

    /**
     * Task 2
     * Set an empty integer array of length 100. Use a loop to fill it with values 1 2 3 4 5 6 7 8 ... 100;
     */
    public static void task2() {
        System.out.println("\nTask2:");
        int[] array = new int[100];
        for (int i = 0; i < array.length; i++) {
            array[i] = i + 1;
        }
        printNewArray(array);
    }

    /**
     * Task 3
     * Set an array [ 1, 5, 3, 2, 11, 4, 5, 2, 4, 8, 9, 1 ] go through it in a loop,
     * and multiply the numbers less than 6 by 2;
     *
     * @param array to process
     */
    public static void task3(int[] array) {
        System.out.println("\nTask3:");
        printCurrentArray(array);
        for (int i = 0; i < array.length; i++) {
            if (array[i] < 6) {
                array[i] *= 2;
            }
        }
        printNewArray(array);
    }

    /**
     * Task 4
     * Create a square two-dimensional integer array (the number of rows and columns is the same),
     * and use a loop (s) to fill its diagonal elements with units
     * (you can only use one of the diagonals, if both are difficult).
     * You can determine the elements of one of the diagonals according to the following principle:
     * the indices of such elements are equal, that is,[0][0], [1][1], [2][2], ..., [ n][n];
     */
    public static void task4() {
        System.out.println("\nTask4:");
        int arraySize = 12;
        int[][] array = new int[arraySize][arraySize];
        for (int i = 0; i < array.length; i++) {
            for (int j = 0; j < array[i].length; j++) {
                if ((i == j) || (i + j + 1 == arraySize)) {
                    array[i][j] = 1;
                }
            }
        }
        printNewArray(array);
    }

    /**
     * Task 5
     * Write a method that accepts two arguments as input: len and initialValue,
     * and returns a one-dimensional array of type int with length len,
     * each cell of which is equal to initialValue;
     *
     * @param len          - the length of array
     * @param initialValue - the value to init each element
     * @return - your array
     */
    public static int[] task5(int len, int initialValue) {
        System.out.println("\nTask5:");
        int[] array = new int[len];
        Arrays.fill(array, initialValue);
        return array;
    }

    /**
     * Task 6
     * Set a one-dimensional array and find the minimum and maximum elements in it
     *
     * @param array in which you need to find min and max
     */
    public static void task6(int[] array) {
        System.out.println("\nTask6:");
        printCurrentArray(array);
        int max = Integer.MIN_VALUE;
        int min = Integer.MAX_VALUE;
        for (int el : array) {
            if (el > max) {
                max = el;
            }
            if (el < min) {
                min = el;
            }
        }
        System.out.println("Minimum value of the array: " + min);
        System.out.println("Maximum value of the array: " + max);
    }

    /**
     * Task 7
     * Write a method that passes a non-empty one-dimensional integer array,
     * the method should return true if there is a place in the array where
     * the sum of the left and right parts of the array are equal.
     *
     * @param array to check balance
     * @return result of the check
     */
    public static boolean task7(int[] array) {
        System.out.println("\nTask7:");
        printCurrentArray(array);
        int leftSum = 0;
        for (int i = 0; i < array.length - 1; i++) {
            int rightSum = 0;
            leftSum += array[i];
            for (int j = i + 1; j < array.length; j++) {
                rightSum += array[j];
            }
            if (leftSum == rightSum) {
                return true;
            }
        }
        return false;
    }

    /**
     * Task 8
     *
     * @param array to rotate
     * @param n - rotation count (if n <0 then rotation will go left)
     */
    public static void task8(int[] array, int n) {
        System.out.println("\nTask8:");
        printCurrentArray(array);
        if (Math.abs(n) > array.length) {
            n %= array.length;
        }
        if (array.length == 0 || (n == 0)) {
            return;
        }
        int steps = (n < 0) ? array.length + n : n; // instead of left rotation
        for (int i = 0; i < steps; i++) {
            int replacesWith = array[0];
            for (int j = 0; j < array.length - 1; j++) {
                int replaced = array[j + 1];
                array[j + 1] = replacesWith;
                replacesWith = replaced;
            }
            array[0] = replacesWith; // replace first element with the last element
        }
        printNewArray(array);
    }

    /**
     * Additional method to print existing array
     *
     * @param array to print
     */
    public static void printCurrentArray(int[] array) {
        System.out.println("Your array:");
        System.out.println(Arrays.toString(array));
    }

    /**
     * Additional method to print new array
     *
     * @param array to print
     */
    public static void printNewArray(int[] array) {
        System.out.println("New array:");
        System.out.println(Arrays.toString(array));
    }

    /**
     * Additional method to print new two dimensional array
     *
     * @param array to print
     */
    public static void printNewArray(int[][] array) {
        System.out.println("New two dim array:");
        for (int i = 0; i < array.length; i++) {
            System.out.println(Arrays.toString(array[i]));
        }
    }
}