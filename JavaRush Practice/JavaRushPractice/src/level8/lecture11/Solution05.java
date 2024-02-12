package level8.lecture11;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Solution05 {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String string = reader.readLine();
        String[] words = string.split(" ");
        for (int i = 0; i < words.length; i++) {
            if (!words[i].isEmpty())
                words[i] = Character.toUpperCase(words[i].charAt(0)) + words[i].substring(1);
        }
        System.out.println(String.join(" ", words));
    }
}
