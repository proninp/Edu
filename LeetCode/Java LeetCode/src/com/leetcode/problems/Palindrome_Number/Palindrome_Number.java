package com.leetcode.problems.Palindrome_Number;

public class Palindrome_Number {
    public static boolean isPalindrome(int x) {
        int revert = 0, n = x;
        while(n > 0) {
            revert = revert * 10 + n % 10;
            n /= 10;
        }
        return revert == x;
    }
}
