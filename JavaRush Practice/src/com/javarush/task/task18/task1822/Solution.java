package com.javarush.task.task18.task1822;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;

/* 
Поиск данных внутри файла
*/

public class Solution {
    public static void main(String[] args) {
        String seekId = args[0];
        try(BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = br.readLine();
            try(BufferedReader bf = new BufferedReader(new FileReader(filename))) {
                while (bf.ready()) {
                    String s = bf.readLine();
                    String[] parts = s.split(" ");
                    if (parts[0].equals(seekId)) {
                        System.out.println(s);
                    }
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
