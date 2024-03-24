package com.javarush.task.pro.task15.task1516;

import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Scanner;

/* 
Файл или директория
*/

public class Solution {
    private static final String THIS_IS_FILE = " - это файл";
    private static final String THIS_IS_DIR = " - это директория";

    public static void main(String[] args) {
        try(Scanner scanner = new Scanner(System.in)) {
            while (true) {
                String s = scanner.nextLine();
                if (s == null)
                    return;
                Path p = Path.of(s);
                if (Files.isDirectory(p))
                    System.out.println(p + THIS_IS_DIR);
                else if (Files.isRegularFile(p)) {
                    System.out.println(p + THIS_IS_FILE);
                } else
                    return;
            }
        }
    }
}

