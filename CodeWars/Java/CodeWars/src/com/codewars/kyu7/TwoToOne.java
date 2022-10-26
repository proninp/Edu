/*
 * Take 2 strings s1 and s2 including only letters from a to z.
 * Return a new sorted string, the longest possible,
 * containing distinct letters - each taken only once - coming from s1 or s2.
 */

package com.codewars.kyu7;

import java.util.ArrayList;
import java.util.Collections;
import java.util.stream.Collectors;

public class TwoToOne {
    public static String longest (String s1, String s2) {
        String s3 = s1 + s2;
        if (!s1.equals(s2))
            s3 += s2;
        ArrayList<Character> list = new ArrayList<>();
        for (int i = 0; i < s3.length(); i++) {
            char el = s3.charAt(i);
            if (el >= 'a' && el <= 'z')
                if (!list.contains(el))
                    list.add(el);
        }
        Collections.sort(list);
        return list.stream().map(Object::toString).collect(Collectors.joining(""));
    }
    public static String longest2 (String s1, String s2) {
        StringBuilder sb = new StringBuilder();
        (s1 + s2).chars().distinct().sorted().forEach(c -> sb.append((char) c));
        return sb.toString();
    }
}
