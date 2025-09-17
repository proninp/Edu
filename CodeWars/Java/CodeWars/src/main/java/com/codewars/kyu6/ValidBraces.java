package main.java.com.codewars.kyu6;

import java.util.Stack;

public class ValidBraces {
    public static boolean isValid(String braces) {
        String openBraces = "({[";
        Stack<String> stack = new Stack<>();
        for (int i = 0; i < braces.length(); i++) {
            String singleChar = braces.charAt(i) + "";
            if (openBraces.contains(singleChar))
                stack.push(singleChar);
            else {
                if (stack.isEmpty())
                    return false;
                String popChar = stack.pop();
                if (!((popChar.equals("{") && singleChar.equals("}")) ||
                        (popChar.equals("[") && singleChar.equals("]")) ||
                        (popChar.equals("(") && singleChar.equals(")"))))
                    return false;
                }
        }
        return stack.isEmpty();
    }
}
