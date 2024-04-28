package com.javarush.task.task18.task1809;

import java.io.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/* 
Реверс файла
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader console = new BufferedReader(new InputStreamReader(System.in))) {
            String file1 = console.readLine();
            String file2 = console.readLine();

            try(FileInputStream fi = new FileInputStream(file1);
                FileOutputStream fo = new FileOutputStream(file2)) {
                byte[] b = new byte[fi.available()];
                fi.read(b);
                for (int i = b.length - 1; i >= 0; i--) {
                    fo.write(b[i]);
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
