package com.javarush.task.pro.task15.task1515;

import java.nio.file.Path;
import java.util.Scanner;

/* 
Абсолютный путь
*/

public class Solution {
    public static void main(String[] args) {
        try(Scanner scanner = new Scanner(System.in)) {
            String str = scanner.nextLine();
            Path p = Path.of(str);
            if (!p.isAbsolute())
                p = p.toAbsolutePath();
            System.out.println(p);
        }


    }
}

