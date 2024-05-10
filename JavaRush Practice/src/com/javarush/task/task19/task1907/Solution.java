package com.javarush.task.task19.task1907;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

/* 
Считаем слово
*/

public class Solution {
    public static void main(String[] args) {
        int result = 0;
        String target = "world";
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
             BufferedReader fileReader = new BufferedReader(new FileReader(reader.readLine()))) {
            while (fileReader.ready()) {
                for (String s : fileReader.readLine().split("\\W")) {
                    if (s.equals(target)) {
                        result++;
                    }
                }
            }
            System.out.println(result);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
