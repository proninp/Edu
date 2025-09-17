/*
 * strarr = ["tree", "foling", "trashy", "blue", "abcdef", "uvwxyz"], k = 2
 * Concatenate the consecutive strings of strarr by 2, we get:
 * treefoling   (length 10)  concatenation of strarr[0] and strarr[1]
 * folingtrashy ("      12)  concatenation of strarr[1] and strarr[2]
 * trashyblue   ("      10)  concatenation of strarr[2] and strarr[3]
 * blueabcdef   ("      10)  concatenation of strarr[3] and strarr[4]
 * abcdefuvwxyz ("      12)  concatenation of strarr[4] and strarr[5]
 *
 * Two strings are the longest: "folingtrashy" and "abcdefuvwxyz".
 * The first that came is "folingtrashy" so
 * longest_consec(strarr, 2) should return "folingtrashy".
 *
 * In the same way:
 * longest_consec(["zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail"], 2) --> "abigailtheta"
 */

package main.java.com.codewars.kyu6;

public class ConsecutiveStrings {
    public static String longestConsec(String[] strarr, int k) {
        int len = strarr.length;
        int max = Integer.MIN_VALUE;
        String longest = "";
        if (k > len || k <= 0)
            return "";
        for (int i = 0; i <= len - k; i++) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.append(strarr[i]);
            for (int j = 1; j < k; j++) {
                stringBuilder.append(strarr[i + j]);
            }
            if (stringBuilder.length() > max) {
                longest = stringBuilder.toString();
                max = stringBuilder.length();
            }
        }
        return longest;
    }
}
