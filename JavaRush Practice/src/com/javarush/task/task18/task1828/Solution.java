package com.javarush.task.task18.task1828;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

/* 
Прайсы 2
*/

public class Solution {
    public static void main(String[] args) {
        if (args == null || args.length < 2 || (!"-u".equals(args[0]) && !"-d".equals(args[0])))
            return;
        if ("-u".equals(args[0]) && args.length != 5)
            return;
        if ("-d".equals(args[0]) && args.length != 2)
            return;

        String filename = "";
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            filename = reader.readLine();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        List<String> lines = new ArrayList<>();
        int seekId = Integer.parseInt(args[1]);

        try(BufferedReader bfr = new BufferedReader(new FileReader(filename))) {
            while (bfr.ready()) {
                String line = bfr.readLine();
                int id = Integer.parseInt(line.substring(0, 8).trim());
                if (id == seekId) {
                    if ("-u".equals(args[0])) {
                        lines.add(String.format("%-8s%-30s%-8s%-4s", id, args[2], args[3], args[4]));
                    }
                } else {
                    lines.add(line);
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        try(BufferedWriter bfw = new BufferedWriter(new FileWriter(filename))) {
            for (int i = 0; i < lines.size(); i++) {
                if (i > 0) bfw.write("\n");
                bfw.write(lines.get(i));
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
