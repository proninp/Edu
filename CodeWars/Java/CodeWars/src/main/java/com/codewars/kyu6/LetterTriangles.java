/*
 * Letter triangles
 * similar to Coloured triangles
 * But this one sums indexes of letters in alphabet.
 * c o d e w a r s
* c is 3
* o is 15
* 15+3=18
* 18. letter in the alphabet is r
* then append r
* next is o d
* sum is 19
* append s
* do this until you iterate through whole string
* now, string is rsibxsk
* repeat whole cycle until you reach 1 character
* then return the char
* output is l
* codewars -> l
 * triangle -> d
 */
package main.java.com.codewars.kyu6;

public class LetterTriangles {
    public static String triangle(final String row) {
        char[] a = row.toCharArray();
        if (a.length == 1)
            return String.valueOf(a[0]);
        char[] s = new char[a.length - 1];
        for (int i = 0; i < s.length; i++) {
            char c = (char)(a[i] + a[i + 1] - 'a' + 1) ;
            if (c > 'z')
                c -= 26;
            s[i] = c;
        }
        return triangle(new String(s));
    }
}
