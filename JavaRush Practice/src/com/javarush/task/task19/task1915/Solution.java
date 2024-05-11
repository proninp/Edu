package com.javarush.task.task19.task1915;

import java.io.*;

/* 
Дублируем текст
*/

public class Solution {
    public static TestString testString = new TestString();

    public static void main(String[] args) {
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            BufferedOutputStream fos = new BufferedOutputStream(new FileOutputStream(reader.readLine()))) {

            PrintStream console = System.out;
            ByteArrayOutputStream oStream = new ByteArrayOutputStream();
            PrintStream stream = new PrintStream(oStream);
            System.setOut(stream);
            testString.printSomething();
            System.setOut(console);

            System.out.println(oStream);
            fos.write(oStream.toByteArray());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static class TestString {
        public void printSomething() {
            System.out.println("it's a text for testing");
        }
    }
}

