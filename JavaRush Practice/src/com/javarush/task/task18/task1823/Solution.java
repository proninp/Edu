package com.javarush.task.task18.task1823;

import java.io.*;
import java.util.HashMap;
import java.util.Map;

/* 
Нити и байты
*/

public class Solution {
    public static Map<String, Integer> resultMap = new HashMap<String, Integer>();

    public static void main(String[] args) {
        try(BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
            String s;
            while(!(s = br.readLine()).equals("exit")) {
                new ReadThread(s).start();
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static class ReadThread extends Thread {
        private final String fileName;
        public ReadThread(String fileName) {
            this.fileName = fileName;
        }

        @Override
        public void run() {
            try(BufferedInputStream bf = new BufferedInputStream(new FileInputStream(fileName))) {
                Map<Integer, Integer> map = new HashMap<>();
                while (bf.available() > 0) {
                    int c = bf.read();
                    map.put(c, map.getOrDefault(c, 0) + 1);
                }
                int maxFrequency = 0;
                int seekByte = 0;
                for (Map.Entry<Integer, Integer> e: map.entrySet()) {
                    if (e.getValue() > maxFrequency) {
                        maxFrequency = e.getValue();
                        seekByte = e.getKey();
                    } else if (e.getValue() == maxFrequency) {
                        if (seekByte > e.getKey()) {
                            seekByte = e.getKey();
                        }
                    }
                }
                resultMap.put(fileName, seekByte);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }
}
