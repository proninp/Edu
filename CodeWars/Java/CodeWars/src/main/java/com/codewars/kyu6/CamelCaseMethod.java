/*
 * Write simple .camelCase method (camel_case function in PHP, CamelCase in C# or camelCase in Java)
 * for strings. All words must have their first letter capitalized without spaces.
 */

package main.java.com.codewars.kyu6;

import java.util.Arrays;

import static java.util.stream.Collectors.joining;

public class CamelCaseMethod {
    public static String camelCase(String str) {
        if (str.isEmpty())
            return str;
        String[] strArr = str.trim().replaceAll("\\s+", " ").split(" ");
        for (int i = 0; i < strArr.length; i++) {
            if (!strArr[i].isEmpty())
                strArr[i] = strArr[i].substring(0, 1).toUpperCase() + strArr[i].substring(1);
        }
        return String.join("", strArr);
    }
    public static String camelCase2(final String string) {

        return Arrays.stream(string.split("\\s+"))
                .filter(s -> !s.isEmpty())
                .map(s -> Character.toUpperCase(s.charAt(0)) + s.substring(1).toLowerCase())
                .collect(joining());
    }
}
