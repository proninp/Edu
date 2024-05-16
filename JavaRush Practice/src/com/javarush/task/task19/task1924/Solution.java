package com.javarush.task.task19.task1924;

import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/* 
Замена чисел
*/

public class Solution {
    public static Map<Integer, String> map = new HashMap<Integer, String>();

    static {
        map.put(0, "ноль");
        map.put(1, "один");
        map.put(2, "два");
        map.put(3, "три");
        map.put(4, "четыре");
        map.put(5, "пять");
        map.put(6, "шесть");
        map.put(7, "семь");
        map.put(8, "восемь");
        map.put(9, "девять");
        map.put(10, "десять");
        map.put(11, "одиннадцать");
        map.put(12, "двенадцать");
    }

    public static void main(String[] args) {
        StringBuilder result = new StringBuilder();
        StringBuilder numberSb = new StringBuilder();
        String s = "Это стоит 1 бакс, а вот это - 12.";
        for (char symbol : s.toCharArray()) {
            if (Character.isDigit(symbol)) {
                numberSb.append(symbol);
            } else {
                if (numberSb.length() != 0) {
                    appendNumber(result, numberSb);
                }
                result.append(symbol);
            }
        }
        System.out.println(result);


//        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
//            BufferedReader fileReader = new BufferedReader(new FileReader(reader.readLine()))) {
//
//            while (fileReader.ready()) {
//                char c = (char)fileReader.read();
//                if (Character.isDigit(c) && map.containsKey(((int)c))) {
//                    result.append(map.get((int)c));
//                } else {
//                    result.append(c);
//                }
//            }
//            System.out.println(result);
//        } catch (IOException e) {
//            throw new RuntimeException(e);
//        }
    }
    public static void appendNumber(StringBuilder result, StringBuilder numberSb) {
        try {
            int number = Integer.parseInt(numberSb.toString());
            if (map.containsKey(number)) {
                result.append(map.get(number));
            } else {
                result.append(number);
            }
        } catch (NumberFormatException e) {
            result.append(numberSb);
        }
        numberSb.setLength(0);
    }
}
