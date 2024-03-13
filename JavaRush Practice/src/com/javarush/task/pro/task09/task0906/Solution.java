package com.javarush.task.pro.task09.task0906;

import java.util.regex.Pattern;

/* 
Двоичный конвертер
*/

public class Solution {
    public static void main(String[] args) {
        int decimalNumber = Integer.MAX_VALUE;
        System.out.println("Десятичное число " + decimalNumber + " равно двоичному числу " + toBinary(decimalNumber));
        String binaryNumber = "1111111111111111111111111111111";
        System.out.println("Двоичное число " + binaryNumber + " равно десятичному числу " + toDecimal(binaryNumber));
    }

    public static String toBinary(int decimalNumber) {
        String binaryString = "";
        if (decimalNumber <= 0)
            return binaryString;
        while (decimalNumber != 0) {
            binaryString = decimalNumber % 2 + binaryString;
            decimalNumber /= 2;
        }
        return binaryString;
    }

    public static int toDecimal(String binaryNumber) {
        int decimalNumber = 0;
        if (binaryNumber == null || binaryNumber.isEmpty())
            return decimalNumber;
        int len = binaryNumber.length();
        for (int i = 0; i < len; i++) {
            int index = len - 1 - i;
            decimalNumber += (binaryNumber.charAt(index) - '0') * (int)Math.pow(2, i);
        }
        return decimalNumber;
    }
}
