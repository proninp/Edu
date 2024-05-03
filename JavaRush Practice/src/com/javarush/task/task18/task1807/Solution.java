package com.javarush.task.task18.task1807;

import java.io.*;
import java.nio.charset.Charset;

/* 
Подсчет запятых
*/

public class Solution {
    public static void main(String[] args) {
        int output = 0;
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String filename = reader.readLine();
            try (FileInputStream fileInputStream = new FileInputStream(filename)) {
                while (fileInputStream.available() > 0) {
                  if (fileInputStream.read() == ',')
                      output++;
                }
                System.out.println(output);
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }
}
