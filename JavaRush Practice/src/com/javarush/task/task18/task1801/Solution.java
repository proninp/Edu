package com.javarush.task.task18.task1801;

import java.io.*;

/* 
Максимальный байт
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        int maxByte = 0;
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try(FileInputStream fileReader = new FileInputStream(filename)) {
                while(fileReader.available() > 0) {
                    maxByte = Math.max(fileReader.read(), maxByte);
                }
            }
        }
        System.out.println(maxByte);
    }
}
