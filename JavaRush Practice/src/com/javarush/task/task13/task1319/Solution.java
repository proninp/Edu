package com.javarush.task.task13.task1319;

import java.io.*;
import java.util.Scanner;

/* 
Писатель в файл с консоли
*/

public class Solution {
    public static void main(String[] args) {
        String line;
        boolean isStop;
        try(Scanner scanner = new Scanner(System.in);
            BufferedWriter writer = new BufferedWriter(new FileWriter(scanner.nextLine()))) {
            do {
                line = scanner.nextLine();
                isStop = line.equals("exit");
                writer.write(line);
                if (!isStop)
                    writer.newLine();
            } while (!isStop);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
