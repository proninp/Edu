import com.codewars.kyu7.*;
public class Main {
    public static void main(String[] args) {
        String test = "Hello world!";
        String test2 = CircleCipher.encode(test);
        System.out.println(test2);
        System.out.println(CircleCipher.decode(test2));
    }
}