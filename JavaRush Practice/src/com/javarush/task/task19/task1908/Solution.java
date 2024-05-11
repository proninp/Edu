package com.javarush.task.task19.task1908;

import java.io.*;
import java.util.ArrayList;

/* 
Выделяем числа
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            BufferedReader fileReader = new BufferedReader(new FileReader(reader.readLine()));
            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(reader.readLine()))) {

            while (fileReader.ready()) {
                String[] lineParts = fileReader.readLine().split(" ");
                for (String part: lineParts) {
                    if (part.chars().allMatch( Character::isDigit)) {
                        fileWriter.write(part + " ");
                    }
                }
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
