package com.javarush.task.task19.task1914;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

/* 
Решаем пример
*/

public class Solution {
    public static TestString testString = new TestString();

    public static void main(String[] args) {
        PrintStream console = System.out;
        ByteArrayOutputStream oStream = new ByteArrayOutputStream();
        PrintStream stream = new PrintStream(oStream);
        System.setOut(stream);
        testString.printSomething();
        System.setOut(console);
        String s = oStream.toString();
        String[] parts = s.split(" ");
        int a = Integer.parseInt(parts[0]);
        int b = Integer.parseInt(parts[2]);
        int c = parts[1].equals("+") ? a + b : parts[1].equals("-") ? a - b : a * b;
        System.out.println(s.trim() + " " + c);
    }

    public static class TestString {
        public void printSomething() {
            System.out.println("3 + 6 = ");
        }
    }
}

