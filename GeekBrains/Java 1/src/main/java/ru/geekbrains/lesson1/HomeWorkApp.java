package ru.geekbrains.lesson1;

public class HomeWorkApp {
    public static void main(String[] args) {
        System.out.println("Task 2:");
        printThreeWords();
        System.out.println("\nTask 3:");
        checkSumSign();
        System.out.println("\nTask 4:");
        printColor();
        System.out.println("\nTask 5:");
        compareNumbers();
    }
    public static void  printThreeWords(){
        System.out.println("Orange");
        System.out.println("Banana");
        System.out.println("Apple");
    }
    public static void checkSumSign(){
        int a = 5;
        int b = -3;
        System.out.println("a = " + a + "; b = " + b);
        if (a + b >= 0) {
            System.out.println("The sum is positive.");
        } else {
            System.out.println("The sum is negative.");
        }
    }
    public static  void printColor(){
        int value = 120;
        System.out.println("value = " + value);
        if (value <= 0){
            System.out.println("Red");
        } else if (value > 0 && value <= 100) {
            System.out.println("Yellow");
        } else {
            System.out.println("Green");
        }
    }
    public static void compareNumbers(){
        int a = 10;
        int b = 5;
        System.out.println("a = " + a + "; b = " + b);
        if (a >= b){
            System.out.println("a >= b");
        } else {
            System.out.println("a < b");
        }
    }
}
