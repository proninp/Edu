package com.javarush.task.task18.task1825;

import java.io.*;
import java.util.*;
import java.util.stream.Collectors;

/* 
Собираем файл
*/

public class Solution {
    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            String line;
            String destinationFilename = "";
            boolean isFirst = true;
            Map<Integer, String> map = new TreeMap<>();
            while(!"end".equals(line = reader.readLine())) {
                String[] array = line.split(".part");
                destinationFilename = array[0];
                map.put(Integer.parseInt(array[1]), line);
            }
            try(BufferedOutputStream bos = new BufferedOutputStream(new FileOutputStream(destinationFilename))) {
                for (String fileSource : map.values()) {
                    BufferedInputStream bis = new BufferedInputStream(new FileInputStream(fileSource));
                    while(bis.available() > 0) {
                        bos.write(bis.read());
                    }
                    bis.close();
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
