package com.javarush.task.task15.task1519;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/* 
Разные методы для разных типов
*/

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String input;
        while (!(input = reader.readLine()).equals("exit")) {
            if (input.contains(".")) {
                Double d = tryParseDouble(input);
                if (d != null) {
                    print(d);
                    continue;
                }
            }
            Integer i = tryParseInteger(input);
            if (i != null) {
                if (i > 0 && i < 128) {
                    print((short)(int)i);
                } else {
                   print(i);
                }
                continue;
            }
            print(input);
        }
        reader.close();
    }

    public static Double tryParseDouble(String s) {
        Double result = null;
        try {
            result = Double.parseDouble(s);
        } catch (NumberFormatException ignored) { }
        return result;
    }
    public static Integer tryParseInteger(String s) {
        Integer result = null;
        try {
            result = Integer.parseInt(s);
        } catch (NumberFormatException ignored) { }
        return result;
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
