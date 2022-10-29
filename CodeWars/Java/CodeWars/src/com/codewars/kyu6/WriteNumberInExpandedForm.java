package com.codewars.kyu6;

public class WriteNumberInExpandedForm {
    public static String expandedForm(int num)
    {
        if (num == 0)
            return String.valueOf(num);
        StringBuilder result = new StringBuilder();
        int sum = 0;
        while (sum != num) {
            if (!result.isEmpty())
                result.append(" + ");
            int n = num - sum;
            int order = 1;
            while (n >= 10) {
                n/= 10;
                order *= 10;
            }
            int remains = n * order;
            sum += remains;
            result.append(remains);
        }
        return result.toString();
    }
}
