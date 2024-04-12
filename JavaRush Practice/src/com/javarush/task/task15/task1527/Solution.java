package com.javarush.task.task15.task1527;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

/* 
Парсер реквестов
*/

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String url = reader.readLine();
        url = url.substring(url.indexOf("?") + 1);
        String[] split = url.split("&");

        StringBuilder sb = new StringBuilder();
        List<String> alerts = new ArrayList<>();

        String param;
        for (String e : split) {
            param = e;
            if (e.contains("=")) {
                String[] kvp = e.split("=");
                param = kvp[0];
                if (param.equals("obj")) {
                    alerts.add(kvp[1]);
                }
            }
            if (sb.length() > 0)
                sb.append(" ");
            sb.append(param);
        }
        System.out.println(sb);

        for (String al : alerts) {
            try {
                alert(Double.parseDouble(al));
            } catch (NumberFormatException ignored) {
                alert(al);
            }
        }
    }

    public static void alert(double value) {
        System.out.println("double: " + value);
    }

    public static void alert(String value) {
        System.out.println("String: " + value);
    }
}
