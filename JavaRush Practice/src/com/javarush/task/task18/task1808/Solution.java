package com.javarush.task.task18.task1808;

import java.io.*;

/* 
Разделение файла
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader console = new BufferedReader(new InputStreamReader(System.in))) {
            String file1 = console.readLine();
            String file2 = console.readLine();
            String file3 = console.readLine();

            try(FileInputStream fi = new FileInputStream(file1);
                FileOutputStream fo1 = new FileOutputStream(file2);
                FileOutputStream fo2 = new FileOutputStream(file3)) {
                int len = fi.available();
                int f1Len = len % 2 == 0 ? len / 2 : len / 2 + 1;

                for (int i = 0; i < f1Len; i++) {
                    fo1.write(fi.read());
                }
                for (int i = f1Len; i < len; i++) {
                    fo2.write(fi.read());
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
