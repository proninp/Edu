package com.javarush.task.task19.task1920;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Map;
import java.util.TreeMap;
import java.util.TreeSet;
import java.util.stream.Collectors;

/* 
Самый богатый
*/

public class Solution {
    public static void main(String[] args) {
        TreeMap<String, Double> map = new TreeMap<>();
        double max = 0.0;
        try(BufferedReader fileReader = new BufferedReader(new FileReader(args[0]))) {
            while (fileReader.ready()) {
                String[] array = fileReader.readLine().split(" ");
                map.put(array[0], map.getOrDefault(array[0], 0.0) + Double.parseDouble(array[1]));
                max = Math.max(max, map.get(array[0]));
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        final double maxValue = max;
        map.forEach((k, v) -> {
            if (v == maxValue)
                System.out.println(k);
        });
    }
}
