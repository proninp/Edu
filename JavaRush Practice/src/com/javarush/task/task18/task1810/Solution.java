package com.javarush.task.task18.task1810;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;

/* 
DownloadException
*/

public class Solution {
    public static void main(String[] args) throws DownloadException {
        boolean isRead = true;
        try(BufferedReader console = new BufferedReader(new InputStreamReader(System.in))) {
            while (isRead) {
                try(FileInputStream fi = new FileInputStream(console.readLine())) {
                    if (fi.available() < 1000) {
                        isRead = false;
                    }
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        throw new DownloadException();
    }

    public static class DownloadException extends Exception {

    }
}
