package main.java.com.codewars.kyu7.exesAndOhs;

public class XO {
    public static boolean getXO (String str) {
        var score = 0;
        for (int i = 0; i < str.length(); i++) {
            var c = Character.toLowerCase(str.charAt(i));
            if (c == 'x') {
                score++;
            } else if (c == 'o') {
                score--;
            }
        }
        return score == 0;
    }
}
