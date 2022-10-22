/*
 * Your task is to make a function that can take any non-negative integer as an argument and
 * return it with its digits in descending order. Essentially,
 * rearrange the digits to create the highest possible number.
 */

package com.codewars.kyu7;

import java.util.Arrays;
import java.util.Collections;
import java.util.LinkedList;

public class DescendingOrder {
    public static int sortDesc(final int num) {
        int n = num;
        LinkedList<Integer> linkedList = new LinkedList<>();
        while(n > 0) {
            ListInsert(linkedList,n % 10);
            n /= 10;
        }
        int res = 0;
        for (int i = 0; i < linkedList.size(); i++)
            res = res * 10 + linkedList.get(i);
        return res;

    }
    static void ListInsert(LinkedList<Integer> list, int n) {
        int i = 0;
        while (i < list.size()) {
            if (n >= list.get(i))
                break;
            i++;
        }
        list.add(i, n);
    }
    public static int sortDescStr(final int num) {
        String[] array = String.valueOf(num).split("");
        Arrays.sort(array, Collections.reverseOrder());
        return Integer.parseInt(String.join("", array));
    }
}
