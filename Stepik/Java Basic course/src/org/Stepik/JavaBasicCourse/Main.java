package org.Stepik.JavaBasicCourse;
import java.math.BigInteger;
import  org.Stepik.JavaBasicCourse.s3_5.*;

public class Main {
    public static void main(String[] args) {
        Test3_5();
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

    //region 2.4.2
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
    //endregion

    //region 3.3
    public static void moveRobot(Robot robot, int toX, int toY) {
        getMoveProperties(robot, toX, robot.getX(), Direction.RIGHT, Direction.LEFT);
        getMoveProperties(robot, toY, robot.getY(), Direction.UP, Direction.DOWN);
    }
    public static void getMoveProperties(Robot robot, int moveTo, int currentCoord, Direction lessPointDir, Direction greaterPointDir) {
        if (moveTo == currentCoord)
            return;
        Direction newDirection = robot.getDirection();
        int steps = 0;
        if (currentCoord < moveTo) {
            newDirection = lessPointDir;
            steps = moveTo - currentCoord;
        } else {
            newDirection = greaterPointDir;
            steps = currentCoord - moveTo;
        }
        while (robot.getDirection() != newDirection)
            robot.turnLeft();
        while (steps-- > 0)
            robot.stepForward();
    }
    //endregion

    // region 3.5
    Label checkLabels(TextAnalyzer[] analyzers, String text) {
        for (TextAnalyzer analyzer: analyzers) {
            if (analyzer.processText(text) != Label.OK)
                return analyzer.processText(text);
        }
        return Label.OK;
    }
    public static void Test3_5() {
        // инициализация анализаторов для проверки в порядке данного набора анализаторов
        String[] spamKeywords = {"spam", "bad"};
        int commentMaxLength = 40;
        TextAnalyzer[] textAnalyzers1 = {
                new SpamAnalyzer(spamKeywords),
                new NegativeTextAnalyzer(),
                new TooLongTextAnalyzer(commentMaxLength)
        };
        TextAnalyzer[] textAnalyzers2 = {
                new SpamAnalyzer(spamKeywords),
                new TooLongTextAnalyzer(commentMaxLength),
                new NegativeTextAnalyzer()
        };
        TextAnalyzer[] textAnalyzers3 = {
                new TooLongTextAnalyzer(commentMaxLength),
                new SpamAnalyzer(spamKeywords),
                new NegativeTextAnalyzer()
        };
        TextAnalyzer[] textAnalyzers4 = {
                new TooLongTextAnalyzer(commentMaxLength),
                new NegativeTextAnalyzer(),
                new SpamAnalyzer(spamKeywords)
        };
        TextAnalyzer[] textAnalyzers5 = {
                new NegativeTextAnalyzer(),
                new SpamAnalyzer(spamKeywords),
                new TooLongTextAnalyzer(commentMaxLength)
        };
        TextAnalyzer[] textAnalyzers6 = {
                new NegativeTextAnalyzer(),
                new TooLongTextAnalyzer(commentMaxLength),
                new SpamAnalyzer(spamKeywords)
        };
        // тестовые комментарии
        String[] tests = new String[8];
        tests[0] = "This comment is so good.";                            // OK
        tests[1] = "This comment is so Loooooooooooooooooooooooooooong."; // TOO_LONG
        tests[2] = "Very negative comment !!!!=(!!!!;";                   // NEGATIVE_TEXT
        tests[3] = "Very BAAAAAAAAAAAAAAAAAAAAAAAAD comment with :|;";    // NEGATIVE_TEXT or TOO_LONG
        tests[4] = "This comment is so bad....";                          // SPAM
        tests[5] = "The comment is a spam, maybeeeeeeeeeeeeeeeeeeeeee!";  // SPAM or TOO_LONG
        tests[6] = "Negative bad :( spam.";                               // SPAM or NEGATIVE_TEXT
        tests[7] = "Very bad, very neg =(, very ..................";      // SPAM or NEGATIVE_TEXT or TOO_LONG
        TextAnalyzer[][] textAnalyzers = {textAnalyzers1, textAnalyzers2, textAnalyzers3,
                textAnalyzers4, textAnalyzers5, textAnalyzers6};
        Main testObject = new Main();
        int numberOfAnalyzer; // номер анализатора, указанный в идентификаторе textAnalyzers{№}
        int numberOfTest = 0; // номер теста, который соответствует индексу тестовых комментариев
        for (String test : tests) {
            numberOfAnalyzer = 1;
            System.out.print("test #" + numberOfTest + ": ");
            System.out.println(test);
            for (TextAnalyzer[] analyzers : textAnalyzers) {
                System.out.print(numberOfAnalyzer + ": ");
                System.out.println(testObject.checkLabels(analyzers, test));
                numberOfAnalyzer++;
            }
            numberOfTest++;
        }
    }

    //endregion
}