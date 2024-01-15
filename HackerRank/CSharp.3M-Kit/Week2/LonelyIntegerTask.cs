﻿namespace Week2;

/*
 * Lonely Integer
 * 
 * Given an array of integers, where all elements but one occur twice, find the unique element.
 * 
 * Example
 * a = [1, 2, 3, 4, 3, 2, 1]
 * The unique element is 4.
 * 
 * Function Description
 * Complete the Lonelyinteger function in the editor below.
 * Lonelyinteger has the following parameter(s):
 *  int a[n]: an array of integers
 * Returns
 *  int: the element that occurs only once
 */

public class LonelyIntegerTask
{
    public static int Lonelyinteger(List<int> a)
    {
        int result = 0;
        foreach (int num in a)
            result ^= num;
        return result;
    }
}
