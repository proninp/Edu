package com.javarush.task.task13.task1326;

import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/* 
Сортировка четных чисел из файла
*/

public class Solution {
    public static void main(String[] args) {
        List<Integer> list = new ArrayList<>();

        try(Scanner scanner = new Scanner(System.in);
            FileInputStream fs = new FileInputStream(scanner.nextLine());
            BufferedReader bf = new BufferedReader(new InputStreamReader(fs))) {
            while (bf.ready()) {
                list.add(Integer.parseInt(bf.readLine()));
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        list.stream()
                .filter(x -> x % 2 == 0)
                .sorted()
                .forEach(System.out::println);
    }
}
