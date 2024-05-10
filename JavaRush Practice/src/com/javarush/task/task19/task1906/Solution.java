package com.javarush.task.task19.task1906;

import java.io.*;
import java.util.ArrayList;

/* 
Четные символы
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            FileReader fileReader = new FileReader(reader.readLine());
            FileWriter fileWriter = new FileWriter(reader.readLine())) {

            int i = 1;
            while (fileReader.ready()) {
                int c = fileReader.read();
                if (i % 2 == 0) {
                    fileWriter.write(c);
                }
                i++;
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }
}
