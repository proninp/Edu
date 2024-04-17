package com.javarush.task.task16.task1629;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/* 
Только по-очереди!
*/

public class Solution {
    public static volatile BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static void main(String[] args) throws InterruptedException {
        Read3Strings t1 = new Read3Strings();
        Read3Strings t2 = new Read3Strings();

        t1.start();
        t2.start();

        t1.join();
        t2.join();

        t1.printResult();
        t2.printResult();
    }

    public static class Read3Strings extends Thread {
        StringBuffer buffer = new StringBuffer();
        @Override
        public void run() {

            try {
                buffer.append(reader.readLine());
                buffer.append(" ");
                buffer.append(reader.readLine());
                buffer.append(" ");
                buffer.append(reader.readLine());
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
        public void printResult() {
            System.out.println(buffer);
        }
    }
}
