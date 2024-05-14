package com.javarush.task.task19.task1923;

import java.io.*;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/* 
Слова с цифрами
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader fileReader = new BufferedReader(new FileReader(args[0]));
            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(args[1]))) {

            while(fileReader.ready()) {
                String[] words = fileReader.readLine().split(" ");
                for (String word : words)
                    if(!word.equals(word.replaceAll("[\\d]", "")))
                        fileWriter.write(word + " ");
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
