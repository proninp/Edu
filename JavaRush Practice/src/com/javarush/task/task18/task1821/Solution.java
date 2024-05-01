package com.javarush.task.task18.task1821;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.TreeMap;

/* 
Встречаемость символов
*/

public class Solution {
    public static void main(String[] args) {
        Map<Character, Integer> map = new TreeMap<>();

        try(BufferedReader br = new BufferedReader(new FileReader(args[0]))) {
            while(br.ready()) {
                char c = (char) br.read();
                map.put(c, map.getOrDefault(c, 0) + 1);
            }
            map.forEach((k, v) -> System.out.println(k + " " + v));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
