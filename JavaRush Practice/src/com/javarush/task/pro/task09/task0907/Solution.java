package com.javarush.task.pro.task09.task0907;

import java.util.regex.Pattern;

/* 
Шестнадцатеричный конвертер
*/

public class Solution {
    private static final String HEX = "0123456789abcdef";

    public static void main(String[] args) {
        int decimalNumber = 1256;
        System.out.println("Десятичное число " + decimalNumber + " равно шестнадцатеричному числу " + toHex(decimalNumber));
        String hexNumber = "4e8";
        System.out.println("Шестнадцатеричное число " + hexNumber + " равно десятичному числу " + toDecimal(hexNumber));
    }

    public static String toHex(int decimalNumber) {
        StringBuilder hexString = new StringBuilder();
        if (decimalNumber <= 0)
            return hexString.toString();
        while (decimalNumber != 0) {
            hexString.insert(0, HEX.charAt(decimalNumber % 16));
            decimalNumber /= 16;
        }
        return hexString.toString();
    }

    public static int toDecimal(String hexNumber) {
        int decimalNumber = 0;
        if (hexNumber == null || hexNumber.isEmpty())
            return decimalNumber;
        int len = hexNumber.length();
        for (int i = 0; i < len; i++) {
            decimalNumber = 16 * decimalNumber + HEX.indexOf(hexNumber.charAt(i));
        }
        return decimalNumber;
    }
}
