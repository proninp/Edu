package com.codewars.kyu5;

import java.util.Stack;

public class ValidParentheses {
    public static boolean validParentheses(String parens)
    {
        Stack<Character> stack = new Stack<>();
        for (int i = 0; i < parens.length(); i++) {
            char c = parens.charAt(i);
            if (c != '(' && c != ')') continue;
            if (stack.isEmpty()) {
                if (c != '(') return false;
                stack.push(c);
            } else
                if (c == ')' && stack.peek() == '(')
                    stack.pop();
                else
                    stack.push(c);
        }
        return stack.isEmpty();
    }
}
