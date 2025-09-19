package main.java.com.codewars.kyu6.consecutiveStrings;

// https://www.codewars.com/kata/56a5d994ac971f1ac500003e/
public class ConsecutiveStrings {
    public static String longestConsec(String[] strarr, int k) {
        var result = "";
        for (int i = 0; i < strarr.length - k + 1; i++) {
            var sb = new StringBuilder();
            for (int j = i; j < i + k; j++) {
                sb.append(strarr[j]);
            }
            if (result.length() < sb.length()) {
                result = sb.toString();
            }
        }
        return result;
    }
}
