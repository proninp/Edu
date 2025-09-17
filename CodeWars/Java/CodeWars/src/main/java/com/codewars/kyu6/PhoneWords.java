package main.java.com.codewars.kyu6;

import java.util.HashMap;

public class PhoneWords {
    public static String phoneWords(String str) {
        // 416666663105558822255
        if (str == null || str.isEmpty())
            return "";

        HashMap<String, String> dictionary = new HashMap<>();

        dictionary.put("0"," ");
        dictionary.put("1","");

        dictionary.put("2","a");
        dictionary.put("22","b");
        dictionary.put("222","c");

        dictionary.put("3","d");
        dictionary.put("33","e");
        dictionary.put("333","f");

        dictionary.put("4","g");
        dictionary.put("44","h");
        dictionary.put("444","i");

        dictionary.put("5","j");
        dictionary.put("55","k");
        dictionary.put("555","l");

        dictionary.put("6","m");
        dictionary.put("66","n");
        dictionary.put("666","o");

        dictionary.put("7","p");
        dictionary.put("77","q");
        dictionary.put("777","r");
        dictionary.put("7777","s");

        dictionary.put("8","t");
        dictionary.put("88","u");
        dictionary.put("888","v");

        dictionary.put("9","w");
        dictionary.put("99","x");
        dictionary.put("999","y");
        dictionary.put("9999","z");

        StringBuilder sb = new StringBuilder();
        int i = 0;
        while (i < str.length()) {
            StringBuilder sub = new StringBuilder(Character.toString(str.charAt(i)));
            while (((i + 1) < str.length()) &&
                    dictionary.containsKey(sub.toString() + str.charAt(i + 1))) {
                sub.append(str.charAt(++i));
            }
            sb.append(dictionary.get(sub.toString()));
            i++;
        }
        return sb.toString();
    }
}
