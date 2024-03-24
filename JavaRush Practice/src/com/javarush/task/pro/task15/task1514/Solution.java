package com.javarush.task.pro.task15.task1514;

import java.nio.file.Path;
import java.util.Scanner;

/* 
Все относительно
*/

public class Solution {
    public static void main(String[] args) {
        try(Scanner scanner = new Scanner(System.in)) {
            Path relativePath = Path.of(scanner.nextLine()).relativize(Path.of(scanner.nextLine()));
            System.out.println(relativePath);
        } catch (Exception e) {

        }
    }
}

