package com.javarush.task.task18.task1826;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

/* 
Шифровка
*/

public class Solution {
    public static void main(String[] args) {
        int salt = 321;
        String filename = args[1];
        String fileOutputName = args[2];
        try(FileInputStream fis = new FileInputStream(filename);
            FileOutputStream fos = new FileOutputStream(fileOutputName)) {
            while(fis.available() > 0) {
                fos.write(fis.read() ^ salt);
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
