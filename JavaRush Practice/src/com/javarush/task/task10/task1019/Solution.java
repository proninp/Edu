package com.javarush.task.task10.task1019;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

/* 
Функциональности маловато!
*/

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        HashMap<String, Integer> map = new HashMap<>();
        
        while (true) {
            String numberText = reader.readLine();
            if (numberText.isEmpty())
                break;
            map.put(reader.readLine(), Integer.parseInt(numberText));
        }

        for(Map.Entry<String, Integer> e : map.entrySet())
            System.out.println(e.getValue() + " " + e.getKey());
    }
}
