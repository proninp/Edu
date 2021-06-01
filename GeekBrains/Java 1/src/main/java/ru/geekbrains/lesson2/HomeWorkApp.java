package ru.geekbrains.lesson2;

public class HomeWorkApp {
    public static void main(String[] args) {
        System.out.println("Task 1:");
        System.out.println(String.valueOf(compareTwoNumbers(5, 7)).toUpperCase());
        System.out.println("\nTask2:");
        getSignNumberDescription(1);
        System.out.println("\nTask3:");
        System.out.println(String.valueOf(isNegative(-5)).toUpperCase());
        System.out.println("\nTask4:");
        printTextNTimes(5, "Hello!");
        System.out.println("\nTask5:");
        System.out.println(String.valueOf(isLeapYear(2021)).toUpperCase());
    }

    /**
     * Task 1
     *
     * @param a - first integer number
     * @param b - second integer number
     * @return - result
     */
    public static boolean compareTwoNumbers(int a, int b) {
        int sum = a + b;
        return sum >= 10 && sum <= 20;
    }

    /**
     * Task 2
     *
     * @param a - integer number
     */
    public static void getSignNumberDescription(int a) {
        if (a < 0) {
            System.out.println("Negative");
        } else {
            System.out.println("Positive");
        }
    }

    /**
     * Task 3
     *
     * @param a - integer number
     * @return boolean result
     */
    public static boolean isNegative(int a) {
        return a < 0;
    }

    /**
     * Task 4
     *
     * @param n    - how many times to print
     * @param text - string to print
     */
    public static void printTextNTimes(int n, String text) {
        for (int i = 0; i < n; i++) {
            System.out.println(text);
        }
    }

    /**
     * Task 5
     *
     * @param year - the number of year
     * @return - is leap year or not
     */
    public static boolean isLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0 && year > 0);
    }
}
