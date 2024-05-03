package com.javarush.task.task18.task1803;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.util.*;
import java.util.stream.IntStream;

/* 
Самые частые байты
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        int[] frequency = new int[256];
        int maxFreq = 0;
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try(FileInputStream fileReader = new FileInputStream(filename)) {
                while(fileReader.available() > 0) {
                    int b = fileReader.read();
                    frequency[b]++;
                    maxFreq = Math.max(maxFreq, frequency[b]);
                }
            }
        }
        final int target = maxFreq;
        IntStream.range(0, frequency.length)
                .filter(i -> frequency[i] == target)
                .forEach(i -> System.out.printf("%d ", i));

    }
}
