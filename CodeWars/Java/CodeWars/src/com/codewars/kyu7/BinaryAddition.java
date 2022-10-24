package com.codewars.kyu7;

public class BinaryAddition {
    public static String binaryAddition(int a, int b){
        return toBinary(a + b);
    }
    static String toBinary(int a) {
        String res = "";
        while (a > 1) {
            res = (a % 2) + res;
            a /= 2;
        }
        return a + res;
    }
}
