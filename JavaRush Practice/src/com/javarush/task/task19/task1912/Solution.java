package com.javarush.task.task19.task1912;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

/* 
Ридер обертка 2
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
        System.out.println(oStream.toString().replace("te", "??"));
    }

    public static class TestString {
        public void printSomething() {
            System.out.println("it's a text for testing");
        }
    }
}
