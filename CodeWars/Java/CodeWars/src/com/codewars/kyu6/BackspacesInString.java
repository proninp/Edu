package com.codewars.kyu6;

import java.util.Stack;

public class BackspacesInString {
    public static String cleanString(String s) {
        Stack<String> stack = new Stack<>();
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) != '#')
                stack.push(s.charAt(i) + "");
            else
                if (!stack.isEmpty())
                    stack.pop();
        }
        return String.join("", stack);
    }
}
