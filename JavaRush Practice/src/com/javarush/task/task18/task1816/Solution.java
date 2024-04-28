package com.javarush.task.task18.task1816;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

/* 
Английские буквы
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader bufferedReader = new BufferedReader(new FileReader(args[0]))) {
            int cnt = 0;
            while(bufferedReader.ready()) {
                if (String.valueOf((char)bufferedReader.read()).matches("\\w"))
                    cnt++;
            }
            System.out.println(cnt);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
