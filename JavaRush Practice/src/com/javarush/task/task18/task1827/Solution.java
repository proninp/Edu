package com.javarush.task.task18.task1827;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

/* 
Прайсы
*/

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String filename = reader.readLine();
        reader.close();

        if (args == null || args.length != 4 || !"-c".equals(args[0]))
            return;

        String productName = args[1];
        String price = args[2];
        String quantity = args[3];

        int maxId = 0;

        try(BufferedReader bfr = new BufferedReader(new FileReader(filename))) {
            while (bfr.ready()) {
                String line = bfr.readLine();
                int id = Integer.parseInt(line.substring(0, 8).trim());
                maxId = Math.max(maxId, id);
            }
        }

        try(BufferedWriter bfw = new BufferedWriter(new FileWriter(filename, true))) {
            bfw.write(String.format("\n%-8s%-30s%-8s%-4s", ++maxId, productName, price, quantity));
        }
    }
}
