package syntax.level.l009.lecture11;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution05 {
    public static char[] vowels = new char[]{'а', 'я', 'у', 'ю', 'и', 'ы', 'э', 'е', 'о', 'ё'};

    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String input = reader.readLine();

        StringBuilder vowelsBuilder = new StringBuilder();
        StringBuilder consonantsBuilder = new StringBuilder();

        for(char c : input.toCharArray()) {
            if (isVowel(c)) {
                vowelsBuilder.append(c).append(" ");
            }
            else if (c != ' ') {
                consonantsBuilder.append(c).append(" ");
            }
        }
        System.out.println(vowelsBuilder);
        System.out.println(consonantsBuilder);
    }
    public static boolean isVowel(char character) {
        character = Character.toLowerCase(character);  // приводим символ в нижний регистр - от заглавных к строчным буквам
        for (char vowel : vowels) {  // ищем среди массива гласных
            if (character == vowel) {
                return true;
            }
        }
        return false;
    }
}
