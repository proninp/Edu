package com.codewars.kyu7;

public class CircleCipher {
    public static String encode(String s) {
        int len = s.length();
        StringBuilder stringBuilder = new StringBuilder(len);
        int i = 0;
        for (; i < len / 2; i++) {
            stringBuilder.append(s.charAt(i)).append(s.charAt(len - 1 - i));
        }
        if (len % 2 != 0)
            stringBuilder.append(s.charAt(i));
        return stringBuilder.toString();
    }
    public static String decode(String s) {
        int len = s.length();
        StringBuilder stringBuilder = new StringBuilder(len);
        int i = 0;
        for (; i < len; i += 2) {
            stringBuilder.append(s.charAt(i));
        }
        if (len % 2 != 0)
            i = len - 1;
        for (i -= 1; i > 0; i -= 2) {
            stringBuilder.append(s.charAt(i));
        }
        return stringBuilder.toString();
    }
}
