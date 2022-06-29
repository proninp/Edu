import java.math.BigInteger;

public class Main {
    public static void main(String[] args) {
        //System.out.println(isPalindrome("Madam, I'm Adam!"));
        //System.out.println(factorial(10).toString());
        //System.out.println(Arrays.toString(mergeArrays(new int[]{1, 2, 5, 5, 8, 9, 11}, new int[]{1, 1, 6, 7, 8, 9, 10})));
        testPrintTextPerRole();
    }

    // 2.2
    public static boolean isPowerOfTwo(int value) {
        if (value == 0)
            return false;
        value = Math.abs(value);
        return ((value & (value - 1)) == 0);
    }

    // 2.3
    public static boolean isPalindrome(String text) {
        String result = text.replaceAll("[^a-zA-Z0-9]", "");
        return result.equalsIgnoreCase(new StringBuilder(result).reverse().toString());
    }

    // 2.4.1
    public static BigInteger factorial(int value) {
        if (value < 2)
            return BigInteger.ONE;
        return BigInteger.valueOf(value).multiply(factorial(value - 1));
    }

    // 2.4.2
    public static int[] mergeArrays(int[] a1, int[] a2) {
        int[] a3 = new int[a1.length + a2.length];
        int i = 0, j = 0, k = 0;
        while (i < a1.length && j < a2.length) {
            a3[k++] = a1[i] < a2[j] ? a1[i++] : a2[j++];
        }
        if (i < a1.length) {
            System.arraycopy(a1, i, a3, k, a1.length - i);
        } else {
            System.arraycopy(a2, j, a3, k, a2.length - j);
        }
        return a3;
    }

    public static void testPrintTextPerRole() {
        String[] roles = {
                "Городничий", "Аммос Федорович",
                "Артемий Филиппович",
                "Лука Лукич"};
        String[] textLines = {
                "Городничий: Я пригласил вас, господа, с тем, чтобы сообщить вам пренеприятное известие: к нам едет ревизор.",
                "Аммос Федорович: Как ревизор?",
                "Артемий Филиппович: Как ревизор?",
                "Городничий: Ревизор из Петербурга, инкогнито. И еще с секретным предписаньем.",
                "Аммос Федорович: Вот те на!",
                "Артемий Филиппович: Вот не было заботы, так подай!",
                "Лука Лукич: Господи боже! еще и с секретным предписаньем!"};
        System.out.println(printTextPerRole(roles, textLines));
    }

    public static String printTextPerRole(String[] roles, String[] textLines) {
        StringBuilder text = new StringBuilder(textLines.length + roles.length * 2);
        for (String role : roles) {
            String roleSeek = role.concat(": ");
            String roleTopic = role.concat(":\n");
            StringBuilder roleText = new StringBuilder();
            for (int j = 0; j < textLines.length; j++) {
                if (textLines[j].startsWith(roleSeek)) {
                    roleText.append(String.valueOf(j + 1).concat(") ").concat(textLines[j].substring(roleTopic.length())).concat("\n"));
                }
            }
            if (roleText.length() != 0)
                text.append(roleTopic).append(roleText).append("\n");
        }
        return text.toString();
    }
}