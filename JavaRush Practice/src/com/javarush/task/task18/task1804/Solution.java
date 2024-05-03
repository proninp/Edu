package com.javarush.task.task18.task1804;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.IntStream;

/* 
Самые редкие байты
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        int[] frequency = new int[256];
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try(FileInputStream fileReader = new FileInputStream(filename)) {
                while(fileReader.available() > 0) {
                    frequency[fileReader.read()]++;
                }
            }
        }
        final int target = Arrays.stream(frequency)
                .filter(v -> v != 0)
                .min()
                .orElse(0);
        IntStream.range(0, frequency.length)
                .filter(i -> frequency[i] == target)
                .forEach(i -> System.out.printf("%d ", i));
    }
}
