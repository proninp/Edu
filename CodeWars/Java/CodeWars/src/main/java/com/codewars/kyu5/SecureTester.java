/*
 * In this example you have to validate if a user input string is alphanumeric.
 * The given string is not nil/null/NULL/None, so you don't have to check that.
 * The string has the following conditions to be alphanumeric:
 * At least one character ("" is not valid)
 * Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
 * No whitespaces / underscore
 */
package main.java.com.codewars.kyu5;

public class SecureTester {
    public static boolean alphanumeric(String s){
        if (s.isEmpty())
            return false;
        for (char c: s.toCharArray()) {
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                return false;
        }
        return true;
    }
    public static boolean alphanumeric2(String s) {
        return s.matches("[A-Za-z0-9]+");
    }

}
