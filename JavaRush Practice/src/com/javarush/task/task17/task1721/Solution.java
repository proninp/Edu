package com.javarush.task.task17.task1721;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

/* 
Транзакционность
*/

public class Solution {
    public static List<String> allLines = new ArrayList<String>();
    public static List<String> forRemoveLines = new ArrayList<String>();

    public static void main(String[] args) {
        try(BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
            allLines = Files.readAllLines(Paths.get(br.readLine()));
            forRemoveLines = Files.readAllLines(Paths.get(br.readLine()));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        try {
            new Solution().joinData();
        } catch (CorruptedDataException e) {
            throw new RuntimeException(e);
        }
    }

    public void joinData() throws CorruptedDataException {
        if (allLines.containsAll(forRemoveLines)) {
            allLines.removeAll(forRemoveLines);
        } else {
            allLines.clear();
            throw new CorruptedDataException();
        }
    }
}
