package com.javarush.task.task18.task1819;

import java.io.*;

/* 
Объединение файлов
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
            String file1 = br.readLine();
            String file2 = br.readLine();

            try(BufferedInputStream bis1 = new BufferedInputStream(new FileInputStream(file1));
                BufferedInputStream bis2 = new BufferedInputStream(new FileInputStream(file2));) {

                byte[] array = new byte[bis1.available()];
                while (bis1.available() > 0) {
                    bis1.read(array);
                }
                try (BufferedOutputStream bos = new BufferedOutputStream(new FileOutputStream(file1))) {
                    while (bis2.available() > 0) {
                        bos.write(bis2.read());
                    }
                    bos.write(array);
                }
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
