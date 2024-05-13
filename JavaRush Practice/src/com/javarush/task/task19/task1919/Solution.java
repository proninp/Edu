package com.javarush.task.task19.task1919;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.TreeMap;

/* 
Считаем зарплаты
*/

public class Solution {
    public static void main(String[] args) {
        TreeMap<String, Double> map = new TreeMap<>();
        try(BufferedReader fileReader = new BufferedReader(new FileReader(args[0]))) {
            while (fileReader.ready()) {
                String[] array = fileReader.readLine().split(" ");
                map.put(array[0], map.getOrDefault(array[0], 0.0) + Double.parseDouble(array[1]));
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        map.forEach((k, v) -> System.out.println(k + " " + v));
    }
}
