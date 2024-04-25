package com.javarush.task.task18.task1805;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import java.util.TreeSet;
import java.util.stream.IntStream;

/* 
Сортировка байт
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        Set<Integer> set = new HashSet<>();
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try(FileInputStream fileReader = new FileInputStream(filename)) {
                while(fileReader.available() > 0) {
                    set.add(fileReader.read());
                }
            }
        }
        set.stream().sorted().forEach(v -> System.out.printf("%d ", v));
    }
}
