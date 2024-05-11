package com.javarush.task.task19.task1916;

import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

/* 
Отслеживаем изменения
*/

public class Solution {
    public static List<LineItem> lines = new ArrayList<LineItem>();

    public static void main(String[] args) {
        ArrayList<String> list1 = new ArrayList<>();
        ArrayList<String> list2 = new ArrayList<>();

        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            BufferedReader file1Reader = new BufferedReader(new FileReader(reader.readLine()));
            BufferedReader file2Reader = new BufferedReader(new FileReader(reader.readLine()))) {

            while(file1Reader.ready() && file2Reader.ready()) {
                list1.add(file1Reader.readLine());
                list2.add(file2Reader.readLine());
            }
            while (file1Reader.ready())
                list1.add(file1Reader.readLine());

            while (file2Reader.ready())
                list2.add(file2Reader.readLine());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        int i = 0, j = 0;
        while (i < list1.size() && j < list2.size()) {
            if (list1.get(i).equals(list2.get(j))) {
                lines.add(new LineItem(Type.SAME, list1.get(i)));
                i++;
                j++;
            } else {
                if (i < list1.size() - 1 && j < list2.size() - 1) {
                    if (list1.get(i).equals(list2.get(j + 1))) {
                        lines.add(new LineItem(Type.ADDED, list2.get(j++)));
                    } else {
                        lines.add(new LineItem(Type.REMOVED, list1.get(i++)));
                    }
                } else {
                    if (i < list1.size() - 1) {
                        lines.add(new LineItem(Type.REMOVED, list1.get(i++)));
                    } else {
                        lines.add(new LineItem(Type.ADDED, list2.get(j++)));
                    }
                }
            }
        }
        while (i < list1.size()) {
            lines.add(new LineItem(Type.REMOVED, list1.get(i++)));
        }
        while (j < list2.size()) {
            lines.add(new LineItem(Type.ADDED, list2.get(j++)));
        }
    }


    public static enum Type {
        ADDED,        //добавлена новая строка
        REMOVED,      //удалена строка
        SAME          //без изменений
    }

    public static class LineItem {
        public Type type;
        public String line;

        public LineItem(Type type, String line) {
            this.type = type;
            this.line = line;
        }
    }
}
