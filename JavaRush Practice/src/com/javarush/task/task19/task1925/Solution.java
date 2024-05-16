package com.javarush.task.task19.task1925;

import java.io.*;
import java.util.ArrayList;

/* 
Длинные слова
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader reader = new BufferedReader(new FileReader(args[0]));
            BufferedWriter writer = new BufferedWriter(new FileWriter(args[1]))) {
            StringBuilder sb = new StringBuilder();
            while (reader.ready()) {
                String[] words = reader.readLine().split(" ");
                for (String word : words) {
                    if (word.length() > 6)
                        sb.append(word).append(",");
                }
            }
            if (sb.length() > 0) {
                writer.write(sb.substring(0, sb.length() - 1));
            }
            
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
