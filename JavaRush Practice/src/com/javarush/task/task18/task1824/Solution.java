package com.javarush.task.task18.task1824;

import java.io.*;

/* 
Файлы и исключения
*/

public class Solution {
    public static void main(String[] args) {
        try(BufferedReader bf = new BufferedReader(new InputStreamReader(System.in))) {
            boolean isRead = true;
            while(bf.ready() && isRead) {
                String filename = bf.readLine();
                try(FileInputStream fis = new FileInputStream(filename)) {

                } catch (FileNotFoundException e) {
                    System.out.println(filename);
                    isRead = false;
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
