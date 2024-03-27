package com.javarush.task.task15.task1527;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

/* 
Requests parser
*/

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String url = reader.readLine();
        String uri = url.substring(url.indexOf("?") + 1);
        String[] params = uri.split("&");
        StringBuilder sb = new StringBuilder();
        List<String> objList = new ArrayList<>();
        String paramName;
        for(String param : params) {
            paramName = param;
            if (param.contains("=")) {
                paramName = param.substring(0, param.indexOf("="));
                if (paramName.equals("obj"))
                    objList.add(param.substring(param.indexOf("=") + 1));
            }
            if (sb.length() > 0)
                sb.append(" ");
            sb.append(paramName);
        }
        System.out.println(sb);
        for(String s : objList) {
            Double d = null;
            try {
                alert(Double.parseDouble(s));
            } catch (NumberFormatException ignored) {
                alert(s);
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
