package com.javarush.task.task18.task1817;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/* 
Пробелы
*/

public class Solution {

    public static void main(String[] args) {
        try(BufferedReader br = new BufferedReader(new FileReader(args[0]))) {
            int wsCnt = 0;
            int totalCnt = 0;
            while (br.ready()) {
                totalCnt++;
                if (Character.isWhitespace((char) br.read()))
                    wsCnt++;
            }
            System.out.printf("%.2f%n", 100.0 * wsCnt / totalCnt);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
