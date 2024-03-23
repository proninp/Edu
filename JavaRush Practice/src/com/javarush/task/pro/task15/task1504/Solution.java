package com.javarush.task.pro.task15.task1504;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

/* 
Перепутанные байты
*/

public class Solution {
    public static void main(String[] args) {
        try(Scanner scanner = new Scanner(System.in);
            InputStream inputStream = Files.newInputStream(Path.of(scanner.nextLine()));
            OutputStream outputStream = Files.newOutputStream(Path.of(scanner.nextLine()))) {
            byte[] file1Bytes = inputStream.readAllBytes();

            for (int i = 1; i < file1Bytes.length; i += 2) {
                outputStream.write(file1Bytes[i]);
                outputStream.write(file1Bytes[i - 1]);
            }
            if (file1Bytes.length %2 != 0)
                outputStream.write(file1Bytes[file1Bytes.length - 1]);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}

