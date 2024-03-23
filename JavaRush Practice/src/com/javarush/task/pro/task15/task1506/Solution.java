package com.javarush.task.pro.task15.task1506;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import java.util.Scanner;
import java.util.List;

/* 
Фейсконтроль
*/

public class Solution {
    public static void main(String[] args) {
        try (Scanner scanner = new Scanner(System.in)) {
            List<String> strings =  Files.readAllLines(Path.of(scanner.nextLine()));
            for (String s : strings)
                System.out.println(s.replaceAll("[., ]", ""));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}

