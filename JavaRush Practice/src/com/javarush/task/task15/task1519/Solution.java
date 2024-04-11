package com.javarush.task.task15.task1519;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/* 
Разные методы для разных типов
*/

public class Solution {
    public static void main(String[] args) throws IOException {
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String data;
            while (!(data = reader.readLine()).equals("exit")) {
                try {
                    if (data.contains(".")) {
                        Double d = Double.parseDouble(data);
                        print(d);
                    } else {
                        int a = Integer.parseInt(data);
                        if (a > 0 && a < 128) {
                            print((short) a);
                        } else {
                            print(a);
                        }
                    }
                } catch (NumberFormatException e) {
                    print(data);
                }
            }
        }
    }

    public static void print(Double value) {
        System.out.println("Это тип Double, значение " + value);
    }

    public static void print(String value) {
        System.out.println("Это тип String, значение " + value);
    }

    public static void print(short value) {
        System.out.println("Это тип short, значение " + value);
    }

    public static void print(Integer value) {
        System.out.println("Это тип Integer, значение " + value);
    }
}
