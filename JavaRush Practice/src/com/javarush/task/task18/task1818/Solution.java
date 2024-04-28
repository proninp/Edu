package com.javarush.task.task18.task1818;

import java.io.*;

/* 
Два в одном
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader bf = new BufferedReader(new InputStreamReader(System.in))) {
            String file1 = bf.readLine();
            String file2 = bf.readLine();
            String file3 = bf.readLine();

            try(BufferedOutputStream bo = new BufferedOutputStream(new FileOutputStream(file1, true));
                BufferedInputStream br1 = new BufferedInputStream(new FileInputStream(file2));
                BufferedInputStream br2 = new BufferedInputStream(new FileInputStream(file3))) {
                while (br1.available() > 0) {
                    bo.write(br1.read());
                }
                while (br2.available() > 0) {
                    bo.write(br2.read());
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
