public class Main {
    public static void main(String[] args) {
        System.out.println(isPalindrome("Madam, I'm Adam!"));
    }
    public static boolean isPalindrome(String text) {
        String result = text.replaceAll("[^a-zA-Z0-9]", "");
        return result.equalsIgnoreCase(new StringBuilder(result).reverse().toString());
    }
}