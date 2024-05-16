package com.javarush.task.task19.task1926;

import java.io.*;

/* 
Перевертыши
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader console = new BufferedReader(new InputStreamReader(System.in));
            BufferedReader reader = new BufferedReader(new FileReader(console.readLine()))) {
            while (reader.ready()) {
                StringBuilder sb = new StringBuilder(reader.readLine());
                System.out.println(sb.reverse());
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
