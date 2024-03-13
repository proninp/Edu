package com.javarush.task.pro.task09.task0908;

/*
Двоично-шестнадцатеричный конвертер
*/

public class Solution {

    private static final String HEX = "0123456789abcdef";
    private static final String[] BINARY_HEX = {"0000", "0001", "0010", "0011", "0100", "0101", "0110",
            "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"};

    public static void main(String[] args) {
        String binaryNumber = "110001100100";
        System.out.println("Двоичное число " + binaryNumber + " равно шестнадцатеричному числу " + toHex(binaryNumber));
        String hexNumber = "c64";
        System.out.println("Шестнадцатеричное число " + hexNumber + " равно двоичному числу " + toBinary(hexNumber));
    }

    public static String toHex(String binaryNumber) {
        StringBuilder hexNumber = new StringBuilder();
        if (binaryNumber == null || binaryNumber.isEmpty()) return hexNumber.toString();
        while (binaryNumber.length() % 4 != 0) {
            binaryNumber = "0".concat(binaryNumber);
        }
        for (int i = 0; i < binaryNumber.length(); i++) {
            char bit = binaryNumber.charAt(i);
            if (bit != '0' && bit != '1') {
                return "";
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < binaryNumber.length(); i += 4) {
            sb.append(binaryNumber, i, i + 4);
            for (int j = 0; j < BINARY_HEX.length; j++) {
                if (BINARY_HEX[j].equals(sb.toString())) {
                    hexNumber.append(HEX.charAt(j));
                    break;
                }
            }
            sb = new StringBuilder();
        }
        return hexNumber.toString();
    }

    public static String toBinary(String hexNumber) {
        StringBuilder binarySb = new StringBuilder("");
        if (hexNumber == null || hexNumber.isEmpty()) return binarySb.toString();
        for (int i = 0; i < hexNumber.length(); i++) {
            int index = HEX.indexOf(hexNumber.charAt(i));
            if (index == -1)
                return "";
            binarySb.append(BINARY_HEX[index]);
        }
        return binarySb.toString();
    }
}
