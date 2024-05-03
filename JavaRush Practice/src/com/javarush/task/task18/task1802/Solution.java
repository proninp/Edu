package com.javarush.task.task18.task1802;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;

/* 
Минимальный байт
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        int minByte = Integer.MAX_VALUE;
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try(FileInputStream fileReader = new FileInputStream(filename)) {
                while(fileReader.available() > 0) {
                    minByte = Math.min(fileReader.read(), minByte);
                }
            }
        }
        System.out.println(minByte);
    }
}
