package com.javarush.task.task19.task1927;

import java.io.*;

/* 
Контекстная реклама
*/

public class Solution {
    public static TestString testString = new TestString();

    public static void main(String[] args) {
        PrintStream console = System.out;
        ByteArrayOutputStream oStream = new ByteArrayOutputStream();
        PrintStream stream = new PrintStream(oStream);
        System.setOut(stream);
        testString.printSomething();

        StringBuilder sb = new StringBuilder();
        int i = 0;
        try (ByteArrayInputStream inputStream = new ByteArrayInputStream(oStream.toByteArray());
             BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream))) {
            while (reader.ready()) {
                sb.append(reader.readLine()).append("\n");
                if (++i % 2 == 0) {
                    sb.append("JavaRush - курсы Java онлайн").append("\n");
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        System.setOut(console);
        System.out.println(sb.toString().trim());
    }

    public static class TestString {
        public void printSomething() {
            System.out.println("first");
            System.out.println("second");
            System.out.println("third");
            System.out.println("fourth");
            System.out.println("fifth");
        }
    }
}
