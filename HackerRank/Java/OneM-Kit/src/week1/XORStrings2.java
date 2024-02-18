package week1;

/**
 * XOR Strings 2
 * <p>
 * In this challenge, the task is to debug the existing code to successfully execute all provided test files.
 * Given two strings consisting of digits 0 and 1 only, find the XOR of the two strings.
 * Debug the given function Strings_xor to find the XOR of the two given strings appropriately.
 * Note: You can modify at most three lines in the given code and you cannot add or remove lines to the code.
 * To restore the original code, click on the icon to the right of the language selector.
 * <p>
 * Input Format
 * The input consists of two lines. The first line of the input contains the first string, s, and the second line contains
 * the second string, t.
 * <p>
 * Output Format
 * Print the string obtained by the XOR of the two input strings in a single line.
 */
public class XORStrings2 {
    public static String stringsXOR(String s, String t) {
        String res = new String("");
        for(int i = 0; i < s.length(); i++) {
            if(s.charAt(i) == t.charAt(i))
                res += "0";
            else
                res += "1";
        }
        return res;
    }
}
