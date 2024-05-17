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
        StringBuilder lineSb = new StringBuilder();

        try(BufferedReader console = new BufferedReader(new InputStreamReader(System.in));
            BufferedReader reader = new BufferedReader(new FileReader(console.readLine()))) {

            while (reader.ready()) {
                String line = reader.readLine();
                String[] words = line.split(" ");
                for (String word: words) {
                    char lastSymbol = word.charAt(word.length() - 1);
                    if (!Character.isLetterOrDigit(lastSymbol)) {
                        String chunk = word.substring(0, word.length() - 1);
                        tryAppendNumber(lineSb, chunk);
                        lineSb.append(lastSymbol);
                    } else {
                        tryAppendNumber(lineSb, word);
                    }
                    lineSb.append(" ");
                }
                System.out.println(lineSb.toString().trim());
                lineSb.setLength(0);
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public static void tryAppendNumber(StringBuilder resultSb, String chunk) {
        try {
            int number = Integer.parseInt(chunk);
            if (map.containsKey(number)) {
                resultSb.append(map.get(number));
            } else {
                resultSb.append(number);
            }
        } catch (NumberFormatException e) {
            resultSb.append(chunk);
        }
    }
}
