/*
 * Your task is to sort a given string. Each word in the string will contain a single number.
 * This number is the position the word should have in the result.
 * Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).
 * If the input string is empty, return an empty string.
 * The words in the input String will only contain valid consecutive numbers.
 *
 * "is2 Thi1s T4est 3a"  -->  "Thi1s is2 3a T4est"
 * "4of Fo1r pe6ople g3ood th5e the2"  -->  "Fo1r the2 g3ood 4of th5e pe6ople"
 */
package main.java.com.codewars.kyu6;

public class YoutOrderPlease {
    public static String order(String words) {
        String[] wordsArray = words.split("\\s+");
        int size = wordsArray.length;
        StringBuilder stringBuilder = new StringBuilder();
        String[] positions = new String[size];
        for (int i = 0; i < size; i++) {
            int pos = getOrderFromWord(wordsArray[i]) - 1;
            if (pos >= 0)
                positions[pos] = wordsArray[i];
        }
        for (int i = 0; i < size; i++) {
            if (positions[i] != null && !positions[i].isEmpty()) {
                if (stringBuilder.length() > 0)
                    stringBuilder.append(" ");
                stringBuilder.append(positions[i]);
            }
        }
        return stringBuilder.toString();
    }
    private static int getOrderFromWord(String word) {
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            if (Character.isDigit(c))
                return Character.getNumericValue(c);
        }
        return -1;
    }
}
